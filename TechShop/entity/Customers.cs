using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.entity
{
    internal class Customers
    {
        // Attributes
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        // Constructor
        public Customers(int customerID, string firstName, string lastName, string email, string phone, string address)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
        }

        // Methods 
        //public int CalculateTotalOrders();

        //public void GetCustomerDetails();

        //public void UpdateCustomerInfo();
    }
}
