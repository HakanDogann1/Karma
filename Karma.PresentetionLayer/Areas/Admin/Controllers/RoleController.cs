using Karma.EntityLayer.Concrete;
using Karma.PresentetionLayer.Areas.Admin.Models.RoleViewModel;
using Karma.PresentetionLayer.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Karma.PresentetionLayer.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]")]
	public class RoleController : Controller
	{
		private readonly RoleManager<AppRole> _roleManager;

		public RoleController(RoleManager<AppRole> roleManager)
		{
			_roleManager = roleManager;
		}

		public async Task<IActionResult> Index()
		{
			var roles = await _roleManager.Roles.ToListAsync();
			var roleList = new List<RoleListViewModel>();
			foreach (var item in roles)
			{
				roleList.Add(new RoleListViewModel() { Name = item.Name , Id=item.Id});
			}
			return View(roleList);
		}

		public async Task<IActionResult> RoleCreate()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> RoleCreate(RoleCreateViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var result = await _roleManager.CreateAsync(new AppRole() { Name= model.Name });
			if (!result.Succeeded)
			{
				ModelState.AddModelErrorList(result.Errors.ToList());
				return View();
			}
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> RoleUpdate(int id)
		{
			var role = await _roleManager.FindByIdAsync(id.ToString());
			return View(new RoleUpdateViewModel()
			{
				Id= id,
				Name= role.Name,
			});
		}

		[HttpPost]
		public async Task<IActionResult> RoleUpdate(RoleUpdateViewModel model)
		{
			if(!ModelState.IsValid)
			{
				return View();
			}

			var role = await _roleManager.FindByIdAsync(model.Id.ToString());
			role.Name= model.Name;
			await _roleManager.UpdateAsync(role);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> RoleDelete(int id)
		{
			var role = await _roleManager.FindByIdAsync(id.ToString());
			var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
				ModelState.AddModelErrorList(result.Errors.ToList());
				return View();
            }
			return RedirectToAction(nameof(Index));
        }
	}
}
