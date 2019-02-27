using System;
using System.Collections.Generic;
using System.Text;

namespace LandaexpressionActionFuncpredicate
{
    class Generics
    {
        // Generic and generic collection are two different thing
        // Generic is the concept and generic collection is the implementation of that concept
        // Generic provide better code reusablity , type safty , usecan utilize that class in better manner
        // Generic help you to decuple your logic from the data type
        // generic collection helps us to create flexible , strong type collection

        static void Main(string[] args)
        {
            compare<int> compare = new compare<int>();
            compare.check(40, 20);  // logic and datatype are tightly copled means i cant chech compare between two string , decimals
            compare<string> obj = new compare<string>();
            obj.check("A", "B");
        }
    }

    class compare<T>  // T = any data type
    {
        public bool check (T num1, T num2)
        {
            if (num1.Equals(num2))
            {
                return true;
            }
            else
                return false;
        }
    }
}
