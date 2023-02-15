using DotNetDesignPatternDemos.Creational.Builder;
using System;
using static System.Console;


namespace ArchitecturePrincipal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //static int Area(Rectangle r) => r.Width * r.Height;
            //Rectangle rc = new Rectangle(2, 3);
            //WriteLine($"{rc} has area {Area(rc)}");
            //// should be able to substitute a base type for a subtype
            ///*Square*/
            //Rectangle sq = new Squares();
            //sq.Width = 4;
            //WriteLine($"{sq} has area {Area(sq)}");
            //sq.GetArea();


            ////////DIP////////////////////////////////
            ///
            //var parent = new Person { Name = "John" };
            //var child1 = new Person { Name = "Chris" };
            //var child2 = new Person { Name = "Matt" };

            //// low-level module
            //var relationships = new Relationships();
            //relationships.AddParentAndChild(parent, child1);
            //relationships.AddParentAndChild(parent, child2);

            //new SOLIDDIP(relationships);

            ////////////////////// Creation Design pattern /////////////
            //Demo.STMain(args);


            //var  t =Child.GetObject();
            //Console.WriteLine( t.GetChild(""));

            string s1 = "abc";
            string s2 = "abc";
            s1 = "abc";
            if (s1.Equals(s2))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
            if (s1==s2)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }

            MultipleInterface o1 = new MultipleInterface();
            MultipleInterface o2 = new MultipleInterface();
            if (o1.Equals(o2))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }

        }
    }
}
