using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Datastructure
{
    class Queue
    {

        LinkedList<int> numbers = new LinkedList<int>();
        public LinkedList<int> Enqueue(LinkedList<int> link, int value)
        {
            int count = link.Count;
            if (link.Count == 0)
            {
                Console.WriteLine("list is empty");
            }

            link.AddLast(value);

            return link;
        }

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            int[] nums11, nums22;
            List<int> subset = new List<int>();

            if (nums1.Length == 0 || nums2.Length == 0)
            {
                return null;
            }
            Array.Sort(nums1);
            Array.Sort(nums2);
            if (nums1.Length <= nums2.Length)
            {
                nums11 = nums1;
                nums22 = nums2;
            }
            else
            {
                nums11 = nums2;
                nums22 = nums1;
            }

            for (int i = 0; i < nums11.Length; i++)
            {
                for (int j = 0; j < nums22.Length; j++)
                {
                    if (nums11[i] == nums22[j])
                    {
                        subset.Add(nums11[i]);
                        break;
                    }
                }

            }
            return subset.ToArray();

        }

        public int[] Intersect1(int[] nums1, int[] nums2)
        {
            HashSet<int> hs = new HashSet<int>();
           
            List<int> intersection = new List<int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                hs.Add(nums1[i]);
            }
            hs.ToArray<int>();
            for (int j = 0; j < nums2.Length; j++)
            {
                if (hs.Contains(nums2[j]))
                {
                    intersection.Add(nums2[j]);

                }
            }
            return intersection.ToArray();

        }

        //static void getCharCountArray(string str)
        //{
        //    for (int i = 0; i < str.Length; i++)
        //        count[str[i]]++;
        //}
        public int FirstUniqChar(string str)
        {
            int NO_OF_CHARS = 256;
            char[] count = new char[NO_OF_CHARS];
            for (int i1 = 0; i1 < str.Length; i1++)
                count[str[i1]]++;

            int index = -1, i;

            for (i = 0; i < str.Length; i++)
            {
                //if (count.Contains<char>(str[i]))
                if (count[str[i]] == 1)
                {
                    index = i;
                    break;
                }
            }

            return index;


        }

        public bool IsAnagram(string s, string t)
        {

            char[] string1 = s.ToCharArray();
            char[] string2 = t.ToCharArray();
            bool status = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (string1.Contains<char>(string2[i]))
                {
                    status = true;
                }
                else
                {
                    status = false;
                    break;
                }

            }

            return status;
        }

        public bool IsPalindrome(string s)
        {
            char[] str = s.ToCharArray();
            char[] reverse = new char[str.Length];

            bool status = false;
            int insert = 0;
            int len = str.Length - 1;
            while (insert < str.Length)
            {
                //reverse.Insert(insert, str[len].ToString());
                reverse.SetValue(str[len], insert);

                len--;
                insert++;
            }
            string rev = new string(reverse);
            if (string.Compare(rev, s) == 0)
            {
                return status = true;
            }
            else
                return status = false;

        }
        public bool sentencePalindrome(String str)
        {
            int l = 0;
            int h = str.Length - 1;

            // Lowercase string 
            str = str.ToLower();

            // Compares character until  
            // they are equal 
            while (l <= h)
            {

                char getAtl = str[l];
                char getAth = str[h];

                // If there is another symbol  
                // in left of sentence 
                if (!(getAtl >= 'a' &&
                      getAtl <= 'z'))
                    l++;

                // If there is another symbol   
                // in right of sentence 
                else if (!(getAth >= 'a' &&
                           getAth <= 'z'))
                    h--;

                // If characters are equal 
                else if (getAtl == getAth)
                {
                    l++;
                    h--;
                }

                // If characters are not equal then 
                // sentence is not palindrome 
                else
                    return false;
            }

            // Returns true if sentence  
            // is palindrome 
            return true;

        }


        public int MyAtoi(string str)
        {
            str = str.ToLower();
            int i = 0, value = 0;
            int sign = 1;
            int[] numerics = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            while (i < str.Length)
            {
                char s = str[i];
                if (s == ' ')
                    i++;
                else if (s == '+')
                {
                    sign = 1;
                    i++;
                }
                else if (s == '-')
                {
                    sign = -1;
                    i++;
                }

                else if (s >= 'a' && s <= 'z')
                    break;
                else
                {
                    int a = Convert.ToInt32(s.ToString());
                    if (numerics.Contains<int>(a))
                    {
                        value = value * 10 + a * sign;
                        i++;
                    }
                }
            }
            return value;
        }

        public int StrStr(string haystack, string needle)
        {
            int index = 0;
            if (haystack.Contains(needle))
            {
                char[] ht = haystack.ToCharArray();
                char[] nd = needle.ToCharArray();

                Array.Sort(ht);
                Array.Sort(nd);
                char[] stack = new char[256];

                for (int i = 0; i < nd.Length; i++)
                {
                    for (int j = 0; j < ht.Length; j++)
                    {
                        if (nd[i] == ht[j])
                        {
                            index = j;
                            return index;
                        }

                    }
                }

                return index;

            }
            return index;

        }


        public string CountAndSay(int n)
        {
            string s = "1";
            for (int i = 1; i < n; i++)
            {
                string tmp = "";
                int cnt = 1;
                for (int j = 1; j < s.Length; j++)
                {
                    if (s[j - 1] == s[j])
                        cnt += 1;
                    else
                    {
                        tmp += cnt.ToString() + s[j - 1];
                        cnt = 1;
                    }
                }
                s = tmp + cnt.ToString() + s[s.Length - 1];
            }
            return s;
        }

        public string LongestCommonPrefix(string[] strs)
        {

            if (strs.Length == 0) return "";

            var result = new StringBuilder();

            var firstWord = strs[0];

            for (int j = 0; j < firstWord.Length; j++)
            {
                for (int i = 1; i < strs.Length; i++)
                {
                    var curWord = strs[i];

                    if (j == curWord.Length) return result.ToString();

                    if (firstWord[j] != curWord[j])
                    {
                        return result.ToString();
                    }
                }
                result.Append(firstWord[j]);
            }

            return result.ToString();
        }


        public int ClimbStairs(int n)
        {

            if (n == 1)
                return 1;
            int[] arr = new int[n + 1];
            //Array = new int arr[n + 1];
            arr[1] = 1;
            arr[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }
            return arr[n];

        }

        public int Rob(int[] nums)
        {

            int sum = nums[0];
            for (int i = 0; i < nums.Length - 1; i = i + 2)
            {
                sum = sum + nums[i + 2];

            }

            return sum;

        }

        public void Swap(int a, int b)
        {
            int[] i = new int[2];
            a = a - b;
            b = a + b;
            a = b - a;
            i[0] = a;
            i[1] = b;
            SnapShow(i);


        }

        public void SnapShow(int[] i)
        {
            for (int j = 0; j < i.Length; j++)
            {
                Console.WriteLine(i[j]);
            }
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length == 0 && nums2.Length == 0)
                return 0;
            int[] num = new int[nums1.Length + nums2.Length];

            Array.Copy(nums1, num, nums1.Length);
            Array.Copy(nums2, 0, num, nums1.Length, nums2.Length);
            Array.Sort(num);
            int len = num.Length;
            int med = len % 2;
            int value = len / 2;
            if (med == 1)
            {
                return num[value];
            }
            else
                return ((num[value] + num[value + 1]) / 2);

        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {

            IList<IList<int>> lists = new List<IList<int>>();
            int[] arr = new int[256];
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        int sum = nums[i] + nums[j] + nums[k];
                        if (sum == 0)
                        {
                            if (lists.Contains(new List<int>() { nums[i], nums[j], nums[k] }))
                                lists.Add(new List<int>() { nums[i], nums[j], nums[k] });
                            if (nums[j] == nums[j + 1])
                                j++;
                            if (nums[i] == nums[i + 1])
                                i++;
                            if (nums[k] == nums[k - 1])
                                k++;
                        }

                    }
                }
            }
            return lists;


        }
    }
}
