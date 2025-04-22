using System;
using System.Text.RegularExpressions;

namespace TechShopApp.entity
{
    public class Customer
    {
        private int customerID;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string address;

        // Constructor
        public Customer()
        {

        }
        public Customer(int customerID, string firstName, string lastName, string email, string phone, string address)
        {
            this.CustomerID = customerID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
        }

        // Properties
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) Console.WriteLine("First name cannot be empty.");
                else firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) Console.WriteLine("Last name cannot be empty.");
                else lastName = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                var emailRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                if (emailRegex.IsMatch(value)) email = value;
                else Console.WriteLine("Invalid email format.");
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                if (value.Length == 10 && value.All(char.IsDigit)) phone = value;
                else Console.WriteLine("Invalid phone number. Phone number should be 10 digits.");
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) Console.WriteLine("Address cannot be empty.");
                else address = value;
            }
        }
    }
}
