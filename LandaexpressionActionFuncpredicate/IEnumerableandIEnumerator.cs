using System;
using System.Collections.Generic;
using System.Text;

namespace LandaexpressionActionFuncpredicate
{
    // IEnumerable andI Enumerator help us to loop through collection
    // IEnumerable actually use iEnumerator but IEnumerable doent know the state  , it dosnt know which row is currently rating through
    class IEnumerableandIEnumerator
    {
        static void Main(string[] args)
        {
            List<int> years = new List<int>();
            years.Add(1990);
            years.Add(1991);
            years.Add(1992);
            years.Add(1993);
            List<int> oyears = new List<int>();
            years.Add(1994);
            years.Add(1995);
            years.AddRange(oyears);

            IEnumerable<int> ienum = (IEnumerable<int>)years;
            foreach (int i in ienum)
            {
                Console.WriteLine(i);
            }

            IEnumerator<int> enumerator = years.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.ToString());
            }
            Console.ReadLine();
        }

    }
}
