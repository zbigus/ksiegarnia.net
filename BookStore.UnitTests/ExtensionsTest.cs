using BookStore.Entities.Helpers;
using BookStore.Entities.Models;
using BookStore.Logic.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStore.UnitTests
{
    [TestClass]
    public class ExtensionsTest
    {
        [Resx(ResxAttExampleName)]
        public class ResxAttExample
        {
            public const string ResxAttExampleName = "Resx example";
        }

        [TestMethod]
        public void EnumAttExTest()
        {
            var resxAtt = OrderStatus.Canceled.GetAttribute<ResxAttribute>();
            Assert.IsNotNull(resxAtt);
            Assert.IsTrue(!string.IsNullOrEmpty(resxAtt.Name));
        }

        [TestMethod]
        public void ClassAttExTest()
        {
            var resxExample = new ResxAttExample();
            var resxAtt = resxExample.GetAttribute<ResxAttExample, ResxAttribute>();
            Assert.IsNotNull(resxAtt);
            Assert.IsTrue(!string.IsNullOrEmpty(resxAtt.Name));
            Assert.AreEqual(resxAtt.Name, ResxAttExample.ResxAttExampleName);
        }
    }
}
