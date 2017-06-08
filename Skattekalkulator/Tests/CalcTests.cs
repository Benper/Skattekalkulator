using NUnit.Framework;
using Skattekalkulator.Buisness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skattekalkulator.Tests
{
    [TestFixture]
    public class CalcTests
    {
        private Calculator cal = new Calculator();

        [Test]
        public void YoungerThe17()
        {
            decimal ret = cal.GetTax(16, 60000);
            Assert.AreEqual(1337.5, ret);
        }

        [Test]
        public void OlderThe16()
        {
            decimal ret = cal.GetTax(25, 60000);
            Assert.AreEqual(1337.5, ret);
        }

        [Test]
        public void OlderThe69()
        {
            decimal ret = cal.GetTax(90, 100000);
            Assert.AreEqual(5100, ret);
        }

        [Test]
        public void Between17And69()
        {
            decimal ret = cal.GetTax(25, 100000);
            Assert.AreEqual(8200, ret);
        }

        [Test]
        public void AtTheMinimumLimitBetween17And69()
        {
            decimal ret = cal.GetTax(25, 54650);
            Assert.AreEqual(0, ret);
        }

    }
}
