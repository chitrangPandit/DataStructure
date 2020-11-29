using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Datastructure
{
    class permutation
    {
        public void PrintPer(int count)
        {
            char[] per = new char[count * 3];
            List<string> list = new List<string>();
             CalculateCount(list, count, count, 0, per);
            for (int i=0; i< list.Count; i++)
            {
                Console.WriteLine(list[i].ToString());
            }
        }

        public  void CalculateCount (List<string> list,int LeftPar, int RightPar,int index, char[] str)
        {
            if (LeftPar < 0 || RightPar < LeftPar)
                return ;
            if (LeftPar == 0 && RightPar == 0)
            {
                string a = new string(str);
                list.Add(a);
            }
            else
            {
                str[index] = '(';
                CalculateCount(list, LeftPar - 1, RightPar, index + 1, str);
                str[index] = ')';
                CalculateCount(list, LeftPar, RightPar - 1, index + 1, str);
            }

            

        }

        public string GetHint(string secret, string guess)
        {
            if (secret.Length == 0 || guess.Length == 0)
                return null;
            char[] s = secret.ToCharArray();
            char[] g = guess.ToCharArray();
            int[] si = new int[10];
            int[] gi = new int[10];
            int a = 0;
            int b = 0;
            string result = null;
            for (int i = 0; i < g.Length; i++) //0111
            {                
                    if ( g[i] == s[i])
                        a++;
                    else
                    {
                        si[s[i] - '0']++;
                        gi[g[i] - '0']++;
                    }
                
            }
                for (int k = 0; k < si.Length; k++)
                {
                    b += Math.Min(si[k], gi[k]);
                }
                result = a.ToString() + 'A' + b.ToString() + 'B';
            return result;
        }

        public bool RepeatedSubstringPattern(string s)
        {

            if (s.Length == null)
                return false;
            int mid = s.Length / 2;
            int len = s.Length;
            string part1 = s;
            string part2 = s.Substring(mid, len-1);
            if (part1 == part2)
                return true;
            else
                return false;

        }


        public string DecodeString(string s)
        {

            int length = s.Length;
            StringBuilder sb = new StringBuilder();            
            string[] str = s.Split('[', ']');
            string number1 = "123456789";
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (number1.Contains(str[i]))
                {
                    int num = Convert.ToInt32(str[i]);
                    for (int k = 0; k < num; k++)
                    {
                        sb = sb.Append(str[i + 1]);
                    }
                    i++;
                }
                else
                    sb = sb.Append(str[i]);

            }
            return sb.ToString();
        }

        public bool BackspaceCompare(string S, string T)
        {

            Stack<char> str = new Stack<char>();
            Stack<char> st1 = new Stack<char>();

            for (int i=0; i< S.Length; i++)
            {
                if (S[i] != '#')
                    str.Push(S[i]);
                else
                {
                    if (str.Count > 0)
                        str.Pop();
                }
            }
            for (int j=0; j<T.Length; j++)
            {
                if (T[j] != '#')
                    st1.Push(T[j]);
                else
                {
                    if (st1.Count > 0)
                        st1.Pop();
                }

            }
            char[] string1 = str.ToArray();
            string s1 = new string(string1);
            char[] string2 = st1.ToArray();
            string s2 = new string(string2);
            

            if (s1.ToString() == s2.ToString())
                return true;
            else
                return false;

            

        }

        public void NextPermutation(int[] num)
        {
            int i, j;
            for (i = num.Length - 1; i > 0; i--)
                if (num[i] > num[i - 1])
                {
                    int newNum;
                    for (j = i; j < num.Length; j++)
                        if (num[j] <= num[i - 1])
                            break;
                    newNum = num[j - 1];
                    num[j - 1] = num[i - 1];
                    num[i - 1] = newNum;
                    Array.Sort(num, i, num.Length - i);
                    break;
                }
            if (i == 0) Array.Sort(num);
        }


        public string Multiply(string num1, string num2)
        {
            int n1 = num1.Length;
            int n2 = num2.Length;
            int[] products = new int[n1 + n2];

            for (int i = n1 - 1; i >= 0; i--)
            {
                for (int j = n2 - 1; j >= 0; j--)
                {
                    int p1 = i + j;
                    int p2 = p1 + 1;
                    int sum = (num1[i] - '0') * (num2[j] - '0') + products[p2];

                    products[p1] += sum / 10;
                    products[p2] = sum % 10;
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (int num in products)
            {
                if (!(sb.Length == 0 && num == 0))
                {
                    sb.Append(num);
                }
            }

            return sb.Length == 0 ? "0" : sb.ToString();
        }

    }
}
