using System;
using BabyStroller.SDK;


namespace Animals.Lib
{
    /// <summary>
    /// 小动物类库插件
    /// </summary>
    public class Cat : IAnimals
    {
        public void Voice(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("Cat:Meow!");
            }
        }
    }


    [Unfinished]
    public class Pig : IAnimals
    {
        public void Voice(int times)
        {
            //to be continued....
        }
    }
}

