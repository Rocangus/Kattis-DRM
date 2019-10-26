using System;
using Xunit;
using KattisDRM;

namespace KattisDRMTest
{
    public class UnitTest1
    {
        DRMEncryptor encryptor = new DRMEncryptor();
        [Fact]
        public void RotateRotatesCorrectly()
        {
            var res = encryptor.Rotate("EWPG");
            Assert.Equal("ZRKB", res);
        }

        [Fact]
        public void RotateCanMergeStrings()
        {
            var res = encryptor.Rotate("ZRKB", "BKSC");
            Assert.Equal("ABCD", res);
        }

        [Fact]
        public void DivideDividesCorrectly()
        {
            encryptor.Divide("EWPGAJRB");
            Assert.Equal("EWPG", encryptor.firstHalf);
            Assert.Equal("AJRB", encryptor.lastHalf);
        } 

        [Fact]
        public void EncryptProducesCorrectResult()
        {
            var result = encryptor.Encrypt("EWPGAJRB");
            Assert.Equal("ABCD", result);
        }
    }
}
