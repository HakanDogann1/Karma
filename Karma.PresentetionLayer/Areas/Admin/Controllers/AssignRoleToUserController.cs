using Karma.EntityLayer.Concrete;
using Karma.PresentetionLayer.Areas.Admin.Models.RoleViewModel;
using Karma.PresentetionLayer.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Karma.PresentetionLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AssignRoleToUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AssignRoleToUserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index(int id)
        {
            TempData["userId"] = id;
            var user = await _userManager.FindByIdAsync(id.ToString());
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);
            var roleViewModelList = new List<AssignRoleToUserModelView>();
            foreach (var role in roles)
            {
                var assignRoleToUserViewModel = new AssignRoleToUserModelView()
                {
                    Name = role.Name,
                    Id = role.Id
                };
                if (userRoles.Contains(role.Name))
                {
                    assignRoleToUserViewModel.Exist = true;
                }
                roleViewModelList.Add(assignRoleToUserViewModel);
            }
            return View(roleViewModelList);
        }
        [HttpPost]
        public async Task<IActionResult> Index(List<AssignRoleToUserModelView> request)
        {
            var userId = TempData["userId"]!.ToString();
            var user = await _userManager.FindByIdAsync(userId);

            foreach (var item in request)
            {
                if (item.Exist == true)
                {
                    var result = await _userManager.AddToRoleAsync(user,item.Name.ToString());
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }

            return RedirectToAction("Index","User");

        }
    }
}
