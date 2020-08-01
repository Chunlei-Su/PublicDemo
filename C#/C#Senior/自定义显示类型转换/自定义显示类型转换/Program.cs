using System;

namespace 自定义显示类型转换
{
    class Program
    {
        static void Main(string[] args)
        {
            //正常情况下
            //stone是不能转换为monkey
            Stone stone=new Stone();
            stone.Age = 5000;
            Monkey monkey = (Monkey)stone;
            Console.WriteLine(monkey.Age);
            monkey.Age = 20;
            stone = (Stone)monkey;
            Console.WriteLine(stone.Age);

            Console.ReadKey();
        }
    }

    class Stone
    {
        public int Age;

        /// <summary>
        /// 自定义类型转换(隐式转换)
        /// </summary>
        /// <param name="stone"></param>
        public static implicit operator Monkey(Stone stone)
        {
            Monkey monkey=new Monkey();
            monkey.Age = stone.Age / 500;
            return monkey;
        }
    }

    class Monkey
    {
        public int Age;

        /// <summary>
        /// 自定义类型转换(显式转换)
        /// </summary>
        /// <param name="stone"></param>
        public static explicit operator Stone(Monkey monkey)
        {
            Stone stone = new Stone();
            stone.Age = monkey.Age * 500;
            return stone;
        }
    }
}
