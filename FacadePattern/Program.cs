using System;

namespace FacadePattern
{
    
    class Program
    {
        public class WelcomeToBank
        {
            public WelcomeToBank()
            {
                Console.WriteLine("Welcome to AAA Bank");
            }

        }

        public class AccountNumberCheck
        {
            private int accountNumber = 12345678;
            public int getAccountNUmber()
            {
                return accountNumber;
            }
            public bool accountActive(int acctNumToCheck)
            {
                if (acctNumToCheck == getAccountNUmber())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class SecurityCodeCheck
        {
            private int securityCode = 1234;
            public int getSecurityCode()
            {
                return securityCode;
            }
            public bool isCodeCorrect(int secCodeToCheck)
            {
                if (secCodeToCheck == getSecurityCode())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class FundsCheck
        {
            private double cashInAccount = 1000;
            public double getcashInAccount()
            {
                return cashInAccount;
            }
            public void decreaseCashInAccount(double cashWithdrawn)
            {
                cashInAccount -= cashWithdrawn;
            }
            public void increaseCashInAccount(double cashDeposited)
            {
                cashInAccount += cashDeposited;
            }
            public bool haveEnoughMoney(double cashToWithdrawal)
            {
                if(cashToWithdrawal > getcashInAccount())
                {
                    Console.WriteLine("ERROR: You don't have enough");
                    Console.WriteLine("Current Balance: " + getcashInAccount());
                    return false;
                }
                else
                {
                    decreaseCashInAccount(cashToWithdrawal);
                    Console.WriteLine("Withdrawal Conmplete: Current balance is " +getcashInAccount());
                    return true;
                }
            }
            public void makeDeposit(double cashToDeposit)
            {
                increaseCashInAccount(cashToDeposit);
                Console.WriteLine("Deposite Complete: Current Balance is " +getcashInAccount());
            }
        }
       
        
        public class BankAccountFacade
        {
            private int accountNumber;
            private int securityCode;

            AccountNumberCheck acctChecker;
            SecurityCodeCheck codeChecker;
            FundsCheck fundChecker;

            WelcomeToBank bankWelcome;

            public BankAccountFacade(int newAcctNum, int newSecCode)
            {
                accountNumber = newAcctNum;
                securityCode = newSecCode;

                bankWelcome = new WelcomeToBank();
                acctChecker = new AccountNumberCheck();
                codeChecker = new SecurityCodeCheck();
                fundChecker = new FundsCheck();
            }
            public int getAccountNumber()
            {
                return accountNumber;

            }
            public int getSecurityCode()
            {
                return securityCode;
            }
            public void withdrawCash(double cashToGet)
            {
                if (acctChecker.accountActive(getAccountNumber()) &&
                    codeChecker.isCodeCorrect(getSecurityCode()) &&
                        fundChecker.haveEnoughMoney(cashToGet))
                {
                    Console.WriteLine("Transaction Complete \n");
                    
                }
                else
                {
                    Console.WriteLine("Transaction Failed \n");
                }
            }
            public void depositCash(double cashToDeposit)
            {
                if (acctChecker.accountActive(getAccountNumber()) &&
                    codeChecker.isCodeCorrect(getSecurityCode()))
                {
                    fundChecker.makeDeposit(cashToDeposit);
                    Console.WriteLine("Transaction Complete \n");
                }
                else
                {
                    Console.WriteLine("Transaction Failed \n");
                }
            }
        }

        static void Main(string[] args)
        {
            BankAccountFacade accessingBank = new BankAccountFacade(12345678, 1234);

            accessingBank.withdrawCash(50);

            accessingBank.withdrawCash(1000);

            accessingBank.withdrawCash(900);

            accessingBank.depositCash(200);

            
        }
    }
}
