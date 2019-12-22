using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace RDPLogsViewer.Tests
{
    [TestClass()]
    public class IPDataTests
    {
        [TestMethod()]
        public void generateMaskByCIDRTest16()
        {

            byte[] expectedBytes = { 255, 255, 0, 0 };
            byte[] actualBytes = IPData.generateMaskByCIDR(16);
            CollectionAssert.AreEqual(expectedBytes, actualBytes);
        }

        [TestMethod()]
        public void calculateNetworkAddressTest()
        {
            IPAddress expectedIP = IPAddress.Parse("192.168.0.0");
            IPData test = new IPData(IPAddress.Parse("192.168.10.0"), 16);

            Assert.AreEqual(expectedIP, test.IP);
        }

        [TestMethod()]
        public void IPbytesToHumanStringTest()
        {
            string expected = "192.168.0.1";
            string actual = IPData.IPbytesToHumanString(new byte[] { 192, 168, 0, 1 });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void checkStringIsIP()
        {
            Assert.AreEqual(IPData.checkStringIsIP("192.168.0.0"), true);
            Assert.AreEqual(IPData.checkStringIsIP("255.255.255.255"), true);
            Assert.AreNotEqual(IPData.checkStringIsIP("192f168.0.1"), true);
            Assert.AreNotEqual(IPData.checkStringIsIP("asdf"), true);
            Assert.AreNotEqual(IPData.checkStringIsIP("256.255.255.255"), true);

        }

        [TestMethod()]
        public void IsIPinListTest()
        {
            IPWhiteList whitelist = IPWhiteList.getInstance();
            whitelist.addToWhiteList(new IPData(IPAddress.Parse("192.168.0.10"),16));
            whitelist.addToWhiteList(new IPData(IPAddress.Parse("95.168.9.3"),24));

            Assert.IsTrue(whitelist.IsIPinList(IPAddress.Parse("192.168.0.14"), false));
            Assert.IsFalse(whitelist.IsIPinList(IPAddress.Parse("192.165.0.14"), false));
            Assert.IsTrue(whitelist.IsIPinList(IPAddress.Parse("95.168.9.15"),false));
            Assert.IsFalse(whitelist.IsIPinList(IPAddress.Parse("95.168.10.15"), false));
        }
    }
}