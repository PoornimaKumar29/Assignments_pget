using BankingSystem.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.dao
{
    public interface ICustomerServiceProvider
    {
        decimal GetBalance(int accountId);
        decimal Deposit(int accountId, decimal amount);
        decimal Withdraw(int accountId, decimal amount);
        void Transfer(int fromAccountId, int toAccountId, decimal amount);
    }
}
