using System;

namespace BankSystem
{
	public class PersonRecord
	{
		private string _ID;

		public string Name { get; set; }

		public string ID
		{
			get
			{
				return _ID;
			}
			set
			{
				if (value.Length >= 10)
				{
					_ID = value;
				}
			}
		}

		public string UserName { get; set; }

		public string Password { get; set; }

		public string PersonType { get; set; }

		public bool State { get; set; }

		public DateTime DateOfRegister { get; set; }

		public string RegisterBy { get; set; }
	}
}
