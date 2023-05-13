

namespace Splay_Tree
{
    public class SplayTree<T> where T : IComparable<T>
    {
        public Node<T> Root;
        public class Node<T> where T : IComparable<T>
        {
            public T Value;
            public Node<T> Left;
            public Node<T> Right;

            public Node(T value, Node<T> left = null, Node<T> right = null)
            {
                Value = value;
                Left = left;
                Right = right;
            }
        }

        public int Count { get; private set; }

        public SplayTree() { }


        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(value);
                return;
            }
            Root = Splay(value);
            if (value.CompareTo(Root.Value) == 0)
            {
                return;
            }
            Node<T> node = new Node<T>(value);
            if (value.CompareTo(Root.Value) < 0)
            {
                node.Left = Root.Left;
                node.Right = Root;
                Root.Left = null;
            }
            else
            {
                node.Right = Root.Right;
                node.Left = Root;
                Root.Right = null;
            }
            Root = node;
        }

        public Node<T> Splay(T value)
        {
            return ZigZag(Root, value);
        }

        // ancestor - предок
        // descendant - потомок
        public Node<T> Zig(Node<T> ancestor, T descendant)
        {
            if (ancestor.Left == null)
                return ancestor;
            if (ancestor.Left.Value.CompareTo(descendant) < 0)
                return ancestor;
            ancestor = RotateRight(ancestor);
            return Zig(ancestor, descendant);
        }

        public Node<T> ZigZig(Node<T> ancestor, T descendant)
        {
            if (ancestor.Right == null)
                return ancestor;
            if (ancestor.Right.Value.CompareTo(descendant) > 0)
                return ancestor;
            ancestor = RotateLeft(ancestor);
            return ZigZig(ancestor, descendant);
        }

        public Node<T> ZigZag(Node<T> ancestor, T descendant)
        {
            if (ancestor == null) return null;
            if (ancestor.Value.Equals(descendant)) return ancestor;
            
            if (descendant.CompareTo(ancestor.Value) < 0)
            {
                ancestor = Zig(ancestor, descendant);
                ancestor.Left = ZigZag(ancestor.Left, descendant);
                if (ancestor.Left == null) return ancestor;
            }
            else
            {
                ancestor = ZigZig(ancestor, descendant);
                ancestor.Right = ZigZag(ancestor.Right, descendant);
                if (ancestor.Right == null) return ancestor;
            }

            if (descendant.CompareTo(ancestor.Value) == 0) return ancestor;
            return descendant.CompareTo(ancestor.Value) < 0 ? 
                RotateRight(ancestor) : RotateLeft(ancestor);
        }

        public bool Search(T value)
        {
            Root = Splay(value);

            if (Root.Value.Equals(value))
            {
                return true;
            }
            return false;
        }

        public void Remove(T value)
        {
            if (Root == null)
            {
                return;
            }

            Root = Splay(value);
            if (value.CompareTo(Root.Value) != 0)
            {
                return;
            }

            if (Root.Left == null)
            {
                Root = Root.Right;
            }
            else
            {
                Node<T> node = Root.Right;
                Root = Root.Left;
                Root = Splay(value);
                Root.Right = node;
            }
        }

        public Node<T> RotateRight(Node<T> node)
        {
            Node<T> temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;
            return temp;
        }

        public Node<T> RotateLeft(Node<T> node)
        {
            Node<T> temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;
            return temp;
        }
    }
}