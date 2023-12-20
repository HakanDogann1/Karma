using System.ComponentModel.DataAnnotations;

namespace Karma.PresentetionLayer.Areas.Admin.Models.RoleViewModel
{
	public class RoleCreateViewModel
	{
		[Required(ErrorMessage ="Role alanı boş bırakılamaz.")]
		public string Name { get; set; }
	}
}
