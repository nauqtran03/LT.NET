using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFind.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void BuiltOptionsTest()
        {
            string[] args= ["/v", "/c", "/n"];
            var options = Program.BuiltOptions(args);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.FindDontContains);
            Assert.IsTrue(options.CountMode);
            Assert.IsTrue(options.IsCaseSensitive);
        }
    }
}