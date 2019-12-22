using System;
using System.Collections.Generic;
using System.Net;

namespace RDPLogsViewer
{
    /// <summary>
    /// Класс, описывающий элемент статистики
    /// </summary>
    public class StatisticElement
    {
        IPWhiteList whiteList = IPWhiteList.getInstance(); //получаем белый список
        public string _ip; // адрес
        public bool _isLocal { get; } //является ли адрес локальным
        public int _count { get; set; }  // количество встреченных таких адресов

        public StatisticElement(string ip) 
        {
            this._ip = ip;

            //if (ip != "LOCAL") // мм, костыли
            IPAddress address;
            if (IPAddress.TryParse(ip, out address))
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    this._isLocal = whiteList.IsIPinList(IPAddress.Parse(ip), true);
            }
            else this._isLocal = true;  // просто на вход если и придёт что-то отличное от адреса, то это будет строка
                                        // LOCAL, или как-то так в локализованных виндах, поэтому выставляем true

            _count++;
        }
    }

    /// <summary>
    /// Класс, описывающий набор статистических элементов
    /// </summary>
    public class Statistics {
        private static Statistics instance; // очередной синглетон, будто другие паттерны не знаю
        private static object syncRoot = new Object();

        private static List<StatisticElement> _StatList = new List<StatisticElement>();
        public int countElem { get; set; }        // общее количество полученных IP-адресов
        public int countLocal { get; set; }      // общее количество событий с локальными адресами
        public int countExternal { get; set; }  // общее количество событий с внешними адресами

        protected Statistics() { }

        public static Statistics getInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new Statistics();
                }
            }
            return instance;
        }

        /// <summary>
        /// Добавление в список статы
        /// </summary>
        /// <param name="statElem">Элемент статы</param>
        public void addToStat(StatisticElement statElem) {
            if (!_StatList.Exists(element => element._ip.Equals(statElem._ip)))
                //Если в статистике ещё нет элемента с определённым  IP-адресом
                _StatList.Add(statElem);
            else {
                var findedEqualElement = _StatList.Find(element => element._ip.Equals(statElem._ip));
                findedEqualElement._count += 1;      
                //раз есть, то увеличиваем счётчик, сколько раз он встречается
                }
        }

        /// <summary>
        /// Получение статистики
        /// </summary>
        /// <returns></returns>
        public List<StatisticElement> getStatList() {
            return _StatList;
        }

        /// <summary>
        /// Отчистка статистики
        /// </summary>
        public void clearStat() {
            _StatList.Clear();
            countElem = 0;
            countLocal = 0;
            countExternal = 0;
        }

        /// <summary>
        /// Подсчёт статистики
        /// </summary>
        public void calcStat() {
            countElem = 0;
            countLocal = 0;
            countExternal = 0;
            foreach (StatisticElement elem in _StatList) {
                if (elem._isLocal) {
                    countLocal += elem._count;
                }
                countElem += elem._count;
            }
            countExternal = countElem - countLocal;
        } 
    }
}