using App.Configuration;
using App.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Accounts.Repositories
{
	public class InMemoryAccountsRepositoriy : IAccountsRepository, ITransientDependency
	{
		List<Account> account = new List<Account> { new Account(1,false) ,
									   new Account(2,true),
										new Account (3, false)};
		public List<Account> GetListAccounts()
		{
			return account;
		}
		public List<Account> Zamina(int nomer)
		{
			
			for (int i = 0; i < account.Count; i++)
			{
				if (account[i].Nomer == nomer)
				{
					if (account[i].IsBlocking == false)
					{
						account[i].IsBlocking = true;
					}
					else if (account[i].IsBlocking == true)
					{
						account[i].IsBlocking = false;
					}
				}
			}
			return account;
		}
	}
}
