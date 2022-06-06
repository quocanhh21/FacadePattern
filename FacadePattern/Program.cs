using System;

namespace FacadePattern
{
    
    class Program
    {       
        static void Main(string[] args)
        {
            BankAccountFacade accessingBank = new BankAccountFacade(12345678, 1234);
        }
    }
}
