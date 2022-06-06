using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern
{
    public class FundsCheck
    {
        private double _cashInAccount = 1000;
        public double GetcashInAccount()
        {
            return _cashInAccount;
        }
        public double DecreaseCashInAccount(double cashWithdrawn)
        {
            return _cashInAccount -= cashWithdrawn;
        }
        public double IncreaseCashInAccount(double cashDeposited)
        {
            return _cashInAccount += cashDeposited;
        }
        public bool HaveEnoughMoney(double cashToWithdrawal)
        {
            if (cashToWithdrawal > GetcashInAccount())
            {
                Console.WriteLine("ERROR: You don't have enough");
                Console.WriteLine("Current Balance: " + GetcashInAccount());
                return false;
            }
            else
            {
                DecreaseCashInAccount(cashToWithdrawal);
                Console.WriteLine("Withdrawal Conmplete: Current balance is " + GetcashInAccount());
                return true;
            }
        }
        public void MakeDeposit(double cashToDeposit)
        {
            IncreaseCashInAccount(cashToDeposit);
            Console.WriteLine("Deposite Complete: Current Balance is " + GetcashInAccount());
        }
    }
}
