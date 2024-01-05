using BaiTap.Models;
using Microsoft.AspNetCore.Identity;

namespace BaiTap.interfaces
{
    public interface ILoginRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUp model);
        public Task<string> SignInAsync(SignIn model);
    }
}
