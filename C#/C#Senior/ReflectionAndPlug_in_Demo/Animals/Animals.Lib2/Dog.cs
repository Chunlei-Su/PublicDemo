using System;
using BabyStroller.SDK;

namespace Animals.Lib2
{
    public class Dog: IAnimals
    {
        public void Voice(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("Dog:Woof!");
            }
        }
    }
}
