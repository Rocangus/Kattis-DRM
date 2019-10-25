using System;
using Xunit;
using KattisDRM;

namespace KattisDRMTest
{
    public class UnitTest1
    {
        [Fact]
        public void RotateRotatesCorrectly()
        {
            DRMEncryptor encryptor = new DRMEncryptor();
            var res = encryptor.Rotate("EWPG");
            Assert.Equal("ZRKB", res);
        }

        [Fact]
        public void DivideDividesCorrectly()
        {
            DRMEncryptor encryptor = new DRMEncryptor();
            encryptor.Divide("EWPGAJRB");
            Assert.Equal("EWPG", encryptor.firstHalf);
            Assert.Equal("AJRB", encryptor.lastHalf);
        } 
    }
}
