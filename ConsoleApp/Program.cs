using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            B obj = new B();
            obj.Demo();

            //Final
            Console.ReadLine();
        }
    }

    public class A
    {
        public A()
        {
            Console.WriteLine("A:Contructor");
        }
        static A()
        {
            Console.WriteLine("A:Static Contructor");
        }
        public virtual void Demo()
        {
            Console.WriteLine("A:Demo()");
        }
        public void DemoA()
        {
            Console.WriteLine("A:DemoA()");
        }
    }
    public class B : A
    {
        public B()
        {
            Console.WriteLine("B:Contructor");
        }
        static B()
        {
            Console.WriteLine("B:Static Contructor");
        }
        
    }
    public class C : B
    {
        public C()
        {
            Console.WriteLine("C:Contructor");
        }
        static C()
        {
            Console.WriteLine("C:Static Contructor");
        }
        public override void Demo()
        {
            Console.WriteLine("C:Demo()");
        }
        public void DemoC()
        {
            Console.WriteLine("C:DemoC()");
        }
    }

}
