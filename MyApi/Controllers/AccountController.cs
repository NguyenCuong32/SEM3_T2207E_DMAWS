using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyApi.Models;
using MyApi.Repositories;

namespace MyApi.Controllers;

[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountRepository accountRepository;

    public AccountController(IAccountRepository accountRepository)
    {
        this.accountRepository = accountRepository;
    }

    [HttpPost("SignUp")]
    public async Task<IActionResult> doSignUp(SignUpModel model)
    {
        var result = await accountRepository.SignUpAsync(model);
        if (result.Succeeded)
        {
            return Ok(result.Succeeded);
        }

        return Unauthorized(result.ToString());
    }

    [HttpPost("SignIn")]
    public async Task<IActionResult> doSignIn(SignInModel model)
    {
        var result = await accountRepository.SignInAsync(model);
        if (result.IsNullOrEmpty())
        {
            return Unauthorized();
        }

        return Ok(result);
    }
}