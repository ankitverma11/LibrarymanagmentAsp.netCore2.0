using System;
using System.Collections.Generic;
using System.Text;

namespace LandaexpressionActionFuncpredicate
{
    // abstraction is nothing but showing only what is necessary 
    // encapsulation say hide complexity 
    class AbstractionvsEncapsulation
    {
        
        //what step-  hat we need  abstration ,, absration is the  thought process while encapsulation is the implementation
        //step -2 How add work , hw validation work
        //step- 3 made those complecated method as private  // enacpsulate
        public class customer
        {
            public string CustomerCode = "";
            public string CustomerName = "";
            public void Add()
            {
                validate();
                createdbobject();
             // databse 
            }
            private bool validate ()
            {
                return true;
            }
            private bool createdbobject()
            {
                //db connection , sql 
                return true;
            }
        }
    }
}
