using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern
{
    public class BankAccountFacade
    {
        private int _accountNumber;
        private int _securityCode;

        AccountNumberCheck acctChecker;
        SecurityCodeCheck codeChecker;
        FundsCheck fundChecker;

        WelcomeToBank bankWelcome;

        public BankAccountFacade(int newAcctNum, int newSecCode)
        {
            _accountNumber = newAcctNum;
            _securityCode = newSecCode;

            bankWelcome = new WelcomeToBank();
            acctChecker = new AccountNumberCheck();
            codeChecker = new SecurityCodeCheck();
            fundChecker = new FundsCheck();
        }
        public int GetAccountNumber()
        {
            return _accountNumber;

        }
        public int GetSecurityCode()
        {
            return _securityCode;
        }
        public void WithdrawCash(double cashToGet)
        {
            if (acctChecker.AccountActive(GetAccountNumber()) &&
                codeChecker.IsCodeCorrect(GetSecurityCode()) &&
                    fundChecker.HaveEnoughMoney(cashToGet))
            {
                Console.WriteLine("Transaction Complete \n");

            }
            else
            {
                Console.WriteLine("Transaction Failed \n");
            }
        }
        public void DepositCash(double cashToDeposit)
        {
            if (acctChecker.AccountActive(GetAccountNumber()) &&
                codeChecker.IsCodeCorrect(GetSecurityCode()))
            {
                fundChecker.MakeDeposit(cashToDeposit);
                Console.WriteLine("Transaction Complete \n");
            }
            else
            {
                Console.WriteLine("Transaction Failed \n");
            }
        }
    }
}
