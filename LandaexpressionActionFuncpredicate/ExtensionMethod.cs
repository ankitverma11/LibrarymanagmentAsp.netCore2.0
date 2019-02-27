using System;
using System.Collections.Generic;
using System.Text;

namespace LandaexpressionActionFuncpredicate
{
    class ExtensionMethod
    {
        //Extension Methods help you to add new method to the existing type without modifing  the orignal code , inheriting or aggregation.
        static void Main (string[] args)
        {
            mathparty math = new mathparty();
            math.Add(3,5);
            math.substact(5, 3);
        }
    }

   public class mathparty
    {
        public  int Add(int num1 , int num2)
        {
            return num1 + num2;
        }
    }
    /// <summary>
    /// Estension method
    /// </summary>
    public static class somemoremethod
    {
        public static int substact(this mathparty obj ,int num1,int num2)
        {
            return num1 - num2;
        }
    }
}
