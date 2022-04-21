using System;

namespace MathildeString
{
    public class String : IEquatable<String>
    {
        private char[] charArray;

        public String(char[] value)
        {
            charArray = value;
        }

        public String(string value)
        {
            charArray = value.ToCharArray();
        }

        public override string ToString()
        {
            return new string(charArray);
        }

        public int IndexOf(char value)
        {
            return ToString().IndexOf(value);
        }

        public String Insert(int index, String s1)
        {
            char[] inserted = new char[s1.Length + charArray.Length];
            char[] firstPart = new ArraySegment<char>(charArray, 0, index).ToArray();
            char[] secondPart = s1.charArray;
            char[] thirdPart = new ArraySegment<char>(charArray, index, charArray.Length - firstPart.Length).ToArray();
            firstPart.CopyTo(inserted, 0);
            secondPart.CopyTo(inserted, index);
            thirdPart.CopyTo(inserted, index + secondPart.Length);
            return new String(inserted);
        }

        public static String Concat(String s1, String s2)
        {
            char[] concatenated = new char[s1.Length + s2.Length];
            s1.charArray.CopyTo(concatenated, 0);
            s2.charArray.CopyTo(concatenated, s1.Length);
            return new String(concatenated);
        }

        public bool Equals(String other)
        {
            if (this.Length == other.Length)
            {
                if (this.Length == 0 && other.Length == 0)
                {
                    return true;
                }
                for (int i = 0; i < this.Length; i++)
                {
                    if (this.charArray[i] != other.charArray[i])
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;    
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || obj.GetType() != typeof(string))
                return false;

            return this.Equals(new String(obj as string));
        }


        public char this[int index] => charArray[index];
        public int Length => charArray.Length;
    }
}

