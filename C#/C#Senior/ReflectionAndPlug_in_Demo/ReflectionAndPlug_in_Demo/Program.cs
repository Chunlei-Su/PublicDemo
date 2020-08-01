using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;
using BabyStroller.SDK;

namespace ReflectionAndPlug_in_Demo
{
    /// <summary>
    /// 反射与插件式编程
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //组合生成插件程序集的文件夹路径
            var folder = Path.Combine(Environment.CurrentDirectory, "Animals");
            //加载文件
            var files = Directory.GetFiles(folder);
            //设置保存插件类型的集合
            var animalTypes = new List<Type>();
            //加载程序集中的文件
            foreach (var file in files)
            {
                //从一个文件中加载程序集
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file);
                //获取程序集中的类型，判断是否是动物类（have voice method?）
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    ////判断类型是否有一个类型包含Voice方法
                    //if (type.GetMethod("Voice")!=null)
                    //{
                    //    //将这个类添加到动物类中
                    //    animalTypes.Add(type);
                    //}

                    //有了SDK以后，就可以简化操作
                    if (type.GetInterfaces().Contains(typeof(IAnimals)))
                    {
                        //获取是否有未完成标签
                        var isunfinshed = type.GetCustomAttributes(false)
                            .Any(attr => attr.GetType() == typeof(UnfinishedAttribute));
                        if(isunfinshed) continue;
                        animalTypes.Add(type);
                    }


                }
            }

            //插件加载完毕后开始真正的执行程序使用插件
            while (true)
            {
                try
                {
                    for (int i = 0; i < animalTypes.Count; i++)
                    {
                        //输出选项列表
                        Console.WriteLine($"{i + 1}.{animalTypes[i].Name}");
                    }

                    Console.WriteLine("=============================================");

                    Console.WriteLine("Please choose animal：");
                    int index = int.Parse(Console.ReadLine());
                    //判断选择的索引是否是正确的
                    if (index > animalTypes.Count || index < 1)
                    {
                        Console.WriteLine("No such an animal. One more try,Please");
                        continue;
                    }

                    Console.WriteLine("Please input animal voice times：");
                    int times = int.Parse(Console.ReadLine());
                    //获取索引类型
                    var t = animalTypes[index - 1];
                    //获取voice方法
                    var m = t.GetMethod("Voice");
                    //创建该类型的实例对象
                    var o = Activator.CreateInstance(t);
                    //调用方法，参数一：执行该方法的对象，参数二：该方法的参数
                    //m.Invoke(o, new object[] { times });

                    //使用SDK以后
                    var a = o as IAnimals;
                    a.Voice(times);
                }
                catch
                {
                    Console.WriteLine("Input error please one more try...");
                    continue;
                }

            }

        }
    }
}
