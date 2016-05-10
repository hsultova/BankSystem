using System;

namespace BankSystem
{
	public class AccountRecord
	{
		public string ClientID { get; set; }

		public string IBAN { get; set; }

		public string Currency { get; set; }

		public string Description { get; set; }

		public DateTime DateOfCreate { get; set; }

		public string RegisterBy { get; set; }
	}
}
