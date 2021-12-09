using System.Collections.Generic;

namespace IntNode
{
    class Node<T>
    {
        public T value { get; set; }
        public Node<T> next { get; set; }
        public int Length
        {
            get
            {
                int count = 0;
                var tempList = this;
                while (tempList != null)
                {
                    ++count;
                }
                return count;
            }
        }
        public Node()
        {
            this.value = default(T);
            this.next = null;
        }
        public Node(params T[] items)
        {
            this.value = default(T);
            this.next = null;
            foreach (var item in items)
            {
                this.Append(item);
            }
        }
        public bool HasNext()
        {
            if (this.next == null) { return false; }
            return true;
        }
        public T this[int index]
        {
            get
            {
                Node<T> temp = this;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.next;
                }
                return temp.value;
            }
            set
            {
                Node<T> temp = this;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.next;
                }
                temp.value = value;
            }
        }
        public void Append(T item)
        {
            if (EqualityComparer<T>.Default.Equals(value, default(T))) { this.value = item; }
            else
            {
                Node<T> temp, first;
                first = temp = this;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = new Node<T>(item);
                this.value = first.value;
                this.next = first.next;
            }
        }
        public override string ToString()
        {
            string output = "{ ";
            var temp = this;
            while (temp.HasNext())
            {
                output += temp.value + ", ";
                temp = temp.next;
            }
            output += temp.value + " }";
            return output;
        }
        public static Node<T> operator +(Node<T> left, Node<T> right)
        {
            var temp = left;
            var first = temp;
            while (temp.HasNext())
            {
                temp = temp.next;
            }
            while (right != null)
            {
                temp.Append(right.value);
                temp = temp.next;
                right = right.next;
            }
            return first;
        }
    }
}