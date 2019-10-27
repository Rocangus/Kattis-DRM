using System;

namespace KattisDRM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DRMEncryptor encryptor = new DRMEncryptor();
            var input = Console.ReadLine();
            var output = encryptor.Encrypt(input);
            Console.WriteLine(output);
        }
    }
}
