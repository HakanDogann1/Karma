using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentetionLayer.Controllers
{
    public class ImageFileController : Controller
    {
        private readonly IImageFileService _imageFileService;

        public ImageFileController(IImageFileService imageFileService)
        {
            _imageFileService = imageFileService;
        }

        public IActionResult Index()
        {
            var values = _imageFileService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddImageFile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddImageFile(ImageFile imageFile)
        {
            _imageFileService.TAdd(imageFile);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateImageFile(int id)
        {
            var value = _imageFileService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateImageFile(ImageFile imageFile)
        {
            _imageFileService.TUpdate(imageFile);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteImageFile(int id)
        {
            var value = _imageFileService.TGetById(id);
            _imageFileService.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
