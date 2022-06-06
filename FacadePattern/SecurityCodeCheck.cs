using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern
{
    public class SecurityCodeCheck
    {
        private int _securityCode = 1234;
        public int GetSecurityCode()
        {
            return _securityCode;
        }
        public bool IsCodeCorrect(int secCodeToCheck)
        {
            if (secCodeToCheck == GetSecurityCode())
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
