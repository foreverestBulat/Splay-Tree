using System.Diagnostics;

namespace Splay_Tree
{
    public class Program
    {
        public static void Main()
        {
            //CreateData();

            //WriteInFileTimeAdd();

            //WriteInFileTimeSearch();

            WriteInFileTimeRemove();


        }

        public static void CreateData() => WorkingWithDates.CreateData();

        public static int[] GetArray() => WorkingWithDates.ReadData();


        public static void WriteInFileTimeAdd()
        {
            var arr = GetArray();

            using (var writer = new StreamWriter("Result.txt"))
            {
                var SplayTree = new SplayTree<int>();

                for (int i = 0; i < arr.Length; i++)
                {
                    var st = new Stopwatch();
                    SplayTree.Iterations = 0;
                    st.Start();
                    SplayTree.Add(arr[i]);
                    st.Stop();


                    writer.WriteLine($"{i + 1}\t{st.ElapsedTicks}\t{SplayTree.Iterations}");
                }
            }
        }

        public static void WriteInFileTimeRemove()
        {
            var arr = GetArray();

            var SplayTree = new SplayTree<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                SplayTree.Add(arr[i]);
            }

            var rnd = new Random();

            var randoms = new int[1000];

            for (int i = 0; i < 1000; i++)
            {
                randoms[i] = rnd.Next(0, 10000);
            }

            var values = new int[1000];

            for (int i = 0; i < 1000; i++)
            {
                values[i] = arr[randoms[i]];
            }

            using (var writer = new StreamWriter("ResultRemove.txt"))
            {
                //var SplayTree = new SplayTree<int>();

                for (int i = 0; i < 1000; i++)
                {
                    var st = new Stopwatch();

                    SplayTree.Iterations = 0;
                    st.Start();
                    SplayTree.Remove(values[i]);
                    st.Stop();

                    writer.WriteLine($"{i + 1}\t{st.ElapsedTicks}\t{SplayTree.Iterations}");
                }
            }
        }

        public static void WriteInFileTimeSearch()
        {
            var arr = GetArray();

            var SplayTree = new SplayTree<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                SplayTree.Add(arr[i]);
            }

            var rnd = new Random();

            var randoms = new int[100];

            for (int i = 0; i < 100; i++)
            {
                randoms[i] = rnd.Next(0, 10000);
            }

            var values = new int[100];

            for (int i = 0; i < 100; i++)
            {
                values[i] = arr[randoms[i]];
            }


            using (var writer = new StreamWriter("ResultSearsh.txt"))
            {
                //var SplayTree = new SplayTree<int>();

                for (int i = 0; i < 100; i++)
                {
                    var st = new Stopwatch();

                    SplayTree.Iterations = 0;
                    st.Start();
                    var key = SplayTree.Search(values[i]);
                    st.Stop();
                    Console.WriteLine(key);

                    writer.WriteLine($"{i + 1}\t{st.ElapsedTicks}\t{SplayTree.Iterations}");
                }
            }
        }
    }
}








//using Splay_Tree;

//var a = new SplayTree<int>();

//a.Root = new SplayTree<int>.Node<int>(10);

//a.Root.Left = new SplayTree<int>.Node<int>(5);

//a.Root.Left.Left = new SplayTree<int>.Node<int>(2);

//a.Root.Left.Left.Left = new SplayTree<int>.Node<int>(0);

//a.Root.Left.Left.Left.Right = new SplayTree<int>.Node<int>(1);

//a.Root.Left.Right = new SplayTree<int>.Node<int>(7);

//a.Root.Right = new SplayTree<int>.Node<int>(20);

//a.Root.Right.Left = new SplayTree<int>.Node<int>(15);

//a.Root.Right.Right = new SplayTree<int>.Node<int>(30);

//a.Add(10);

//a.Add(20);

//a.RotateLeft(ref a.Root);

//a.Zig(a.Root, a.Root.Left.Left);

//Console.WriteLine(a.Root.Value);

//a.Root = a.ZigZag(a.Root, new SplayTree<int>.Node<int>(8));// .Root.Left.Left.Left.Right

//a.Root = a.RotateRight(a.Root);

//a.Add(10);
//a.Add(5);
//a.Add(2);
//a.Add(7);
//a.Add(20);
//a.Add(30);
//a.Add(15);




//Console.WriteLine(a.Search(10));

//Console.WriteLine(a.Root.Value);

//Console.WriteLine();