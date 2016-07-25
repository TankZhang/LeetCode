using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/4sum/
namespace _184Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] nums = {-494,-474,-425,-424,-391,-371,-365,-351,-345,-304,-292,-289,-283,-256,-236,-236,-236,-226,-225,-223,-217,-185,-174,-163,-157,-148,-145,-130,-103,-84,-71,-67,-55,-16,-13,-11,1,19,28,28,43,48,49,53,78,79,91,99,115,122,132,154,176,180,185,185,206,207,272,274,316,321,327,327,346,380,386,391,400,404,424,432,440,463,465,466,475,486,492};
            int[] nums = { 0, 1, 5, 0, 1, 5, 5, -4 };
            //int[] nums = { 91277418, 66271374, 38763793, 4092006, 11415077, 60468277, 1122637, 72398035, -62267800, 22082642, 60359529, -16540633, 92671879, -64462734, -55855043, -40899846, 88007957, -57387813, -49552230, -96789394, 18318594, -3246760, -44346548, -21370279, 42493875, 25185969, 83216261, -70078020, -53687927, -76072023, -65863359, -61708176, -29175835, 85675811, -80575807, -92211746, 44755622, -23368379, 23619674, -749263, -40707953, -68966953, 72694581, -52328726, -78618474, 40958224, -2921736, -55902268, -74278762, 63342010, 29076029, 58781716, 56045007, -67966567, -79405127, -45778231, -47167435, 1586413, -58822903, -51277270, 87348634, -86955956, -47418266, 74884315, -36952674, -29067969, -98812826, -44893101, -22516153, -34522513, 34091871, -79583480, 47562301, 6154068, 87601405, -48859327, -2183204, 17736781, 31189878, -23814871, -35880166, 39204002, 93248899, -42067196, -49473145, -75235452, -61923200, 64824322, -88505198, 20903451, -80926102, 56089387, -58094433, 37743524, -71480010, -14975982, 19473982, 47085913, -90793462, -33520678, 70775566, -76347995, -16091435, 94700640, 17183454, 85735982, 90399615, -86251609, -68167910, -95327478, 90586275, -99524469, 16999817, 27815883, -88279865, 53092631, 75125438, 44270568, -23129316, -846252, -59608044, 90938699, 80923976, 3534451, 6218186, 41256179, -9165388, -11897463, 92423776, -38991231, -6082654, 92275443, 74040861, 77457712, -80549965, -42515693, 69918944, -95198414, 15677446, -52451179, -50111167, -23732840, 39520751, -90474508, -27860023, 65164540, 26582346, -20183515, 99018741, -2826130, -28461563, -24759460, -83828963, -1739800, 71207113, 26434787, 52931083, -33111208, 38314304, -29429107, -5567826, -5149750, 9582750, 85289753, 75490866, -93202942, -85974081, 7365682, -42953023, 21825824, 68329208, -87994788, 3460985, 18744871, -49724457, -12982362, -47800372, 39958829, -95981751, -71017359, -18397211, 27941418, -34699076, 74174334, 96928957, 44328607, 49293516, -39034828, 5945763, -47046163, 10986423, 63478877, 30677010, -21202664, -86235407, 3164123, 8956697, -9003909, -18929014, -73824245 };
            int target = 10;
            IList<IList<int>> l = FourSum2(nums, target);
            foreach (var list in l)
            {
                foreach (var i in list)
                {
                    Console.Write("{0}  ", i);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        //借鉴方法
        static IList<IList<int>> FourSum2(int[] nums, int target)
        {
            List<IList<int>> l = new List<IList<int>>();
            if (nums.Length < 4)
                return l;
            Array.Sort(nums);
            Go2(l, new List<int>(), nums, target, 4, 0, nums.Length - 1);
            return l;
        }

        /// <summary>
        /// 递归解决问题
        /// </summary>
        /// <param name="l">要返回的总的结果</param>
        /// <param name="lTemp">临时的列表</param>
        /// <param name="nums">待选的数字列表</param>
        /// <param name="target">需要得到结果，剩下的值的和</param>
        /// <param name="k">还要添加几个值</param>
        /// <param name="start">nums开始的值</param>
        /// <param name="end">nums结束的值</param>
        private static void Go2(List<IList<int>> l, List<int> lTemp, int[] nums, int target, int k, int start, int end)
        {

            if (k == 0 || start > end)
                return;
            //如果剩下1个值去确定
            if (k == 1)
            {
                for (int i = start; i <= end; i++)
                {
                    if (nums[i] == target)
                    {
                        lTemp.Add(nums[i]);
                        l.Add(new List<int>(lTemp));
                        return;
                    }
                }
            }
            else if (k == 2)
            {
                while (start < end)
                {
                    int sum = nums[start] + nums[end];
                    if ( sum== target)
                    {
                        lTemp.Add(nums[start]);
                        lTemp.Add(nums[end]);
                        l.Add(new List<int>(lTemp));
                        lTemp.RemoveAt(lTemp.Count - 1);
                        lTemp.RemoveAt(lTemp.Count - 1);
                        while (start < end && nums[start] == nums[start + 1])
                            start++;
                        start++;
                        while (start < end && nums[end] == nums[end - 1])
                            end--;
                        end--;
                    }
                    else if (sum < target)
                    {
                        while (start < end && nums[start] == nums[start + 1])
                            start++;
                        start++;
                    }
                    else if(sum > target)
                    {
                        while (start < end && nums[end] == nums[end - 1])
                            end--;
                        end--;
                    }
                }
                return;
            }

            //减小复杂度,剪枝
            if (k * nums[start] > target || k * nums[end] < target)
            { return; }

            for (int i = start; i <=end-k+1; i++)
            {
                if (i > start && nums[i] == nums[i - 1])
                    continue;
                if(k*nums[i]<=target)
                {
                    lTemp.Add(nums[i]);
                    Go2(l, lTemp, nums, target - nums[i], k - 1, i + 1, end);
                    lTemp.RemoveAt(lTemp.Count - 1);
                }
            }

        }


        //优化n次的自己的方法，总是超时，来自编程之美
        static IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> l = new List<IList<int>>();
            if (nums.Length < 4) return l;
            Array.Sort(nums);
            if (nums[nums.Length - 1] + nums[nums.Length - 2] + nums[nums.Length - 3] + nums[nums.Length - 4] < target || nums[0] + nums[1] + nums[2] + nums[3] > target)
                return l;
            List<int> temp = new List<int>();
            Go(l, temp, nums, target, 0);
            return l;
        }

        private static void Go(IList<IList<int>> l, List<int> temp, int[] nums, int target, int start)
        {
            if (target == 0 && temp.Count == 4)
            {
                //int sum = 0;
                //for (int i = 0; i < 4; i++)
                //{
                //    if (l.Count>0&&l[l.Count - 1][i] == temp[i])
                //        sum++;
                //}
                //if(sum!=4)
                l.Add(new List<int>(temp));
                return;
            }
            else
            {
                for (int i = start; i < nums.Length && temp.Count < 4; i++)
                {
                    if (i > start && nums[i - 1] == nums[i])
                        continue;
                    if (nums[i] > target && nums[i] > 0)
                        break;
                    temp.Add(nums[i]);
                    Go(l, temp, nums, target - nums[i], i + 1);
                    temp.RemoveAt(temp.Count - 1);
                }
            }
        }
    }
}
