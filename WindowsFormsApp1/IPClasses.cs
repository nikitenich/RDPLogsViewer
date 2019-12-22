using System;
using System.Net;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Xml;
using System.Windows.Forms;

namespace RDPLogsViewer
{
    public class IPData {
        private IPAddress _ip;
        private int _mask;
        private byte[] MaskBytes;

        [DisplayName("IP-адрес")]
        public IPAddress IP {
            get {
                return _ip;
            }
            set {
                _ip = value;
                if (_mask != 0)
                {
                    MaskBytes = generateMaskByCIDR(_mask);
                    _ip = new IPAddress(calculateNetworkAddress());
                    
                }
            }
        }

        [DisplayName("Маска")]
        public int Mask {
            get {
                return _mask;
            }
            set
            {
                if (value <= 32 && value >= 0)
                {
                    _mask = value;
                    MaskBytes = generateMaskByCIDR(value);
                    IP = new IPAddress(calculateNetworkAddress());
                }
                else { MessageBox.Show("Некорректное значение маски"); }
            }
        }

 
        public IPData(IPAddress ip, int mask) {
            this.IP = ip;
            this.Mask = mask;
            this.MaskBytes = generateMaskByCIDR(mask);
            this.IP = new IPAddress(calculateNetworkAddress());
        }

        public byte[] getMaskBytes()
        {
            return MaskBytes;
        }

        /// <summary>
        /// Генерация маски сети по нотации CIDR (/n)
        /// </summary>
        /// <param name="n">n</param>
        /// <returns>4 байта маски</returns>
        public static byte[] generateMaskByCIDR(int n)
        {
            int ip = 0;
            for (int i = 0; i < n; i++)
            {
                ip |= 1 << (31 - i);
            }
             
            byte[] ipBytes = BitConverter.GetBytes(ip);
            Array.Reverse(ipBytes, 0, ipBytes.Length);

            return ipBytes;
        }

        /// <summary>
        /// Вычисление адреса сети
        /// </summary>
        /// <returns>4 байта адреса сети</returns>
        public byte[] calculateNetworkAddress()
        {
            byte[] networkBytes = new byte[4];
            byte[] ipBytes = this.IP.GetAddressBytes();

            for (int i = 0; i < networkBytes.Length; i++)
            {
                int a = ipBytes[i] & MaskBytes[i];
                networkBytes[i] = Convert.ToByte(a);
            }

            return networkBytes;
        }
        /// <summary>
        /// Получение из массива байт строчного IP
        /// </summary>
        /// <param name="ip">Байты IP-адрес</param>
        /// <returns>IP-адрес-строка</returns>
        public static string IPbytesToHumanString(byte[] ip)
        {
            string str = "";
            for (int i = 0; i < ip.Length; i++)
            {
                str += ip[i] + ".";
            }

            return str.Substring(0, str.Length - 1);
        }

        /// <summary>
        /// Проверка, является ли строка IP-адресом
        /// </summary>
        /// <param name="input">Строка к проверке</param>
        /// <returns>true, если да, false, если нет</returns>
        public static bool checkStringIsIP(string input) {
            Match match = Regex.Match(input, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}"); //^$
            if (match.Success)
            {
                IPAddress addr;
                IPAddress.TryParse(match.Value.ToString(), out addr);
                if (addr!=null)
                    return true;
            }

            return false;
            }

        /// <summary>
        /// Получение IP-адреса из события в XML-формате (работает только для определённого типа событий)
        /// </summary>
        /// <param name="inputXML">Строка в XML-формате</param>
        /// <returns>IPv4-адрес в строковом виде</returns>
        public static string GetIPfromEventXML(string inputXML)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(inputXML);
            XmlElement root = doc.DocumentElement;

            foreach (XmlNode node in root)
            {
                foreach (XmlNode childnode in node.ChildNodes)
                {
                    if (childnode.Name == "EventData") //EventXML
                    {
                        /*return 
                            childnode.LastChild.InnerText.ToString();*/
                        foreach (XmlNode prechi in childnode) {
                            if (prechi.Name == "IpAddress") {
                                return prechi.InnerText.ToString();
                            }
                        }
                    }
                }
            }
            return null;
        }
    }

    public class IPWhiteList
    {
        private static IPWhiteList instance;
        private static object syncRoot = new Object();
        private static BindingList<IPData> _IPWhiteList = new BindingList<IPData>(); //список всех экземпляров класса
        private static BindingList<IPData> _IPLocalList = new BindingList<IPData>(); //список локальных адресов (юзается только в статистике)

        protected IPWhiteList()
        {
            // раз и навсегда заполняем список локальных адресов
            _IPLocalList.Add(new IPData(IPAddress.Parse("192.168.0.0"), 16));
            _IPLocalList.Add(new IPData(IPAddress.Parse("10.0.0.0"), 8));
            _IPLocalList.Add(new IPData(IPAddress.Parse("172.16.0.0"), 12));
            _IPLocalList.Add(new IPData(IPAddress.Parse("127.0.0.0"), 8));

        }

        public static IPWhiteList getInstance() {
            if (instance == null) {
                lock (syncRoot) {
                    if (instance == null)
                        instance = new IPWhiteList();
                }
            }
            return instance;
        }

        /// <summary>
        /// Добавление в белый список
        /// </summary>
        /// <param name="ipData"></param>
        public void addToWhiteList(IPData ipData) {
            _IPWhiteList.Add(ipData);
        }
        
        /// <summary>
        /// Получение BindingList белого списка
        /// </summary>
        /// <returns></returns>
        public BindingList<IPData> getWhiteList() {
            return _IPWhiteList;
        }

        /// <summary>
        /// Получение списка локальных адресов
        /// </summary>
        /// <returns></returns>
        public BindingList<IPData> getLocalList()
        {
            return _IPLocalList;
        }

        /// <summary>
        /// Проверка, удовлетворяет ли белому списку IP-адрес (обегает весь)
        /// </summary>
        /// <param name="ipToCheck">IP-адрес к проверке</param>
        /// <param name="byLocal">Поиск по общему списку, либо же только по локальным адресам
        /// true - только по локальным адресам
        /// false - по всему белому списку
        /// </param>
        /// <returns>true, если входит, false, если нет</returns>
        public bool IsIPinList(IPAddress ipToCheck, bool byLocal)
        {
            byte[] ipToCheckBytes = ipToCheck.GetAddressBytes(); //байты ip-адреса к проверке
            byte[] ipToCheckBytesWithMask = new byte[4];


            //if (IPAddress.IsLoopback(ipToCheck)) return false;

            var list = (byLocal) ? _IPLocalList : _IPWhiteList;

            bool allBytesEq = false; //совпадают ли полностью 2 сравниваемых адреса? 
            foreach (IPData item in list) { //Обегаем весь список
                IPAddress ipFromWhiteList = item.IP;   //получаем IP из списка
                byte[] curMaskBytes = item.getMaskBytes(); //и маску из него же
            
                byte[] ipFromWhiteListBytes = ipFromWhiteList.GetAddressBytes(); //получение адреса сети

                for (int i = 0; i < 4; i++)
                {
                    ipToCheckBytesWithMask[i] = Convert.ToByte(ipToCheckBytes[i] & curMaskBytes[i]); //накладываем маску на проверяемый IP
                                                                                                     //маска тут каждый раз из белого списка
                    if (ipToCheckBytesWithMask[i] != ipFromWhiteListBytes[i]) // если хотя бы один байт не совпал                
                    {
                        allBytesEq = false;
                        break; //дальше проверять смысла нет
                    }
                    else allBytesEq = true;
                }

                if (allBytesEq) return allBytesEq;
            }
            return false;
        }
    }
}