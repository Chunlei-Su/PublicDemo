using System;
using System.Collections.Generic;
using System.Text;
using BabyStroller.SDK;

namespace Animals.Lib
{
    public class Sheep:IAnimals
    {
        public void Voice(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("Sheep:Baa!");
            }
        }
    }
}
