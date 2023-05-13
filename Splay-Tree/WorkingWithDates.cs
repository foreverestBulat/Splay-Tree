using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splay_Tree
{
    public static class WorkingWithDates
    {
        public static void CreateData()
        {
            using (var writer = new StreamWriter("Data.txt"))
            {
                var rnd = new Random();

                for (int i = 0; i < 10000; i++)
                {
                    writer.Write($"{rnd.Next(1, 100000)} ");
                }

                writer.Write(rnd.Next(1, 100000));
            }
        }

        public static int[] ReadData()
        {
            using (var reader = new StreamReader("Data.txt", true))
            {
                var data = reader.ReadToEnd().Split();

                var ints = Array.ConvertAll(data, s => int.Parse(s));

                return ints;
            }
        }
    }
}
