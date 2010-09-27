using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UniformRenamer.Core
{
    static class Helper
    {
        public static int GetNthIndex(string s, char t, int n)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == t)
                {
                    count++;
                    if (count == n)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public static string CleanRuleText(string text)
        {
            StringBuilder sb = new StringBuilder(String.Empty);
            StringReader sr = new StringReader(text);
            string s = null;
            while ((s = sr.ReadLine()) != null)
            {
                s = s.SubstringBefore("//").Trim();
                if (s.Length == 0)
                {
                    continue;
                }
                sb.AppendLine(s);
            }
            return sb.ToString();
        }

        private static string SubstringBefore(this string source, string value)
        {
            //CompareInfo compareInfo = CultureInfo.InvariantCulture.CompareInfo;
            int index = source.IndexOf(value);//compareInfo.IndexOf(source, value, CompareOptions.Ordinal);
            if (index < 0)
            {
                //No such substring
                return source;
            }
            return source.Substring(0, index);
        }


    }
}
