using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BITSharp;

namespace BITTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class FullRequests
    {
        private BitClient _client;

        public FullRequests()
        {
            //
            // TODO: Add constructor logic here
            //
            _client = new BitClient("BitSharp Testing");
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestEvents_Search_geoip()
        {
            var returnList = _client.Events_Search(null, "use_geoip", 50, null, 1, 10);

            Assert.IsNotNull(returnList);
            //TODO - Add more checks
        }
        [TestMethod]
        public void TestEvents_Search_artist()
        {
            var returnList = _client.Events_Search(new List<string> { "eagles of death metal" }, null, 50, null, 1, 10);

            Assert.IsNotNull(returnList);
            //TODO - Add more checks
        }

        [TestMethod]
        public void TestEvents_Daily()
        {
            var returnList = _client.Events_Daily();

            Assert.IsNotNull(returnList);
            Assert.IsTrue(returnList.Count > 0);
            //TODO - Add more checks
        }

        [TestMethod]
        public void TestArtists_Get()
        {
            var returnArtist = _client.Artists_Get("de11b037-d880-40e0-8901-0397c768c457");

            Assert.IsNotNull(returnArtist);
            Assert.AreEqual("de11b037-d880-40e0-8901-0397c768c457", returnArtist.MusicBrainzID);
            //TODO - Add more checks
        }

        [TestMethod]
        public void TestEvents_OnSaleSoon()
        {
            var returnList = _client.Events_OnSaleSoon(null, null);

            Assert.IsNotNull(returnList);
            //TODO - Add more checks
        }
    }
}
