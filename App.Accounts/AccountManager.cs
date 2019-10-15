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
		List<Account> UnBlockAccount(int nomer);
		List<Account> BlockAccount(int nomer);
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
		public List<Account> UnBlockAccount(int nomer)
		{
			return _repository.UnBlockAccount(nomer);
		}
		public List<Account> BlockAccount(int nomer)
		{
			return _repository.BlockAccount(nomer);
		}
	}
}
