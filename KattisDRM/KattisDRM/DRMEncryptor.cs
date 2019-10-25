using System;
using System.Collections.Generic;
using System.Text;

namespace KattisDRM
{

    class DRMEncryptor
    {
        string firstHalf = "";
        string lastHalf = "";
        public DRMEncryptor()
        {
        }

        public string Encrypt(string str)
        {
            Divide(str);
        }

        private void Divide(string str)
        {
            firstHalf = str.Substring(0, str.Length / 2);
            lastHalf = str.Substring(str.Length / 2);
        }

        private string Rotate(string oldStr)
        {
            int rotValue = 0;
            char[] characters = new char[oldStr.Length];
            foreach(char c in oldStr)
            {
                rotValue += Convert.ToInt32(c) - 65;
            }
            for (int i = 0; i < oldStr.Length; i++)
            {
                int charValue = Convert.ToInt32(oldStr[i]);
                charValue += rotValue;
                while(charValue > 90)
                {
                    charValue -= 26;
                }
                characters[i] = (char)charValue;
            }
            return characters.ToString();
        }
    }
}
