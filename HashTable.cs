using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure
{
    class HashTable
    {
        int maxAll = 0;
        public int LongestStrChain(string[] words)
        {
            Dictionary<int, List<string>> map = new Dictionary<int, List<string>>();

            foreach (var w in words)
            {
                if (!map.ContainsKey(w.Length))
                    map[w.Length] = new List<string>();

                map[w.Length].Add(w);

            }

            for (int i = 0; i < words.Length; i++)
            {
                DFS(map, words[i], 1);
            }

            return maxAll;
        }

        public void DFS(Dictionary<int, List<string>> map, string word, int max)
        {
            maxAll = Math.Max(maxAll, max);

            List<string> temp = FindWords(word, map);
            if (temp.Count == 0)
                return;

            foreach (var t in temp)
                DFS(map, t, max + 1);
        }

        public List<string> FindWords(string word, Dictionary<int, List<string>> map)
        {
            if (!map.ContainsKey(word.Length + 1))
                return new List<string>();

            List<string> output = new List<string>();
            List<string> temp = map[word.Length + 1];
            foreach (var t in temp)
            {
                int[] chars = new int[26];
                foreach (var c in t)
                    chars[c - 'a']++;

                int count = t.Length;
                foreach (var c in word)
                {
                    if (chars[c - 'a'] != 0)
                    {
                        count--;
                        chars[c - 'a']--;
                    }
                }

                if (count == 1)
                    output.Add(t);
            }

            return output;
        }

        public List<KeyValuePair<int,int>> sdafsda = new List<KeyValuePair<int,int>>();
        /*
         * use of dictionary
         */
        public bool HasGroupsSizeX(int[] deck)
        {
            bool status = false;
            int len = deck.Length;
            if ((len % 2 == 0))
            {
                Dictionary<int, int> count = new Dictionary<int, int>();
                Array.Sort(deck);

                for (int i = 0; i < len; i++)
                {
                    if (!count.ContainsKey(deck[i]))
                    {
                        count.Add(deck[i], 1);
                    }
                    else
                    {
                        count[deck[i]]++;
                    }
                }

                int sum = count[deck[0]];
                foreach (int v in count.Values)
                {
                    if (v % sum != 0)
                    {
                        status = false;
                        break;
                    }
                    else
                        status = true;
                }


            }
            return status;



        }



        public int MinMeetingRooms(int[][] intervals)
        {
            int[] start = new int[intervals.Length];
            int[] end = new int[intervals.Length];

            for (int i = 0; i < intervals.Length; i++)
            {
                start[i] = intervals[i][0];
            }

            for (int i = 0; i < intervals.Length; i++)
            {
                end[i] = intervals[i][1];
            }
            Array.Sort(start);
            Array.Sort(end);

            int s = 0;
            int e = 0;
            int rooms = 0;

            while (s < intervals.Length)
            {
                if (start[s] >= end[e])
                {
                    rooms = rooms - 1;
                    e = e + 1;
                }
                rooms = rooms + 1;
                s = s + 1;


            }
            return rooms;
        }


        public string DecodeString(string s)
        {

            Stack<Char> countchar = new Stack<Char>();
            string basestring = String.Empty;
            string temp = String.Empty;
            string result = String.Empty;
            string tail = String.Empty;
            int repeatcount = 0;
            int digit = 0;
            foreach (char c in s)
            {
                if (c != ']')
                {
                    countchar.Push(c);
                }
                else
                {
                    while (countchar.Count != 0 && countchar.Peek() != '[')
                    {
                        basestring = countchar.Pop().ToString() + basestring;
                    }
                    countchar.Pop();
                    while (countchar.Count != 0 && countchar.Peek() <= 57)
                    {
                        repeatcount = ((int)countchar.Pop() - 48) * (int)Math.Pow(10, digit++) + repeatcount;
                    }

                    for (int i = 0; i < repeatcount; i++)
                    {
                        temp = basestring + temp;
                    }
                    if (countchar.Count == 0)
                        result += temp;
                    else
                        foreach (char c1 in temp)
                            countchar.Push(c1);
                    basestring = string.Empty;
                    temp = string.Empty;
                    repeatcount = 0;
                    digit = 0;
                }
            }

            while (countchar.Count != 0)
                tail = countchar.Pop().ToString() + tail;

            return result + tail;
        }

    }
}
