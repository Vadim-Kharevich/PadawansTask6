using System;

namespace PadawansTask6
{
    public static class NumberFinder
    {
        public static int? NextBiggerThan(int number)
        {
            string s1 = number.ToString();
            int[] mas1 = new int[s1.Length];
            for (int i = 0; i < s1.Length; i++)
            {
                mas1[i] = Convert.ToInt32(s1[i]) - 48;
            }
            Array.Sort(mas1);
            string max = "";
            for (int i = 0; i < s1.Length; i++)
            {
                max += "9";
            }
            for (int i = number + 1; i < Convert.ToInt32(max); i++)
            {
                string str = i.ToString();
                int[] mas2 = new int[str.Length];
                for (int j = 0; j < str.Length; j++)
                {
                    mas2[j] = Convert.ToInt32(str[j]) - 48;
                }
                Array.Sort(mas2);
                bool flag = true;
                for (int j = 0; j < str.Length; j++)
                {
                    if (mas1[j] != mas2[j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    return i;
            }
            return null;
        }
    }
}
