using System;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;
using static RDPLogsViewer.RDPEvents;

namespace RDPLogsViewer
{
    class RDPEvents
    {
        public enum SecurityIDs : int {
            AuthSuccessLoggedOn = 4624, //Security
            AuthFailedLogOn = 4625, //Security

            SessionDisconnectedToWS = 4778, //Security
            SessionDisconnectedFromWS = 4779, //Security

            AccountWasLoggedOff = 4634, //Security
            UserInitialedLogoff = 4647, //Security
        }

        public enum RemoteConnectionManagerIDs : int {
            NetworkUserAuthSuccess = 1149, //Microsoft-Windows-TerminalServices-RemoteConnectionManager/Operational
        }

        public enum LocalServiceManagerIDs : int {
            RDPServiceStartFailed = 17, ////Microsoft-Windows-TerminalServices-LocalSessionManager/Operational

            SessionLogonSucceded = 21, //Microsoft-Windows-TerminalServices-LocalSessionManager/Operational
            ShellStartNotifRecieved = 22, //Microsoft-Windows-TerminalServices-LocalSessionManager/Operational

            SessionHasBeenDisconnected = 24, //Microsoft-Windows-TerminalServices-LocalSessionManager/Operational
            SessionReconnectionSucceded = 25, //Microsoft-Windows-TerminalServices-LocalSessionManager/Operational
            SessionDisconnectedBySession = 39, //Microsoft-Windows-TerminalServices-LocalSessionManager/Operational
            SessionDisconnectedByReason = 40, //Microsoft-Windows-TerminalServices-LocalSessionManager/Operational
            SessionLogoffSucceded = 23, //Microsoft-Windows-TerminalServices-LocalSessionManager/Operational
        }

        public enum SystemIDs :int  {
            WindowManagExited = 9009 //System
        }


        public struct RDPEvent
        {
            private int _num;
            private string _caption;

            public RDPEvent(LocalServiceManagerIDs type, string caption)
            {
                _num = (int)type;
                _caption = caption;
            }
            public RDPEvent(RemoteConnectionManagerIDs type, string caption) {
                _num = (int)type;
                _caption = caption;
            }

            public RDPEvent(SecurityIDs type, string caption)
            {
                _num = (int)type;
                _caption = caption;
            }

            public RDPEvent(SystemIDs type, string caption)
            {
                _num = (int)type;
                _caption = caption;
            }

            public int GetNumber()
            {
                return _num;
            }

            public override string ToString()
            {
                return _caption;
            }
        }

        public static object[] GetLocalServiceManagerIDs()
        {
            return new object[]
            {
                new RDPEvent(LocalServiceManagerIDs.RDPServiceStartFailed, "17: RDP Service Start Failed"),
                new RDPEvent(LocalServiceManagerIDs.SessionLogonSucceded, "21: Session logon succeeded"),
                new RDPEvent(LocalServiceManagerIDs.ShellStartNotifRecieved, "22: Shell start notification received"),
                new RDPEvent(LocalServiceManagerIDs.SessionLogoffSucceded, "23: Session logoff succeded"),
                new RDPEvent(LocalServiceManagerIDs.SessionHasBeenDisconnected, "24: Session has been disconnected"),
                new RDPEvent(LocalServiceManagerIDs.SessionReconnectionSucceded, "25: Session reconnection succeeded"),
                new RDPEvent(LocalServiceManagerIDs.SessionDisconnectedBySession, "39: Session <X> has been disconnected by session <Y>"),
                new RDPEvent(LocalServiceManagerIDs.SessionDisconnectedByReason, "40: Session <X> has been disconnected by reason"),
            };
        }

        public static object[] GetRemoteConnectionManagerIDs()
        {
            return new object[]
            {
                new RDPEvent(RemoteConnectionManagerIDs.NetworkUserAuthSuccess, "1149: Network user authentification succeeded"),
            };
        }

        public static object[] GetSecurityIDs()
        {
            return new object[]
            {
                new RDPEvent(SecurityIDs.AuthSuccessLoggedOn, "4624: An account was successfully logged on"),
                new RDPEvent(SecurityIDs.AuthFailedLogOn, "4625: An account failed to log on"),
                new RDPEvent(SecurityIDs.AccountWasLoggedOff, "4634: An account was logged off"),
                new RDPEvent(SecurityIDs.UserInitialedLogoff, "4647: User initiated logoff"),
                new RDPEvent(SecurityIDs.SessionDisconnectedToWS, "4778: A session was reconnected to a Window Station"),
                new RDPEvent(SecurityIDs.SessionDisconnectedFromWS, "4779: A session was disconnected from a Window Station"),
                
            };
        }

        public static object[] GetSystemIDs() {
            return new object[] {
                new RDPEvent(SystemIDs.WindowManagExited, "9009: The Desktop Window Manager has exited"),
            };
        }

    }

    public class myEvent {
        public int _id { get;}
        public string _entryType { get; }
        public DateTime? _timeGenerated { get; }
        public string _machineName { get; }
        public string _message { get; }
        public string _ip { get; }
        private Statistics stat = Statistics.getInstance();
        public static int count { get; set; }


        public myEvent(EventRecord eventInstance) {
            _id = eventInstance.Id;
            _entryType = eventInstance.LevelDisplayName;
            _timeGenerated = eventInstance.TimeCreated;
            _machineName = eventInstance.MachineName;
            _message = eventInstance.FormatDescription();
            /*_ip = AnEventWithIP(eventInstance) ? IPData.GetIPfromEventXML(eventInstance.ToXml()) : 
                anotherIPMethod(eventInstance.FormatDescription().ToString());*/
            _ip = getIPByTextDescription(_message);

            if (_ip != "") { //если у события есть IP-адрес, то используем это в дальнейшем в статистике
                stat.addToStat(new StatisticElement(_ip));
            }
            count++;
        }

        /// <summary>
        /// Содержит ли событие в себе IP-адрес
        /// </summary>
        /// <param name="EventRecord">Событие</param>
        /// <returns>Истина, если содержит в себе IP</returns>
        public static bool AnEventWithIP(EventRecord eventInstance)
        {
            return !(eventInstance.Id == (int)LocalServiceManagerIDs.SessionDisconnectedBySession ||
                eventInstance.Id == (int)LocalServiceManagerIDs.SessionDisconnectedByReason ||
                eventInstance.Id == (int)LocalServiceManagerIDs.SessionLogoffSucceded ||
                eventInstance.Id == (int)LocalServiceManagerIDs.RDPServiceStartFailed ||
                eventInstance.Id == (int)SecurityIDs.AccountWasLoggedOff ||
                eventInstance.Id == (int)SecurityIDs.AuthFailedLogOn ||
                eventInstance.Id == (int)SecurityIDs.AuthSuccessLoggedOn ||
                eventInstance.Id == (int)SecurityIDs.SessionDisconnectedFromWS ||
                eventInstance.Id == (int)SecurityIDs.SessionDisconnectedToWS ||
                eventInstance.Id == (int)SecurityIDs.UserInitialedLogoff ||
                eventInstance.Id == (int)SystemIDs.WindowManagExited); //у 23, 40, 17 и 29 событий нет IP-адресов, поэтому выводить их не будем
        }

        public static string getIPByTextDescription(string input) {
            bool eng = input.Contains("Source Network Address:");
            bool ru = input.Contains("Сетевой адрес источника:");
            int first = 0;

            if (eng)
            {
                first = input.IndexOf("Source Network Address:") + "Source Network Address:".Length;

            }
            else if (ru) {
                first = input.IndexOf("Сетевой адрес источника:") + "Сетевой адрес источника:".Length;
            }

            string unstr = input.Substring(first, input.Length - first);
            Match match1 = Regex.Match(unstr, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
            if (match1.Success)
                return match1.Value.ToString();

            Match match2 = Regex.Match(unstr, @"LOCAL");
            if (match2.Success)
                return match2.Value.ToString();

            Match match3 = Regex.Match(unstr, @"ЛОКАЛЬНЫЕ");
            if (match3.Success)
                return match3.Value.ToString();

            return "";
        }
    }
}