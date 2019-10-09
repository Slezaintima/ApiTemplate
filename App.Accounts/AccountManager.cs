using App.Configuration;
using App.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Accounts
{
	public interface IAccountsManager
	{
		List<Account> GetListAccounts();
		List<Account> Zamina(int nomer);
	}
	public class AccountsManager : IAccountsManager, ITransientDependency
	{
	
		readonly IAccountsRepository _repository;
		public AccountsManager(IAccountsRepository repository)
		{
			_repository = repository;
		}

		public List<Account> GetListAccounts()
		{
			return _repository.GetListAccounts();
		}
		public List<Account> Zamina(int nomer)
		{
			return _repository.Zamina(nomer);
		}
	}
}
