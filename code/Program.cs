using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number:");
            int num = Convert.ToInt32(Console.ReadLine());

            List<int> nums = new List<int>();
            for (int i = 0; i < num.ToString().Length; i++)
            {
                nums.Add(Convert.ToInt32(num.ToString().Substring(i, 1)));
            }

            List<string> list = new List<string>(); // get all combinations
            GetAllCombinations(list, nums);
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}

            for (int i = 0; i < list.Count; i++) // delete all numbers that start with zero or less than num
            {
                try
                {
                    if (list[i][0] == '0' || Convert.ToInt32(list[i]) <= num)
                    {
                        list.RemoveAt(i);
                        i--;
                    }
                }
                catch (Exception)
                {
                    break;
                }
            }

            int closest = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if ((closest == 0 && Convert.ToInt32(list[i]) > num) || (closest != 0 && Convert.ToInt32(list[i]) > num && Convert.ToInt32(list[i]) < closest))
                {
                    closest = Convert.ToInt32(list[i]);
                }
            }
            Console.WriteLine($"Output: {closest}");


            Console.ReadLine();

            void GetAllCombinations<T>(IList<string> array, IList< T> arr, string current = "")
            {
                if (arr.Count == 0) 
                {
                    array.Add(current);
                    return;
                }
                for (int i = 0; i < arr.Count; i++) 
                {
                    List<T> lst = new List<T>(arr);
                    lst.RemoveAt(i);
                    GetAllCombinations(array, lst, current + arr[i].ToString());
                }
            }
        }
    }
}
