using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datastructure
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] mubers = { 0, 0, 1, 2, 2 };
            Queue test = new Queue();

            //int result= test.RemoveDuplicates(mubers);
            // Console.WriteLine(result);
            // Array.Sort(mubers);
            // int[] number2 = mubers;

            // List<int> i = new List<int>();
            // i.Add(1);
            // i.Add(2);
            // i.Add(3);
            // i.Add(4);
            // i.Add(5);
            // Array a = i.ToArray();
            // LinkedList<int> j = new LinkedList<int>();
            // LinkedListNode<int> k = new LinkedListNode<int>(3);
            // j.AddAfter(k, 3);

            //int a= test.FirstUniqChar("loveleetcode");
            //bool status = test.IsAnagram("rat", "rat");
            //bool palindrom = test.sentencePalindrome("naman");
            //int value = test.MyAtoi(" -42");
            // string countandsay = test.CountAndSay(6);
            //string[] prefixstr = { "flower", "flow", "flight" };
            //string result1 = test.LongestCommonPrefix(prefixstr);
            //Console.WriteLine(result1);

            int[] i = { -10, -3, 0, 5, 8 };
            tree t = new tree();
            TreeNode n = t.CreateBST(i);
            Random ra = new Random();
            TreeNode node = new TreeNode(1);
            node = new TreeNode(2);
            node = new TreeNode(3);
            node = new TreeNode(4);
            node = new TreeNode(5);
            node = new TreeNode(6);
            int count = t.CountNodes(node);

            int[] matrix1 = new int[] { 0, 1, 1,0 };
            int[] matrix2 = new int[] { 0, 1, 1, 0 };
            int[] matrix3 = new int[] { 0,0,0,1 };
            int[][] M = new int[][] { matrix1, matrix2, matrix3 };
            t.LongestLine(M);
            
            int[] list1 = new int[] { 1, 1 };
            int[] list2 = new int[] { 1, 3 };
            int[] list3 = new int[] { 3, 1 };
            int[] list4 = new int[] { 3, 3 };
            int[] list5 = new int[] { 4, 1 };
            int[] list6 = new int[] { 4, 3 };
            int[][] points = new int[][] { list1, list2, list3, list4, list5,list6 };                           
            //int result= t.MinAreaRect(points);
            //Console.WriteLine(result);
            Hashtable charcount = new Hashtable();
            int a = charcount.Count;
            
            HashSet<int> qwe= new HashSet<int>();
            
            //test.Swap(9, 7);

            permutation per = new permutation();
            //per.GetHint("1123", "0111");
            // per.RepeatedSubstringPattern("abcabcabcabc");
            bool re= per.BackspaceCompare("a#c", "b");
            Console.WriteLine(re);
            //per.PrintPer(2);
            string s1 = "01:44";
            string s2 = "19:34";
            DateTime time = new DateTime();
            time = Convert.ToDateTime(time);
            string s = "2[abc]3[cd]ef";
             string[] str2=s.Split('[', ']');
            string[] str= s.Split('[');
            string[] str1 = s.Split(']');
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("fsdfsd");
            sb1.ToString();
            //TimeSpan ts = TimeSpan.Parse(s1);
            //TimeSpan ts1 = TimeSpan.Parse(s2);
            //int hours = ts.Hours;
            //int minute = ts.Minutes;
            //if (ts1 > ts)
            //    Console.WriteLine(ts1);
            //else
            //    Console.WriteLine(ts);


            HashTable dshs = new HashTable();
            string[] val = { "a","b","ba","bca","bda","bdca" };
            int value =dshs.LongestStrChain(val);

            int[] meeting1 = new int[] { 0, 30 };
            int[] meeting2 = new int[] { 5, 10 };
            int[] meeting3 = new int[] { 15, 20 };
            int[][] meeting = { meeting1, meeting2, meeting3 };
            int roomcount = dshs.MinMeetingRooms(meeting);
            //Console.WriteLine(roomcount);

            string decodestring =dshs.DecodeString("3[a]2[bc]");

            //Console.WriteLine(decodestring);

            google gg = new google();
            string[] emails = { "test.email+alex@leetcode.com", "test.email@leetcode.com" } ;
            gg.NumUniqueEmails(emails);
            string license=gg.LicenseKeyFormatting("5F3Z-2e-9-w", 4);
            Console.WriteLine(license);

            permutation per1 = new permutation();
            int[] arr = { 1, 2, 3 };
            per1.NextPermutation(arr);
            string n1 = "123";
            per1.Multiply("123", "123");
            int q = Convert.ToInt32(n1);



            int[] matrix11 = new int[] {1,2,3 };
            int[] matrix12 = new int[] {4,5,6 };
            int[] matrix13 = new int[] { 7,8,9 };
            int[][] matrix = { matrix11, matrix12, matrix13 };
            gg.Rotate(matrix);

            int[] jump = new int[] { 3, 2, 1, 0, 4 };
            gg.CanJump(jump);
            int[] plusone = { 0 };
            gg.PlusOne(plusone);
            gg.LengthOfLongestSubstringTwoDistinct("eceba");

            int[] peak = { 0, 2, 1, 0 };
            gg.PeakIndexInMountainArray(peak);
            gg.LongestPalindrome("babad");

            int[] coin = new int[] { 1, 2, 5 };
            gg.CoinChange(coin, 11);


        }
    }
}
