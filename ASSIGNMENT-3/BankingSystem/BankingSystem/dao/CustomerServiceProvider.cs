using System;
using Microsoft.Data.SqlClient;
using BankingSystem.Exceptions;
using BankingSystem.util;
using BankingSystem.entity;

namespace BankingSystem.dao
{
    public class CustomerServiceProvider : ICustomerServiceProvider
    {
        public decimal GetBalance(int accountId)
        {
            using (SqlConnection conn = DBUtil.GetConnection())
            {
                conn.Open();
                string query = "SELECT Balance FROM Accounts WHERE Account_id = @account_id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@account_id", accountId);

                object result = cmd.ExecuteScalar();
                if (result != null)
                    return Convert.ToDecimal(result);
                else
                    throw new InvalidAccountException("Account ID not found.");
            }
        }

        public decimal Deposit(int accountId, decimal amount)
        {
            decimal currentBalance = GetBalance(accountId);
            decimal newBalance = currentBalance + amount;

            using (SqlConnection conn = DBUtil.GetConnection())
            {
                conn.Open();
                string update = "UPDATE Accounts SET Balance = @balance WHERE Account_id = @account_id";
                SqlCommand cmd = new SqlCommand(update, conn);
                cmd.Parameters.AddWithValue("@balance", newBalance);
                cmd.Parameters.AddWithValue("@account_id", accountId);
                cmd.ExecuteNonQuery();
            }

            return newBalance;
        }

        public decimal Withdraw(int accountId, decimal amount)
        {
            decimal currentBalance = GetBalance(accountId);

            if (amount > currentBalance)
                throw new InsufficientFundException("Insufficient funds.");

            decimal newBalance = currentBalance - amount;

            using (SqlConnection conn = DBUtil.GetConnection())
            {
                conn.Open();
                string update = "UPDATE Accounts SET Balance = @balance WHERE Account_id = @account_id";
                SqlCommand cmd = new SqlCommand(update, conn);
                cmd.Parameters.AddWithValue("@balance", newBalance);
                cmd.Parameters.AddWithValue("@account_id", accountId);
                cmd.ExecuteNonQuery();
            }

            return newBalance;
        }

        public void Transfer(int fromAccountId, int toAccountId, decimal amount)
        {
            Withdraw(fromAccountId, amount);
            Deposit(toAccountId, amount);
        }
    }
}
