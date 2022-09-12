using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Repositories
{
    public interface IRepository
    {
        List<Person> Persons { get; set; }
       List<Product> Products { get; set; }
        List<Order> Orders { get; set; }
    }
}
