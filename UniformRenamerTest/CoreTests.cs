using NUnit.Framework;
using UniformRenamer;
using UniformRenamer.Core;

namespace UniformRenamerTests
{
    [TestFixture]
    class CoreTests
    {
        [Test]
        public void GetExtensionTest()
        {
            FileName n = new FileName(@"sandbox\fixtures\test.zip");
            Assert.AreEqual(".zip", n.GetExtension());
        }
        [Test]
        public void GetDoubleExtension()
        {
            FileName n = new FileName(@"sandbox\fixtures\test.jpg.zip");
            Assert.AreEqual(".zip", n.GetExtension());
        }
        [Test]
        public void GetFolderWithNoExtension()
        {
            FileName n = new FileName(@"sandbox\fixtures\folder.vm1");
            Assert.AreEqual("", n.GetExtension());
        }
        [Test]
        public void GetFileInFolder()
        {
            FileName n = new FileName(@"sandbox\fixtures\folder.vm1\test.zip");
            Assert.AreEqual(".zip", n.GetExtension());
        }
    }
}
