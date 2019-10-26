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

        // Divides a string of an even count of uppercase letters only in half.
        public void Divide(string str)
        {
            firstHalf = str.Substring(0, str.Length / 2);
            lastHalf = str.Substring(str.Length / 2);
        }

        // Overload for Rotate of one string
        public string Rotate(string oldStr)
        {
            var rotateString = GetRotateValue(oldStr);
            return Rotate(oldStr, rotateString);
        }

        // Processes a string to generate a string of a series of identical values to rotate a string with by itself for the Rotate step of DRM encryption
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

        // Performs actual rotation of a string by the characters in the second argument. Will double for Merge due to implementation.
        public string Rotate(string str, string rotateString)
        {
            char[] characters = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                int charValue = Convert.ToInt32(str[i]);
                charValue += Convert.ToInt32(rotateString[i]) - 65;
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
