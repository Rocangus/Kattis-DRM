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
            var res = encryptor.Rotate("EWPG".ToCharArray());
            Assert.Equal("ZRKB".ToCharArray(), res);
        }

        [Fact]
        public void RotateCanMergeStrings()
        {
            var res = encryptor.Rotate("ZRKB".ToCharArray(), "BKSC".ToCharArray());
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
