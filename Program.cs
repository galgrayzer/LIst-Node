using System;

namespace IntMyList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>(1, 2, 3, 4, 5, 6, 7);
            Console.WriteLine(list);
        }
    }
}
