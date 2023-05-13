using Splay_Tree;

var a = new SplayTree<int>();

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

a.Add(10);
a.Add(5);
a.Add(2);
a.Add(7);
a.Add(20);
a.Add(30);
a.Add(15);




Console.WriteLine(a.Search(10));

Console.WriteLine(a.Root.Value);

Console.WriteLine();