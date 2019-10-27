using System;
using System.Collections.Generic;
using System.Text;

namespace KattisDRM
{

    public class DRMEncryptor
    {
        public char[] firstHalf;
        public char[] lastHalf;
        int valFirst = 0;
        int valSecond = 0;
        private static string letters = "abcdefghijklmnopqrstuvwxyz".ToUpper();
        public DRMEncryptor()
        {
        }

        // Main encryption method. Makes necessary calls.
        public string Encrypt(string str)
        {
            Divide(str);
            firstHalf = Rotate(firstHalf);
            lastHalf = Rotate(lastHalf);
            return Rotate(firstHalf, lastHalf);
        }


        // Divides a string of an even count of uppercase letters only in half.
        public void Divide(string str)
        {
            firstHalf = str.Substring(0, str.Length / 2).ToCharArray();
            lastHalf = str.Substring(str.Length / 2).ToCharArray();
        }

        // Overload for Rotate of one string
        public char[] Rotate(char[] oldStr)
        {
            var val = 0;
            for (var i = 0; i < oldStr.Length; i++)
            {
                val += letters.IndexOf(oldStr[i]);
            }
            for (var i = 0; i < oldStr.Length; i++)
            {
                oldStr[i] = (char)((Convert.ToInt32(oldStr[i]) - 'A' + val) % 26 + 'A');
            }
            return oldStr;
        }

        // Performs actual rotation of a string by the characters in the second argument. Will double for Merge due to implementation.
        public string Rotate(char[] str, char[] rotateString)
        {
            char[] characters = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                int charValue = Convert.ToInt32(str[i]) - 'A';
                charValue += letters.IndexOf(rotateString[i]);
                characters[i] = (char)(charValue % 26 + 'A');
            }
            return new string(characters);
        }
    }
}
