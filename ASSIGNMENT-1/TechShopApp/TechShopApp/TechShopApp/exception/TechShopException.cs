using System;

namespace TechShopApp.exception
{
    // Custom Exception for Database connection errors
    public class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException() : base("Error establishing database connection.")
        {
        }

        public DatabaseConnectionException(string message) : base(message)
        {
        }

        public DatabaseConnectionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    // Custom Exception for invalid customer details
    public class InvalidCustomerException : Exception
    {
        public InvalidCustomerException() : base("Invalid customer details provided.")
        {
        }

        public InvalidCustomerException(string message) : base(message)
        {
        }

        public InvalidCustomerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    // Custom Exception for invalid product details
    public class InvalidProductException : Exception
    {
        public InvalidProductException() : base("Invalid product details provided.")
        {
        }

        public InvalidProductException(string message) : base(message)
        {
        }

        public InvalidProductException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    // Custom Exception for order-related issues
    public class OrderProcessingException : Exception
    {
        public OrderProcessingException() : base("An error occurred while processing the order.")
        {
        }

        public OrderProcessingException(string message) : base(message)
        {
        }

        public OrderProcessingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    // Custom Exception for Payment processing issues
    public class PaymentProcessingException : Exception
    {
        public PaymentProcessingException() : base("Error occurred while processing the payment.")
        {
        }

        public PaymentProcessingException(string message) : base(message)
        {
        }

        public PaymentProcessingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    // Custom Exception for Inventory management errors
    public class InventoryException : Exception
    {
        public InventoryException() : base("An error occurred while managing inventory.")
        {
        }

        public InventoryException(string message) : base(message)
        {
        }

        public InventoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    // General Custom Exception for Unhandled errors
    public class GeneralApplicationException : Exception
    {
        public GeneralApplicationException() : base("An unexpected error occurred in the application.")
        {
        }

        public GeneralApplicationException(string message) : base(message)
        {
        }

        public GeneralApplicationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
