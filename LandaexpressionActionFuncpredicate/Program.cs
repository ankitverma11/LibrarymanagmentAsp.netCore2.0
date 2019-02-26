using System;

namespace LandaexpressionActionFuncpredicate
{
    class Program
    {
        // landa expression , Action<> , function<> , predicate<> make ur delegate code more simple 
        // lamda expression help u to build in linq expression 
        // Annomoys method are also used to make delegate simple.

        public delegate double calareapointer(int r);

        //static calareapointer cpointer = calculatearea; 

        static void Main(string[] args)
        {
            // Annomoys method
                    //calareapointer cpointer = new calareapointer(delegate (int r)
                    //                                                              { return 3.14 * r * r; });

                    //double area = cpointer(20);

            //more sort and sweet by using lamda expression
                    //calareapointer cpointer = r => 3.12 * r * r;  // lamda expression is nothing but a simple inline code
                    //double area = cpointer(20);

            //more sort and sweet by using lamda expression + func
                    Func<Double, Double> cpointer = r => 3.12 * r * r;  // func is genric delegate . its a read made delegate.First double input and second is output
                    double area = cpointer(20);

            Action<string> myaction = y => Console.Write(y);
            myaction("Hello");

            Predicate<string> checkgreterthan5 = x => x.Length > 5;  // extension of func . it is just for check if trurn type is true or false
            checkgreterthan5("ankit1");

            // normal Delegate 
            //double area = cpointer.Invoke(20);
            //Console.WriteLine("Hello World!");
        }

        //Simple method
        //static double calculatearea(int r)
        //{
        //    return 3.14 * r * r;
        //}
    }
}
