using System;

namespace recursion
{
    class Program
    {
        public static void Main()
        {
            Make(2); // 1 0 0
            Make(3); // 2 1 0 0 1 0 0
            Make(4); //3 2 1 0 0 1 0 0 2 1 0 0 1 0 0
            Console.WriteLine();

            WriteReversed(new char[] { '1', '2', '3' }); //321
            WriteReversed(new char[] { '1', '2' }); //21
            WriteReversed(new char[] { '1' }); //1
            WriteReversed(new char[] { }); //
            WriteReversed(new char[] { '1', '1', '2', '2', '3', '3' }); //332211
            WriteReversed(new char[] { '1', '2', '3', '4' }); //4321
            WriteReversed(new char[] { 'a', 'b', 'c', 'd' }); //dcba
        }

        static void Make(int n)
        {
            for (int i = n - 1; i >= 0; i--)
            {
                Console.Write(i.ToString() + " ");
                Make(i);
            }
        }

        //программa, печатающей все элементы массива в обратном порядке (решить задачу, для всего массива, кроме первого элемента, а потом вывести первый элемент)
        public static void WriteReversed(char[] items, int startIndex = 0)
        {
            if (startIndex >= items.Length)
                return;
            WriteReversed(items, startIndex + 1); // Выводим (в обратном порядке) все элементы с индексом больше startIndex
            Console.Write(items[startIndex]); // а потом выводим сам элемент startIndex
        }

        //Вычисляет минимальный разряд десятичного числа x, в котором стоит 0
        static int F(int x)
        {
            if (x % 10 == 0) return 0;
            return 1 + F(x / 10);
        }

        //Вычисляет НОД x и y по алгоритму Евклида
        static int G(int x, int y)
        {
            if (y == 0)
                return x;
            else
                return G(y, x % y);
        }

        //вывесчти на экран все возможные подмножества от множества
        static int[] weights = new int[] { 2, 5, 6, 2, 4, 7 };
        static void Evaluate(bool[] subset)
        {
            var delta = 0;
            for (int i = 0; i < subset.Length; i++)
                if (subset[i]) delta += weights[i];
                else delta -= weights[i];
            foreach (var e in subset)
                Console.Write(e ? 1 : 0);
            Console.Write(" ");
            if (delta == 0)
                Console.Write("OK");
            Console.WriteLine();
        }
        static void MakeSubsets(bool[] subset, int position)
        {
            if (position == subset.Length)
            {
                Evaluate(subset);
                return;
            }
            subset[position] = false;
            MakeSubsets(subset, position + 1);
            subset[position] = true;
            MakeSubsets(subset, position + 1);
        }
        public static void Main2()
        {
            MakeSubsets(new bool[weights.Length], 0);
        }

        //программa перебирала все слова из букв a, b, c в лексикографическом порядке
        public static void Main1()
        {
            WriteAllWordsOfSize(1);
            WriteAllWordsOfSize(2);
            WriteAllWordsOfSize(0);
            WriteAllWordsOfSize(4);
        }
        static void WriteAllWordsOfSize(int size)
        {
            MakeSubsets(new char[size]);
        }
        static void MakeSubsets(char[] subset, int position = 0)
        {
            if (position == subset.Length)
            {
                Console.WriteLine(new string(subset));
                return;
            }
            for (char let = 'a'; let < 'd'; let++)
            {
                subset[position] = let;
                MakeSubsets(subset, position + 1);
            }
        }


    }
}
