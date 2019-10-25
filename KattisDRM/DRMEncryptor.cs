using System;
using System.Collections.Generic;
using System.Text;

namespace KattisDRM
{

    public class DRMEncryptor
    {
        public string firstHalf = "";
        public string lastHalf = "";
        public DRMEncryptor()
        {
        }

        public string Encrypt(string str)
        {
            Divide(str);
            Rotate(str);
            Merge();
            return str;
        }

        private void Merge()
        {
            
        }

        public void Divide(string str)
        {
            firstHalf = str.Substring(0, str.Length / 2);
            lastHalf = str.Substring(str.Length / 2);
        }

        public string Rotate(string oldStr)
        {
            var rotateString = GetRotateValue(oldStr);
            return Rotate(oldStr, rotateString);
        }

        private static string GetRotateValue(string oldStr)
        {
            int rotValue = 0;
            foreach (char c in oldStr)
            {
                rotValue += Convert.ToInt32(c) - 65;
            }
            char[] rotateBase = new char[oldStr.Length];
            for (var i = 0; i < oldStr.Length; i++)
            {
                rotateBase[i] = (char)(rotValue + 65);
            }
            return new string(rotateBase);
        }

        public string Rotate(string str, string rotateString)
        {
            char[] characters = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                int charValue = Convert.ToInt32(str[i]);
                charValue += Convert.ToInt32(str[i]) - 65;
                while(charValue > 90)
                {
                    charValue -= 26;
                }
                characters[i] = (char)charValue;
            }
            return new string(characters);
        }
    }
}
