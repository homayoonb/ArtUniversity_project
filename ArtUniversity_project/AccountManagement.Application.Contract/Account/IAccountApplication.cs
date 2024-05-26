using _0_Framework.Application;

namespace AccountManagement.Application.Contract.Account
{
    public interface IAccountApplication
    {
        AccountViewModel GetAccountBy(long id);
        OperationResult Register(RegisterAccount command);
        OperationResult Update(EditAccount command);
        OperationResult Login(Login command);
        EditAccount GetDetailsAccount(long id);
        void Logout();
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        List<AccountViewModel> GetAccounts();
        OperationResult ChangePassword(ChangePassword command);
    }
}
