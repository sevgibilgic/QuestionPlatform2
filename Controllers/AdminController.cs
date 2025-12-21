using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuestionPlatform2.Models;
using QuestionPlatform2.ViewModels;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole<int>> _roleManager;

    public AdminController(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole<int>> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<IActionResult> Users()
    {
        var users = _userManager.Users.ToList();
        var roles = _roleManager.Roles.Select(r => r.Name).ToList();

        var model = new List<UserRoleModel>();

        foreach (var user in users)
        {
            model.Add(new UserRoleModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Roles = (await _userManager.GetRolesAsync(user)).ToList(),
                AllRoles = roles
            });
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateRole(int userId, string role, bool isInRole)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
            return NotFound();

        if (isInRole)
            await _userManager.AddToRoleAsync(user, role);
        else
            await _userManager.RemoveFromRoleAsync(user, role);

        return RedirectToAction(nameof(Users));
    }

    public IActionResult Index()
        {
            return View();
        }
    }

