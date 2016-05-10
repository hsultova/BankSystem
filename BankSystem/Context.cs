using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BankSystem
{
	public class Context
	{
		private readonly string _connectionString;

		public Context(string connectionString)
		{
			_connectionString = connectionString;
		}

		public SqlConnection CreateConnection()
		{
			SqlConnection connection = new SqlConnection(_connectionString);
			connection.Open();
			return connection;
		}

		#region Persons

		public PersonRecord CreatePerson(PersonRecord person)
		{
			using (SqlConnection connection = CreateConnection())
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText =
@"INSERT INTO Persons (Name, ID, UserName, Password, PersonType, State, DateOfRegister,RegisterBy) 
VALUES (@Name, @ID, @UserName, @Password, @PersonType, @State, @DateOfRegister, @RegisterBy) ";

					command.Parameters.AddWithValue("@Name", person.Name);
					command.Parameters.AddWithValue("@ID", person.ID);
					command.Parameters.AddWithValue("@UserName", person.UserName);
					command.Parameters.AddWithValue("@Password", person.Password);
					command.Parameters.AddWithValue("@PersonType", person.PersonType);
					command.Parameters.AddWithValue("@State", person.State);
					command.Parameters.AddWithValue("@DateOfRegister", person.DateOfRegister);
					command.Parameters.AddWithValue("@RegisterBy", person.RegisterBy);

					command.ExecuteNonQuery();

					return person;
				}
			}
		}

		public PersonRecord UpdatePerson(PersonRecord person)
		{
			using (SqlConnection connection = CreateConnection())
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText =
@"UPDATE Persons 
SET Name = @Name, Password = @Password, PersonType = @PersonType, 
State = @State, DateOfRegister = @DateOfRegister, RegisterBy = @RegisterBy
WHERE ID = @ID";

					command.Parameters.AddWithValue("@Name", person.Name);
					command.Parameters.AddWithValue("@Password", person.Password);
					command.Parameters.AddWithValue("@PersonType", person.PersonType);
					command.Parameters.AddWithValue("@State", person.State);
					command.Parameters.AddWithValue("@DateOfRegister", person.DateOfRegister);
					command.Parameters.AddWithValue("@RegisterBy", person.RegisterBy);
					command.Parameters.AddWithValue("@ID", person.ID);

					command.ExecuteNonQuery();

					return person;
				}
			}
		}

		public PersonRecord GetPerson(string id)
		{
			using (SqlConnection connection = CreateConnection())
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText =
@"SELECT Name, ID, UserName, Password, PersonType, State, DateOfRegister, RegisterBy
FROM Persons 
WHERE ID=@ID";

					command.Parameters.AddWithValue("@ID", id);

					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (!reader.Read())
							throw new ArgumentException("Invalid UserID!");

						var person = new PersonRecord
						{
							Name = reader["Name"].ToString(),
							ID = reader["ID"].ToString(),
							UserName = reader["UserName"].ToString(),
							Password = reader["Password"].ToString(),
							PersonType = reader["PersonType"].ToString(),
							State = (bool)reader["State"],
							DateOfRegister = (DateTime)reader["DateOfRegister"],
							RegisterBy = reader["RegisterBy"].ToString()
						};

						return person;
					}
				}
			}
		}

		public PersonRecord DeletePerson(string id)
		{
			using (SqlConnection connection = CreateConnection())
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = @"DELETE Persons WHERE ID=@ID ";

					command.Parameters.AddWithValue(@"ID", id);

					PersonRecord person = GetPerson(id);

					command.ExecuteNonQuery();

					return person;
				}
			}
		}

		#endregion

		#region Accounts

		public AccountRecord CreateAccount(AccountRecord account)
		{
			using (SqlConnection connection = CreateConnection())
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText =
@"INSERT INTO Accounts (Client_ID, IBAN, Currency, Description, DateOfCreate, RegisterBy)
VALUES (@Client_ID, @IBAN, @Currency, @Description, @DateOfCreate, @RegisterBy) ";

					command.Parameters.AddWithValue("@Client_ID", account.ClientID);
					command.Parameters.AddWithValue("@IBAN", account.IBAN);
					command.Parameters.AddWithValue("@Currency", account.Currency);
					command.Parameters.AddWithValue("@Description", account.Description);
					command.Parameters.AddWithValue("@DateOfCreate", account.DateOfCreate);
					command.Parameters.AddWithValue("@RegisterBy", account.RegisterBy);

					command.ExecuteNonQuery();

					return account;
				}
			}
		}

		public AccountRecord UpdateAccount(AccountRecord account)
		{
			using (SqlConnection connection = CreateConnection())
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText =
@"UPDATE Accounts SET Currency = @Currency, Description = @Description,
DateOfCreate = @DateOfCreate, RegisterBy = @RegisterBy
WHERE IBAN = @IBAN";

					command.Parameters.AddWithValue("@Currency", account.Currency);
					command.Parameters.AddWithValue("@Description", account.Description);
					command.Parameters.AddWithValue("@DateOfCreate", account.DateOfCreate);
					command.Parameters.AddWithValue("@RegisterBy", account.RegisterBy);
					command.Parameters.AddWithValue("@IBAN", account.IBAN);

					command.ExecuteNonQuery();

					return account;
				}
			}
		}

		public AccountRecord GetAccount(string IBAN)
		{
			using (SqlConnection connection = CreateConnection())
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText =
@"SELECT Client_ID, IBAN, Currency, Description, DateOfCreate, RegisterBy
FROM Accounts
WHERE IBAN = @IBAN";

					command.Parameters.AddWithValue("@IBAN", IBAN);

					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (!reader.Read())
							throw new ArgumentException("Invalid IBAN!");

						var account = new AccountRecord
						{
							ClientID = reader["Client_ID"].ToString(),
							IBAN = reader["IBAN"].ToString(),
							Currency = reader["Currency"].ToString(),
							Description = reader["Description"].ToString(),
							DateOfCreate = (DateTime)reader["DateOfCreate"],
							RegisterBy = reader["RegisterBy"].ToString()
						};

						return account;
					}
				}
			}
		}

		public AccountRecord DeleteAccount(string IBAN)
		{
			using (SqlConnection connection = CreateConnection())
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = @"DELETE Accounts WHERE IBAN = @IBAN";

					command.Parameters.AddWithValue("@IBAN", IBAN);

					AccountRecord account = GetAccount(IBAN);

					command.ExecuteNonQuery();

					return account;
				}
			}
		}

		#endregion

		#region Transactions

		public TransactionRecord CreateTransaction(TransactionRecord transaction)
		{
			using (SqlConnection connection = CreateConnection())
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText =
@"INSERT INTO Transactions (IBAN, Amount, Description, DateOfTransact, RegisterBy)
VALUES (@IBAN, @Amount, @Description, @DateOfTransact, @RegisterBy)";

					command.Parameters.AddWithValue("@IBAN", transaction.IBAN);
					command.Parameters.AddWithValue("@Amount", transaction.Amount);
					command.Parameters.AddWithValue("@Description", transaction.Description);
					command.Parameters.AddWithValue("@DateOfTransact", transaction.DateOfTransact);
					command.Parameters.AddWithValue("@RegisterBy", transaction.RegisterBy);

					command.ExecuteNonQuery();

					return transaction;
				}
			}
		}

		public TransactionRecord GetTransaction(string IBAN)
		{
			using (SqlConnection connection = CreateConnection())
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText =
@"SELECT IBAN, Amount, Description, DateOfTransact, RegisterBy
FROM Transactions
WHERE IBAN = @IBAN";

					command.Parameters.AddWithValue("@IBAN", IBAN);

					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (!reader.Read())
							throw new ArgumentException("Invalid IBAN!");

						var transaction = new TransactionRecord
						{
							IBAN = reader["IBAN"].ToString(),
							Amount = (int)reader["Amount"],
							Description = reader["Description"].ToString(),
							DateOfTransact = (DateTime)reader["DateOfTransact"],
							RegisterBy = reader["RegisterBy"].ToString()
						};

						return transaction;
					}
				}
			}
		}

		#endregion

		public List<PersonRecord> GetAllPersons()
		{
			using (SqlConnection connection = CreateConnection())
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText =
@"SELECT Name, ID, UserName, Password, PersonType, State, DateOfRegister, RegisterBy
FROM Persons ";

					using (SqlDataReader reader = command.ExecuteReader())
					{
						List<PersonRecord> persons = new List<PersonRecord>();

						while (reader.Read())
						{
							PersonRecord person = new PersonRecord
							{
								Name = reader["Name"].ToString(),
								ID = reader["ID"].ToString(),
								UserName = reader["UserName"].ToString(),
								Password = reader["Password"].ToString(),
								PersonType = reader["PersonType"].ToString(),
								State = (bool)reader["State"],
								DateOfRegister = (DateTime)reader["DateOfRegister"],
								RegisterBy = reader["RegisterBy"].ToString()
							};

							persons.Add(person);
						}

						return persons;
					}
				}
			}
		}

		public List<AccountRecord> GetAllAccountsByClientID(string clientID)
		{
			using (SqlConnection connection = CreateConnection())
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText =
@"SELECT Client_ID, IBAN, Currency, Description, DateOfCreate, RegisterBy
FROM Accounts
WHERE Client_ID = @Client_ID";

					command.Parameters.AddWithValue("@CLient_ID", clientID);

					using (SqlDataReader reader = command.ExecuteReader())
					{
						List<AccountRecord> accounts = new List<AccountRecord>();

						while (reader.Read())
						{
							AccountRecord account = new AccountRecord
							{
								ClientID = reader["Client_ID"].ToString(),
								IBAN = reader["IBAN"].ToString(),
								Currency = reader["Currency"].ToString(),
								Description = reader["Description"].ToString(),
								DateOfCreate = (DateTime)reader["DateOfCreate"],
								RegisterBy = reader["RegisterBy"].ToString()
							};

							accounts.Add(account);
						}

						return accounts;
					}
				}
			}
		}

		public List<TransactionRecord> GetAllTransactionByIBAN(string IBAN)
		{
			using (SqlConnection connection = CreateConnection())
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText =
@"SELECT IBAN, Amount, Description, DateOfTransact, RegisterBy
FROM Transactions
WHERE IBAN = @IBAN";

					command.Parameters.AddWithValue("@IBAN", IBAN);

					using (SqlDataReader reader = command.ExecuteReader())
					{
						List<TransactionRecord> transactions = new List<TransactionRecord>();

						while (reader.Read())
						{
							TransactionRecord transaction = new TransactionRecord
							{
								IBAN = reader["IBAN"].ToString(),
								Amount = (int)reader["Amount"],
								Description = reader["Description"].ToString(),
								DateOfTransact = (DateTime)reader["DateOfTransact"],
								RegisterBy = reader["RegisterBy"].ToString()
							};

							transactions.Add(transaction);
						}

						return transactions;
					}
				}
			}
		}
	}
}
