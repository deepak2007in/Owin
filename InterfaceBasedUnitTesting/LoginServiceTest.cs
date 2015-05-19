using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterfaceBasedUnitTesting
{
    public interface IAccount
    {
        bool PasswordMatches(string password);
        void SetLoggedIn(bool isLoggedIn);
    }

    public interface IAccountRepository
    {
        IAccount Find(string userName);
    }

    public class LoginService
    {
        private IAccountRepository accountRepository;
        public LoginService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public void Login(string userName, string password)
        {
            var account = this.accountRepository.Find(userName);
            account.SetLoggedIn(true);
        }
    }

    [TestClass]
    public class LoginServiceTest
    {
        [TestMethod]
        public void Should_set_account_to_logged_in_when_password_matches()
        {
            // Arrange
            var account = A.Fake<IAccount>();
            A.CallTo(() => account.PasswordMatches(A<string>.Ignored)).Returns(true);

            var accountRepository = A.Fake<IAccountRepository>();
            A.CallTo(() => accountRepository.Find(A<string>.Ignored)).Returns(account);

            var service = new LoginService(accountRepository);

            // Act
            service.Login("username", "password");

            // Assert
            A.CallTo(() => account.SetLoggedIn(true)).MustHaveHappened();
        }
    }
}