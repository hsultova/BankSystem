using System;

namespace BankSystem.Business
{
	public class Transaction
	{
		private TransactionRecord _transaction;

		public Transaction(TransactionRecord transactionRecord)
		{
			_transaction = transactionRecord;
		}

		public string IBAN
		{
			get { return _transaction.IBAN; }
		}

		public int Amount
		{
			get { return _transaction.Amount; }
		}

		public string Description
		{
			get { return _transaction.Description; }
		}

		public DateTime DateOfTransact
		{
			get { return _transaction.DateOfTransact; }
		}

		public string RegisterBy
		{
			get { return _transaction.RegisterBy; }
		}
	}
}
