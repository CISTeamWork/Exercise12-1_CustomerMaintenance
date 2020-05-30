using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMaintenance
{
    /******************************************************************************
     * George Gachoki, Jason Thomas, Tonya Martinez, Travis Johnson
     * 6-1-2020
     * "Murach Practice Assignments (Team)"
     * "Exercises 12-1 Create a Customer Maintenance application that uses classes"
     ******************************************************************************/
    public class Customer
    {
        public Customer() // constructor w/ default values
        {
        }

        public Customer(string firstName, string lastName, string email) // constructor w/ specified values
        {
            this.FirstName = firstName; // set first name to specified value
            this.LastName = lastName; // set last name to specified value
            this.Email = email; // set email to specified value
        }

        public string FirstName { get; set; } // auto-implemented property for first name
        
        public string LastName { get; set; } // auto-implemented property for last name

        public string Email { get; set; } // auto-implemented property for email

        public string GetDisplayText => FirstName + " " + LastName + ", " + Email; // expression-bodied method for displaying text
    }
}