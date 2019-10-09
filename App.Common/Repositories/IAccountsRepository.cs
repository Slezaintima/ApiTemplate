using App.Accounts;
using System.Collections.Generic;

namespace App.Repositories
{
    public interface IAccountsRepository
    {
		List<Account> GetListAccounts();
		List<Account> Zamina(int nomer);
    }
}
