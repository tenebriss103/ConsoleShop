using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Models
{
    public class Person
    {
        public int PersonId { get; set; }
     
        public Position Position { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool Online { get; set; } = false;

        private static int NextId { get; set; } = 0;
        public Person()
        {
            PersonId = NextId +1;
           NextId++;
        }
        public override string ToString()
        {
            return $"Id: {PersonId}, Name: {Name}, Surname: {Surname},  Phone: { Phone}, Email: {Email} ";
        }

    }
}
