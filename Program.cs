using System;

namespace IntNode
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> list = new Node<int>(1, 2, 3, 4, 5, 6, 7);
            Console.WriteLine(list.ToString());
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
