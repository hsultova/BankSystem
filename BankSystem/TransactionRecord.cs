using System;

namespace BankSystem
{
	public class TransactionRecord
	{
		public string IBAN { get; set; }

		public int Amount { get; set; }

		public string Description { get; set; }

		public DateTime DateOfTransact { get; set; }

		public string RegisterBy { get; set; }
	}
}
