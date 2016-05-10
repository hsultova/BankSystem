using System;

namespace BankSystem.Business
{
	public class Account
	{
		private AccountRecord _account;

		public Account(AccountRecord accountRecord)
		{
			_account = accountRecord;
		}

		public string ClientID
		{
			get { return _account.ClientID; }
		}

		public string IBAN
		{
			get { return _account.IBAN; }
		}

		public string Currency
		{
			get { return _account.Currency; }
		}

		public string Description
		{
			get { return _account.Description; }
		}

		public DateTime DateOfCreate
		{
			get { return _account.DateOfCreate; }
		}

		public string RegisterBy
		{
			get { return _account.RegisterBy; }
		}
	}
}
