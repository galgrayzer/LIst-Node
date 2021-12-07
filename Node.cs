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

        public Node(T v, Node<T> n)
        {
            this.value = v;
            this.next = n;
        }
        public Node(T v)
        {
            this.value = v;
            this.next = null;
        }
        public Node()
        {
            this.value = default(T);
            this.next = null;
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
    }
}