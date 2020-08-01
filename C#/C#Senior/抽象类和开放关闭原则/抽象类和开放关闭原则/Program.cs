using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 抽象类和开放关闭原则
{
    //为做基类而生的抽象类和开放关闭原则
    //开闭原则说的是不要轻易修改已经写好的稳定的类。那些不稳定的容易被修改的应该放到抽象类中让子类去实现他们
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Car();
            vehicle.Run();
            vehicle.Stop();
        }
    }

    #region 开发架构示例

    interface IVehicle
    {
        void Stop();
        void Fill();
        void Run();
    }

    abstract class Vehicle : IVehicle
    {
        public void Stop()
        {
            Console.WriteLine("Stopped!");
        }

        public void Fill()
        {
            Console.WriteLine("Pay and Fill");
        }

        public abstract void Run();
    }

    class Car : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Car is running...");
        }
    }

    class Truck : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Truck is running...");
        }
    }

    class RaceCar : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("RaceCar is running");
        }
    }

    #endregion

}

#region 定义一个抽象类
abstract class Student
{
    abstract public void Study();
}


#endregion