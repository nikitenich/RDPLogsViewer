using Microsoft.VisualStudio.TestTools.UnitTesting;
using RDPLogsViewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDPLogsViewer.Tests
{
    [TestClass()]
    public class StatisticsTests
    {
        [TestMethod()]
        public void addToStatTest()
        {
            Statistics stat = Statistics.getInstance();
            stat.addToStat(new StatisticElement("192.168.1.1")); 
            stat.calcStat();

            //добавили 1 элемент и проверяем, что упоминается он один раз.
            Assert.AreEqual(1, stat.getStatList().Find(
                element => element._ip.Equals("192.168.1.1")
                )._count);

            //добавим его ещё раз, упоминаний должно быть 2
            stat.addToStat(new StatisticElement("192.168.1.1"));
            stat.calcStat();
            Assert.AreEqual(2, stat.getStatList().Find(
                element => element._ip.Equals("192.168.1.1")
                )._count);
            Assert.AreEqual(1, stat.getStatList().Count); // но при этом количество IP всё ещё одно

            //добавим внешний адрес
            stat.addToStat(new StatisticElement("212.35.64.66"));
            stat.calcStat();
            Assert.AreEqual(2, stat.getStatList().Count); // адресов уже 2

            Assert.AreEqual(3, stat.countElem); //общее количество добавленных событий
            Assert.AreEqual(2, stat.countLocal); //общее количество событий с локальными адресами
            Assert.AreEqual(1, stat.countExternal); //общее количество с внешними адресами
        }
    }
}