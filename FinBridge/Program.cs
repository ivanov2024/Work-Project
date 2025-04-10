using FinBridge.Data.Models;
using FinBridge.Data.Models.BankAccountEnums;

namespace FinBridge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var customer = new Customer("password")
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "dvsvovno@gmail.com",
                Phone = "+35951401256"

            };

            Console.WriteLine(customer.Password);

            var bank = new Bank()
            {
                Name = "Test",
                BankCode = "032043252",
                CountryCode = CountryCode.BG
            };

            var bankAccount1 = new BankAccount()
            {
                AccountNumber = "230458456",
                CountryCode = CountryCode.BG,
                AccountType = AccountType.SavingsAccount,
                BankId = bank.BankId,
                Bank = bank,
                CustomerId = customer.CustomerId,
                Customer = customer,
                Balance = 13333.56m
            };

            bankAccount1.InitializeAccountDetails(null);

            var bankAccount2 = new BankAccount()
            {
                AccountNumber = "000000",
                CountryCode = CountryCode.UK,
                AccountType = AccountType.LiquidationAccount,
                BankId = bank.BankId,
                Bank = bank,
                CustomerId = customer.CustomerId,
                Customer = customer,
                Balance = 16160.56m
            };

            bankAccount2.InitializeAccountDetails(CurrencyType.EUR.ToString());

            Console.WriteLine("---------Bank Account 1---------");
            Console.WriteLine(bankAccount1.IBAN);
            Console.WriteLine(bankAccount1.AccountNumber);
            Console.WriteLine(bankAccount1.Currency);

            Console.WriteLine("---------Bank Account 2---------");
            Console.WriteLine(bankAccount2.IBAN);
            Console.WriteLine(bankAccount2.AccountNumber);
            Console.WriteLine(bankAccount2.Currency);
        }
    }
}
