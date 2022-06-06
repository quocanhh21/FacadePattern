using FacadePattern;
using NUnit.Framework;
using System;

namespace BankTesting
{
    public class Tests
    {
        private int _accountNumberTest = 12345678; // mock data test
        private int _secNumberTest = 1234; // mock data test
        private AccountNumberCheck _accountNumberCheck;
        private SecurityCodeCheck _securityCodeCheck;
        private FundsCheck _fundsCheck;
        private BankAccountFacade _bankAccountFacade;

        [SetUp]
        public void Setup()
        {
            _accountNumberCheck = new AccountNumberCheck();
            _securityCodeCheck = new SecurityCodeCheck();
            _fundsCheck = new FundsCheck();
            _bankAccountFacade = new BankAccountFacade(_accountNumberTest, _secNumberTest);
        }

        [Test]
        public void BankAccountCheck_IsValid()
        {
            int accountNumber = _accountNumberCheck.GetAccountNumber();
            int secNumber = _securityCodeCheck.GetSecurityCode();
            Assert.AreEqual(accountNumber, _bankAccountFacade.GetAccountNumber());
            Assert.AreEqual(secNumber, _bankAccountFacade.GetSecurityCode());
        }

        [Test]
        public void DepositCash()
        {
            var depositeCashTest = 500; // mock data test
            var cashInAccountTest = _fundsCheck.IncreaseCashInAccount(depositeCashTest);

            Assert.AreEqual(1500, cashInAccountTest);
        }

        [Test]
        public void WithdrawCash()
        {
            var withdrawCashTest = 500; // mock data test
            var cashInAccountTest = _fundsCheck.DecreaseCashInAccount(withdrawCashTest);

            Assert.AreEqual(500, cashInAccountTest);
        }

        [Test]
        public void Withdraw_Throws()
        {
            var cashInAcount = _fundsCheck.GetcashInAccount();
            Assert.Throws<ArgumentOutOfRangeException>(() => _bankAccountFacade.WithdrawCash(-500));
        }

        [Test]
        public void Withdraw_MoreThanCashInAccount_Throws()
        {
            var cashInAcount = _fundsCheck.GetcashInAccount();
            Assert.Throws<ArgumentOutOfRangeException>(() => _bankAccountFacade.WithdrawCash(5000));
        }
    }
}