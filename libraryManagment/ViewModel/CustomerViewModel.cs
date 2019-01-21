using LibraryManagment.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.ViewModel
{
    //View Model is a model class that can hold only those properties that is required for a view. It can also contains properties from more than one entities (tables) of the database. As the name suggests, this model is created specific to the View requirements.
    //ViewModel in the MVC design pattern is very similar to a "model". The major difference between "Model" and "ViewModel" is that we use a ViewModel only in rendering views.
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }

        public int BookCount { get; set; }
    }
}
