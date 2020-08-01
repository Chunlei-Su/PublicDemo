using System;
using System.Collections.Generic;
using System.Text;
using BabyStroller.SDK;

namespace Animals.Lib2
{
    public class Cow: IAnimals
    {
        public void Voice(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("Cow:Moo!");
            }
        }
    }
}
