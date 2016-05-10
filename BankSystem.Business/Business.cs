using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Business
{
	public class Business
	{
		private Context _context;
		private Person _person;

		public Business(string connectionString)
		{
			_context = new Context(connectionString);
			_person = null;
		}

		public Person Person
		{
			get { return _person; }
		}

		public LoginResponse Login(string userName, string password)
		{
			List<PersonRecord> persons = _context.GetAllPersons();
			PersonRecord personRecord = persons.Find((record) => record.UserName == userName && record.Password == password);

			if (personRecord == null)
			{
				return LoginResponse.Failed;
			}
			else if (personRecord.State == true)
			{
				_person = new Person(personRecord);
				return LoginResponse.Successful;
			}
			else
			{
				return LoginResponse.NotApproved;
			}
		}

		public Person RegisterClient(string name, string id, string userName,
			string password, bool state, DateTime dateOfRegister, string registerBy)
		{
			List<PersonRecord> persons = _context.GetAllPersons();
			PersonRecord employee = persons.Find((record) => record.RegisterBy == registerBy);

			if (employee.PersonType == "employee")
			{

				PersonRecord newClient = new PersonRecord
				{
					Name = name,
					ID = id,
					UserName = userName,
					Password = password,
					PersonType = "client",
					State = state,
					DateOfRegister = dateOfRegister,
					RegisterBy = registerBy
				};

				PersonRecord personRecord = _context.CreatePerson(newClient);
				return new Person(personRecord);
			}
			else
			{
				return new Person(null);
			}
		}
	}
}
