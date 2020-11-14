
namespace OnlineShop.Common.Helper
{
    public static class PasswordManagement
    {
        public static bool CheckPassword(string enterPassword, string password)=> BCrypt.Net.BCrypt.Verify(enterPassword, password);


        public static string HashPass(string pass) => BCrypt.Net.BCrypt.HashPassword(pass);

    }
}