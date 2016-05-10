
using System;
using System.Configuration;

namespace BankSystem
{
	class Test
	{
		public static void Main()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["BankSystem"].ToString();
			Context context = new Context(connectionString);

			PersonRecord person = new PersonRecord
			{
				Name = "Maria",
				ID = "8704088793",
				UserName = "Mari",
				Password = "656",
				PersonType = "empleyee",
				State = true,
				DateOfRegister = DateTime.Today,
				RegisterBy = "n "
			};

			var account = new AccountRecord
			{
				ClientID = "8704088793",
				IBAN = "12118554G54",
				Currency = "EU",
				Description = "Description",
				DateOfCreate = DateTime.Today,
				RegisterBy = "n "
			};

			var transaction = new TransactionRecord
			{
				IBAN = "12668554G54",
				Amount = 1000,
				Description = "Description",
				DateOfTransact = DateTime.Today,
				RegisterBy = "Ivan Ivanov"
			};

			//context.CreatePerson(person);
			//context.UpdatePerson(person);
			context.CreateAccount(account);
			//context.UpdateAccount(account);
			//context.GetAccount(account.IBAN);
			//context.GetPerson(person.ID);
			//context.DeleteAccount(account.IBAN);
			//context.CreateTransaction(transaction);
			//context.GetTransaction(transaction.IBAN);
			//context.GetAllPersons();
			//context.GetAllTransactionByIBAN(transaction.IBAN);
			//context.GetAllAccountsByClientID("8905117695");
		}
	}
}
