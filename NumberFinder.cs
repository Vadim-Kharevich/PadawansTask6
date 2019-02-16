using System;

namespace PadawansTask6
{
    public static class NumberFinder
    {
        public static int? NextBiggerThan(int number)
        {
            if (number < 0 || number == int.MinValue)
            {
                throw new ArgumentException();
            }
            if (number == int.MaxValue)
            {
                return null;
            }
            string s1 = number.ToString();
            int col = 1;
            for (int i = 1; i <= s1.Length; i++)
            {
                col *= i;
            }
            int[] perestanovki = new int[col];
            int[] mas = new int[s1.Length];
            for (int i = 0; i < s1.Length; i++)
            {
                mas[i] = Convert.ToInt32(s1[i]) - 48;
            }

            for (int k = 0; k < col; k++)
            {
                int I = 0;
                int J = 0;
                for (int i = 0; i < mas.Length - 1; i++)
                {
                    if (mas[i] < mas[i + 1])
                    {
                        I = i;
                        J = i + 1;
                    }
                }
                int[,] mas_dop = new int[mas.Length, 2];
                for (int i = I + 1; i < mas.Length; i++)
                {
                    if (mas[i] > mas[I])
                    {
                        mas_dop[i, 0] = mas[i];
                        mas_dop[i, 1] = i;
                    }
                }
                int min = 10;
                for (int i = 0; i < mas.Length; i++)
                {
                    if (mas_dop[i, 0] < min && mas_dop[i, 1] != 0)
                    {
                        min = mas_dop[i, 0];
                        J = mas_dop[i, 1];
                    }
                }
                int a = mas[I];
                mas[I] = mas[J];
                mas[J] = a;
                int[] mas1 = new int[0];
                int j = 0;
                for (int i = J; i < mas.Length; i++)
                {
                    Array.Resize(ref mas1, mas1.Length + 1);
                    mas1[j] = mas[i];
                    j++;
                }
                Array.Reverse(mas1);
                j = 0;
                for (int i = J; i < mas.Length; i++)
                {
                    mas[i] = mas1[j];
                    j++;
                }
                string str = "";
                for (int i = 0; i < mas.Length; i++)
                {
                    str += mas[i].ToString();
                }
                perestanovki[k] = Convert.ToInt32(str);
            }
            Array.Sort(perestanovki);
            for (int i = 0; i < perestanovki.Length; i++)
            {
                if (perestanovki[i] > number)
                {
                    return perestanovki[i];
                }
            }
            return null;
        }
    }
}
