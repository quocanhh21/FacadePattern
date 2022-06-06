using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern
{
    public class AccountNumberCheck
        {
            private int _accountNumber = 12345678;
            public int GetAccountNumber()
            {
                return _accountNumber;
            }
            public bool AccountActive(int acctNumToCheck)
            {
                if (acctNumToCheck == GetAccountNumber())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
}
