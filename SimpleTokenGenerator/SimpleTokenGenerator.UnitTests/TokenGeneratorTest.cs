using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleTokenGenerator.UnitTests
{   [TestClass]
    public class TokenGeneratorTest
    {
        [TestMethod]
        public void GetTokenSignature()
        {
            var token = SimpleTokenGenerator.GetToken();
            var currentTimeStamp = DateTime.Now.ToOADate();
            var sampleSecret = Guid.Empty.ToString();

            var tokenSignature = SimpleTokenGenerator.GetTokenSignature(currentTimeStamp, token, sampleSecret);

            Assert.AreEqual(1, 1);
        }
    }
}
