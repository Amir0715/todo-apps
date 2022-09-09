using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoApps.Identity.Models;

namespace TodoApps.Identity.Controllers;

public class AuthController: Controller
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly IIdentityServerInteractionService _interactionService;

    public AuthController(
        SignInManager<AppUser> signInManager, 
        UserManager<AppUser> userManager, 
        IIdentityServerInteractionService interactionService
        )
    {
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _interactionService = interactionService?? throw new ArgumentNullException(nameof(interactionService));
    }

    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        var viewModel = new LoginViewModel()
        {
            ReturnUrl = returnUrl
        };
        return View(viewModel);
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var user = await _userManager.FindByNameAsync(viewModel.Username);
        if (user == null)
        {
            ModelState.AddModelError(String.Empty, "User not found");
            return View(viewModel);
        }

        var result = await _signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false);
        if (result.Succeeded)
        {
            return Redirect(viewModel.ReturnUrl);
        }
        ModelState.AddModelError(String.Empty, "Login error");
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Register(string returnUrl)
    {
        var viewModel = new RegisterViewModel()
        {
            ReturnUrl = returnUrl
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(registerViewModel);
        }

        var user = new AppUser()
        {
            UserName = registerViewModel.Username
        };

        var result = await _userManager.CreateAsync(user, registerViewModel.Password);
        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);
            return Redirect(registerViewModel.ReturnUrl);
        }
        
        ModelState.AddModelError(String.Empty, "Error occured");
        return View(registerViewModel);
    }
    
    [HttpGet]
    public async Task<IActionResult> Logout(string logoutId)
    {
        await _signInManager.SignOutAsync();
        var logoutResult = await _interactionService.GetLogoutContextAsync(logoutId);
        return Redirect(logoutResult.PostLogoutRedirectUri);
    }
}