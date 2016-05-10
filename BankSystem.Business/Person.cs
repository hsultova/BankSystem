using System;

namespace BankSystem.Business
{
	public class Person
	{
		private PersonRecord _person;

		public Person(PersonRecord personRecord)
		{
			_person = personRecord;
		}

		public string Name
		{
			get { return _person.Name; }
		}

		public string ID
		{
			get { return _person.ID; }
		}

		public string UserName
		{
			get { return _person.UserName; }
		}

		public string Password
		{
			get { return _person.Password; }
		}

		public string PersonType
		{
			get { return _person.PersonType; }
		}

		public bool State
		{
			get { return _person.State; }
		}

		public DateTime DateOfRegister
		{
			get { return _person.DateOfRegister; }
		}

		public string RegisterBy
		{
			get { return _person.RegisterBy; }
		}
	}
}
