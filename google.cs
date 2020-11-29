using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure
{
    class google
    {
        public int NumUniqueEmails(string[] emails)
        {

            List<string> value1 = new List<string>();
            for (int i = 0; i < emails.Length; i++)
            {
                if (emails[i].Contains('@'))
                {
                    string[] splitemail = emails[i].Split('@');


                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < splitemail[0].Length; j++)
                    {
                        if (splitemail[0][j] != '.')
                        {
                            if (splitemail[0][j] != '+')
                                sb.Append(splitemail[0][j].ToString());
                        }
                            
                        if (splitemail[0][j] == '+')
                            j = splitemail[0].Length - 1;
                        
                        
                    }
                    sb.Append(splitemail[1].ToString());
                    if (!value1.Contains(sb.ToString()))
                        value1.Add(sb.ToString());


                }

            }

            return value1.Count;
        }

        public string LicenseKeyFormatting(string S, int K)
        {
            int Stringchar = S.Length;
            int dashcount = 0;
            string[] split = S.Split('-');
            string merge= String.Concat(split);
            char[] totalchars = new char[S.Length];
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] != '-')
                    totalchars[i] = S[i];
                else
                    dashcount++;
            }

            int onlychars =S.Length-dashcount;
            int sets = onlychars / K;
            int reminder = onlychars % 2;
            StringBuilder sb = new StringBuilder();
            String afterdash = new String(totalchars);
            if (reminder!=0)
            {
                for (int i = 0; i < reminder; i++)
                {
                    sb.Append(merge[i].ToString());                    
                }
                sb.Append('-');
            }
            int count = 0;
            for (int i = reminder; i < merge.Length; i++)
            {
                sb.Append(merge[i].ToString());
                count++;
                if (count==K && count <merge.Length)
                {
                    sb.Append('-');
                    count = 0;
                }    
                    
            }
            return sb.ToString();
        }

        public void Rotate(int[][] matrix)
        {
            //get matrix's size to make the code clear, you don't have to be like this
            int size = matrix.Length - 1;

            for (int i = 0; i < matrix.Length / 2; i++)
            {
                for (int j = i;  j < size - i; j++)
                {

                    //Circle the number to correct position
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[size - j][i];
                    matrix[size - j][i] = matrix[size - i][size - j];
                    matrix[size - i][size - j] = matrix[j][size - i];
                    matrix[j][size - i] = temp;

                }
            }
        }


        public bool CanJump(int[] nums)
        {

            int farthest = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                if (i > farthest)
                    return false;

                farthest = Math.Max(farthest, i + nums[i]);
                if (farthest > nums.Length)
                    return true;
            }

            return true;
        }

        public int[] PlusOne(int[] digits)
        {

            int len = digits.Length;
            for (int i = len - 1; i > 0; i--)
            {
                if (digits[i] == 9)
                    digits[i] = 0;
                else
                {
                    digits[i]++;
                    return digits;
                }
            }

            digits = new int[len + 1];
            digits[0] = 1;
            return digits;
        }

        public int LengthOfLongestSubstringTwoDistinct(string s)
        {

            int max = 0;
           
            for (int i = 0; i < s.Length - 1; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (stringLength(s, i, j))
                    {
                        max = Math.Max(max, j - i);
                    }
                }
            }
            return max;
        }

        public bool stringLength(string s, int i, int j)
        {          
            HashSet<char> hs = new HashSet<char>();
            for (int k = i; k < j; k++)
            {

                if (!hs.Contains(s[k]))
                {
                    if (hs.Count == 2)
                        return false;
                    else
                        hs.Add(s[k]);
                }

            }
            return true;
        }


        public int PeakIndexInMountainArray(int[] A)
        {
            int len = A.Length;
            int max = 0;
            if (len >= 3)
            {
                for (int i = 0; i < A.Length - 1; i++)
                {
                    for (int j = i + 1; j < A.Length-1; j++)
                    {
                        if (A[i] < A[j] && A[j]>A[j+1])
                        {
                            max = Math.Max(max, j);
                        }
                    }
                }
            }
            return max;
        }

        public string LongestPalindrome(string s)
        {

            string result = string.Empty;
            int max = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (palindrome(s, i, j))
                    {
                        int charcount = j - i;
                        max = Math.Max(max, j - i);
                        if (charcount>=max)
                            result = s.Substring(i, j - i);
                    }
                }
            }
            return result;
        }

        public bool palindrome(string s, int start, int end)
        {
            string substring = s.Substring(start, end - start);
            int left = 0, right = substring.Length - 1;
            while (left <= right)
            {
                if (substring[left] == substring[right])
                {
                    left++;
                    right--;
                }
                else
                {
                    return false;
                }

            }
            return true;
        }

        public int CoinChange(int[] coins, int amount)
        {
            var n = coins.Length;

            var dp = new int[amount + 1];

            for (int i = 1; i <= amount; i++)
            {
                dp[i] = int.MaxValue;
                for (int j = 0; j < n; j++)
                {
                    var pre = i - coins[j];
                    if (pre >= 0 && dp[pre] != int.MaxValue)
                    {
                        dp[i] = Math.Min(dp[i], dp[pre] + 1);
                    }
                }
            }

            if (dp[amount] == int.MaxValue)
            {
                return -1;
            }

            return dp[amount];

        }
    }
}
