using System.Collections.Generic;

namespace IntMyList
{
    class MyList<T>
    {
        public T value { get; set; }
        public MyList<T> next { get; set; }
        public int Length
        {
            get
            {
                int count = 0;
                var tempList = this;
                while (tempList != null)
                {
                    ++count;
                    tempList = tempList.next;
                }
                return count;
            }
        }
        public MyList()
        {
            this.value = default(T);
            this.next = null;
        }
        public MyList(params T[] items)
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
                MyList<T> temp = this;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.next;
                }
                return temp.value;
            }
            set
            {
                MyList<T> temp = this;
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
                MyList<T> temp, first;
                first = temp = this;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = new MyList<T>(item);
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
        public static MyList<T> operator +(MyList<T> left, MyList<T> right)
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
        public MyList<dynamic> ConvertToDynamic()
        {
            var list = this;
            MyList<dynamic> output = new MyList<dynamic>();
            for (int i = 0; i < list.Length; i++)
            {
                output.Append(list[i]);
            }
            return output;
        }
        public IEnumerator<T> GetEnumerator()
        {
            var temp = this;
            while (temp != null)
            {
                yield return temp.value;
                temp = temp.next;
            }
        }
        public int? FindIndex(T value)
        {
            var temp = this;
            for (int i = 0; i < this.Length; i++)
            {
                if (temp[i].Equals(value)) { return i; }
            }
            return null;
        }
    }
}