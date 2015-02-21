using System;
using System.Collections.Generic;
using System.Text;

namespace FlyoutProblem.Extensions
{
    public class Node<T>
    {
        public T Value { get; set; }
        public IList<Node<T>> Children { get; private set; }

        public int Level { get; set; }

        public Node<T> Parent { get; set; }

        public Node()
        {

        }

        public Node(T value, IEnumerable<Node<T>> children)
        {
            this.Value = value;
            this.Children = new List<Node<T>>(children);
        }
    }
}
