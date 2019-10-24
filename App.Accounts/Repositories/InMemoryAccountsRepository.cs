using App.Configuration;
using App.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Accounts.Repositories
{
	public class InMemoryAccountsRepositoriy : IAccountsRepository, ITransientDependency
	{
		List<Account> account = new List<Account> 
		{ 
			new Account(1,false) ,
			new Account(2,true),
			new Account (3, false)
		};
		public List<Account> GetListAccounts()
		{
			return account;
		}
		public void BlockAccount(int number)
		{
			var item = account.Find(x => x.Number == number);
			if (item.IsBlocked)
			{
				throw new Exception("You cannot block an already blocked account");
			}
		    item.IsBlocked = true;
		}
		public void UnBlockAccount(int number)
		{
			var item = account.Find(x => x.Number == number);
			if (!item.IsBlocked)
			{
				throw new Exception("You cannot Unblock an already Unblocked account");
			}
			item.IsBlocked = false;
		}

	}
}
