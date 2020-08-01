using System;
using System.Collections.Generic;
using System.Reflection;

namespace Variance_变体_
{
    class Program
    {
        static void Main(string[] args)
        {
            //多态性
            Animals cat = new Cat();
            Animals dog = new Dog();



            //协变
            //IAnimals<Animals> animals;
            //animals=new AnimalsAdmin<Dog>();
            //animals.InvokeSay();
            //animals= new AnimalsAdmin<Cat>();
            //animals.InvokeSay();

            //抗变
            AnimalsAdmin<Cat> cAdmin = new AnimalsAdmin<Cat>();
            Type type = cAdmin.GetAnimalType(new AnimalsType<Animals>());
            Console.WriteLine(type);
        }
    }

    class Animals
    {
        public virtual void Say() { }
    }

    class Cat : Animals
    {
        public override void Say()
        {
            Console.WriteLine("小猫喵喵叫");
        }
    }

    class Dog : Animals
    {
        public override void Say()
        {

            Console.WriteLine("小狗汪汪汪");
        }
    }

    interface IAnimals<out T> where T :Animals, new()
    {
        void InvokeSay();
    }
    interface IAnimalsType<in T> where T :Animals
    {
        Type GetAnimalType();
    }

    class AnimalsType<T>:IAnimalsType<T> where T : Animals
    {
        public Type GetAnimalType()
        {
            return typeof(T);
        }
    }

    class AnimalsAdmin<T> : IAnimals<T> where T : Animals,new()
    {
        
        //此处涉及到反射，不清楚反射的读者请留意后期文章，此处只需知道调用了传入类的Say()方法即可
        public void InvokeSay()
        {
            Type type = typeof(T);
            T t = new T();
            MethodInfo Say = type.GetMethod("Say");
            Say.Invoke(t, null);
        }

        public Type GetAnimalType(IAnimalsType<T> animals)
        {
            return animals.GetAnimalType();
        }
    }

}
