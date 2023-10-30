using Microsoft.AspNetCore.Identity;
using MyApi.Models;

namespace MyApi.Repositories;

public interface IAccountRepository
{
    public Task<IdentityResult> SignUpAsync(SignUpModel model);
    public Task<string> SignInAsync(SignInModel model);
}