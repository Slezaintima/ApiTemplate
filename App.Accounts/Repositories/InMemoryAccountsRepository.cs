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
		public List<Account> BlockAccount(int nomer)
		{
			var item = account.Find(x => x.Nomer == nomer);
			if (item.IsBlocking == true)
			{
				throw new Exception("You cannot block an already blocked account");
			}
			else
			{
				item.IsBlocking = true;
			}
			return account;
		}
		public List<Account> UnBlockAccount(int nomer)
		{
			var item = account.Find(x => x.Nomer == nomer);
			if (item.IsBlocking == false)
			{
				throw new Exception("You cannot Unblock an already Unblocked account");
			}
			else
			{
				item.IsBlocking = false;
			}
			return account;
		}

	}
}
