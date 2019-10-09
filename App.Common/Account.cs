using System;

namespace App.Accounts
{
	public class Account
	{
		public Account(int nomer, bool isBlocking)
		{
			Nomer = nomer;
			IsBlocking = isBlocking;
		}

		public int Nomer { get; set; }
		public bool IsBlocking { get; set; }

	}
}
