using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Datastructure
{
    class tree
    {

        
         
        public bool IsValidBST(TreeNode root)
        {
            return checkBSTValidWithRange(root, long.MinValue, long.MaxValue);
        }

        /// <summary>
        /// By giving range minimum and maximum, the tree is also forced to give 
        /// left child smaller than parent node, right child bigger than parent node
        /// </summary>
        /// <param name="node"></param>
        /// <param name="rangeMin"></param>
        /// <param name="rangeMax"></param>
        /// <returns></returns>
        private static bool checkBSTValidWithRange(TreeNode node, long rangeMin, long rangeMax)
        {
            if (node == null)
                return true;

            var current = node.val;                                                                                                                         

            if (current <= rangeMin || current >= rangeMax)
                return false;

            var checkLeftSubTree = checkBSTValidWithRange(node.left, rangeMin, current);
            if (!checkLeftSubTree)                                                                                                                                                                                                                            
                return false;

            //var checkRightSubtree = checkBSTValidWithRange(node.right, current, rangeMax);
            //if (!checkRightSubtree)
            //    return false;

            return true;
        }


        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            return InOrderCheck(root, root);

        }

        private bool InOrderCheck(TreeNode root, TreeNode root1)
        {
            if (root == null && root1 == null)
                return true;
            if (root == null || root1 == null)
                return false;

            if ((root.val == root1.val) && InOrderCheck(root.left, root1.right) && InOrderCheck(root.right, root1.left))
                return true;
            else
                return false;
        }

        public TreeNode CreateBST(int[] i)
        {
            
            return CreateBST( i, 0,i.Length-1);
                    

        }
        public TreeNode CreateBST(int[] i, int start,int end)
        {
            if (end < start)
            {
                return null;
            }
                

            int mid = (start + end) / 2;
            TreeNode n = new TreeNode(i[mid]);

            n.left = CreateBST(i, 0, mid - 1);
            n.right = CreateBST(i, mid + 1, end);
            return n;

        }

        public TreeNode SortedArrayToBST(int[] nums)
        {
            return Partition(nums, 0, nums.Length - 1);
        }

        public TreeNode Partition(int[] nums, int left, int right)
        {
            if (right < left) return null;
            int mid = (left + right) / 2;
            TreeNode root = new TreeNode(nums[mid]);
            root.left = Partition(nums, left, mid - 1);
            root.right = Partition(nums, mid + 1, right);

            return root;
        }

        //public IList<List<TreeNode>> ReturnBST(TreeNode root)
        //{
        //    IList<List<TreeNode>> result = new List<TreeNode>();
        //    List<TreeNode> current = new List<TreeNode>();
        //    if (root != null)
        //    {
        //        current.Add(root);
        //    }

        //    while (current.Count > 0)
        //    {
        //        List<TreeNode> parents = new List<TreeNode>();
        //        result.Add(current);
        //        parents = current;
        //        current = new List<TreeNode>();
        //        foreach (TreeNode parent in parents)
        //        {
        //            if (parent.left != null)
        //                current.Add(parent.left);
        //            if (parent.right != null)
        //                current.Add(parent.right);
        //        }

        //    }
        //    return result;

        //}

        public bool IsBalanced(TreeNode root)
        {
            if (CheckHeight(root) != int.MinValue)
                return true;
            else
                return false;
        }

        public int CheckHeight(TreeNode root)
        {
            if (root == null)
                return -1;
            int leftHeight = CheckHeight(root.left);
            int rightHeight = CheckHeight(root.right);
            int diff = leftHeight - rightHeight;
            if (Math.Abs(diff) > 1)
                return int.MinValue;
            else
                return Math.Max(leftHeight, rightHeight) + 1;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
        }


        public bool ContainTree(TreeNode t1, TreeNode t2)
        {
            StringBuilder string1 = new StringBuilder();
            StringBuilder string2 = new StringBuilder();
            subtree(t1, string1);
            subtree(t2, string2);
            if (string1.ToString().Contains(string2.ToString()))
            {
                return true;
            }
            else
                return false;
        }
        public StringBuilder subtree(TreeNode node, StringBuilder s)
        {
            if (node == null)
                s.Append('X');
            s.Append(node.val);
            subtree(node.left, s);
            subtree(node.right, s);
            return s;
        }

        public int CountPathWithSum(TreeNode node, int targetsum)
        {
            if (node == null)
                return 0;
            int totalcount = 0;
            totalcount = CountFromNode(node, 0, targetsum);
            totalcount += CountFromNode(node.left, 0, targetsum);
            totalcount += CountFromNode(node.right, 0, targetsum);

            return totalcount;
        }
        public int CountFromNode(TreeNode node, int currentSum, int targetsum)
        {
            int path = 0;
            if (node == null)
                return 0;
            currentSum = currentSum + node.val;
            if (currentSum == targetsum)
                path++;
            //if (currentSum > targetsum)
            //{
            //    currentSum = 0;
            //    path = 0;
            //    break;
            //}
            //else { 
            //}
            path += CountFromNode(node.left, currentSum, targetsum);
            path += CountFromNode(node.right, currentSum, targetsum);
            return path;
        }

        public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {

            IList<TreeNode> result= new List<TreeNode>();
            if (root == null)
                return null;
            List<int> deleteNode = new List<int>();
            for (int i=0; i<to_delete.Length; i++)
            {
                deleteNode.Add(to_delete[i]);
            }

            return result = del(root, deleteNode);
        }

        public IList<TreeNode> del(TreeNode root, List<int> deleteNode)
        {
            IList<TreeNode> li = new List<TreeNode>();
            //deleteNode.Contains(root.val);
            int l = deleteNode.Count;
            int i = 0;
            while (i < l)
            {
                if (root.val == deleteNode[i])
                {
                    deleteNode.Remove(3);
                    root = null;
                    li.Add(root.left);                   
                    li.Add(root.right);
                }
                else
                {

                }
            }
            del(root.left, deleteNode);
            del(root.right, deleteNode);
            return li;
        }

        public bool ShouldPrintMessage(int timestamp, string message)
        {

            Dictionary<string, int> hs = new Dictionary<string, int>();
            bool print = false;
            if (hs.ContainsKey(message))
            {
                int i = 0;
               
                hs.TryGetValue(message,out i);
                if( i - 10 > 0)
                {
                    hs.Remove(message);
                    hs.Add(message, timestamp);
                    print = true;
                    return print;
                }
                else
                {
                    hs.Remove(message);
                    hs.Add(message, timestamp);
                    return print = false;
                }

            }
            else
                hs.Add(message, timestamp);

            return print;
        }

        public int MinAreaRect(int[][] points)
        {
            var map = new Dictionary<int, HashSet<int>>();
            foreach (int[] p in points)
            {
                if (!map.ContainsKey(p[0]))
                {
                    map.Add(p[0], new HashSet<int>());
                }
                map[p[0]].Add(p[1]);
            }
            var n = points.Length;
            int res = int.MaxValue;
            for (var i = 0; i < n; ++i)
            {
                for (var j = i + 1; j < n; ++j)
                {
                    int p1x = points[i][0], // 1
                        p1y = points[i][1], // 1
                        p2x = points[j][0], // 3
                        p2y = points[j][1]; // 3

                    if (p1x != p2x && p1y != p2y)
                    {
                        if (map[p1x].Contains(p2y) && map[p2x].Contains(p1y))
                        {
                            res = Math.Min(res,
                                           Math.Abs(p2x - p1x) * Math.Abs(p2y - p1y));
                        }
                    }
                }
            }
            return res == int.MaxValue ? 0 : res;
        }


        public int CountNodes(TreeNode root)
        {
            if (root == null)
                return 0;
            int counter = 0;
            return counter = nodes(root, counter);

        }

        public int nodes(TreeNode root, int counter)
        {
            if (root == null)
                return counter;
            if (root != null)
            {
                counter = counter + 1;
                nodes(root.left, counter);
                nodes(root.right, counter);
            }

            if (root.left != null)
            {
                nodes(root.left, counter);
                nodes(root.right, counter);
            }

            return counter;
        }


        public int LongestLine(int[][] M)
        {
            int result = 0;
            if (M.Length == 0)
                return 0;
            for (int i = 0; i<M.Length; i++)
            {
                int count = 0;
                for (int j=0; j<M[0].Length;j++)
                {
                    if (M[i][j] == 1)
                        count++;
                }
                result = Math.Max(result, count);
            }

            for (int i=0; i<M[0].Length; i++)
            {
                int count = 0;
                for (int j=0;j<M.Length; j++)
                {
                    if (M[j][i] == 1)
                        count++;
                }
                result = Math.Max(result, count);
            }

            for (int i = 0; i < M[0].Length || i < M.Length; i++)
            {
                int count = 0;
                for (int x = 0, y = i; x < M.Length && y < M[0].Length; x++, y++)
                {
                    if (M[x][y] == 1)
                    {
                        count++;
                        result = Math.Max(result, count);
                    }
                    else count = 0;
                }
            }

            for (int i = 0; i < M[0].Length || i < M.Length; i++)
            {
                int count = 0;
                for (int x = i, y = 0; x < M.Length && y < M[0].Length; x++, y++)
                {
                    if (M[x][y] == 1)
                    {
                        count++;
                        result = Math.Max(result, count);
                    }
                    else count = 0;
                }
            }

            for (int i = 0; i < M[0].Length || i < M.Length; i++)
            {
                int count = 0;
                for (int x = 0, y = M[0].Length - i - 1; x < M.Length && y >= 0; x++, y--)
                {
                    if (M[x][y] == 1)
                    {
                        count++;
                        result = Math.Max(result, count);
                    }
                    else count = 0;
                }
            }
            for (int i = 0; i < M[0].Length || i < M.Length; i++)
            {
                int count = 0;
                for (int x = i, y = M[0].Length - 1; x < M.Length && y >= 0; x++, y--)
                {
                    // System.out.println(x+" "+y);
                    if (M[x][y] == 1)
                    {
                        count++;
                        result = Math.Max(result, count);
                    }
                    else count = 0;
                }
            }
            return result;
        }



        public IList<int> RightSideView(TreeNode root)
        {
            IList<int> g = new List<int>();
            g = test(root);
            return g;
        }

        public IList<int> test(TreeNode root)
        {
            IList<int> a = new List<int>();

            a.Add(root.val);
            if (root.left != null)
            {
                test(root.left);
            }
            if (root.right != null)
            {
                test(root.right);
            }

           
            return a;
        }

        
        
    }
}
