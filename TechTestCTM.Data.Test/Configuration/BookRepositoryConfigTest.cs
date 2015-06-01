using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTestCTM.Data.Configuration;

namespace TechTestCTM.Data.Test.Configuration
{
    [TestClass]
    public class BookRepositoryConfigTest
    {
        [TestMethod]
        public void When_config_section_and_config_is_present_config_can_be_loaded()
        {
            var config = BookRepositoryConfig.GetConfig();
            Assert.AreEqual(config.Books["1"].FilePath, "FilePath1");
            Assert.AreEqual(config.Books["2"].FilePath, "FilePath2");
            Assert.AreEqual(config.Books["3"].FilePath, "FilePath3");
            Assert.AreEqual(config.Books["4"].FilePath, "FilePath4");
        }
    }
}