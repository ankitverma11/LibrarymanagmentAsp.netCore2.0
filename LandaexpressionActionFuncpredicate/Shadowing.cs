using System;
using System.Collections.Generic;
using System.Text;

namespace LandaexpressionActionFuncpredicate
{
    // in shadowing parent class element is completely replaced by the child class 
    class Shadowing
    {
        static void Main (string[] args)
        {
            AbstractionvsEncapsulation.customer obj = new AbstractionvsEncapsulation.customer();
            obj.CustomerCode = "sa01";
            obj.CustomerName = "shiv";
            obj.validate();
            obj.createdbobject();
            obj.Add();

            class1 obj1 = new class1();
            class2 obj2 = new class2();
            // i is variable
            obj1.i = 123;
            // i has been converter to method
            obj2.i();
            // so old client happly use invoice as int as sales class
            sales sales = new sales();
            // new cleint use second version
            salesVersion2 salesVersion = new salesVersion2();
            salesVersion.invoicenumber = "a23";
        }
    }

    public class class1
    {
        public int i = 0;
    }

    public class class2 : class1
    {
        public void i ()
        {

        }
    }

    // whats the use of shadowing

    public class sales
    {
        public int invoicenumber { get; set; }  // sales class used in lot of places  .. assume new requrent that invoice number accept alphanumeric number so u cant change this property  
                                               // option is overwritting but it only change implementation it does not change the datatype  
    }

    public class salesVersion2 : sales
    {
        public new object invoicenumber { get; set; }
    }

}
