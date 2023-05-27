using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PresentetionLayer.Controllers
{
    public class HeaderController : Controller
    {
        private readonly IHeaderService _headerService;

        public HeaderController(IHeaderService headerService)
        {
            _headerService = headerService;
        }

        public IActionResult Index()
        {
            var values = _headerService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddHeader()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddHeader(Header header)
        {
            _headerService.TAdd(header);
            return RedirectToAction("Index");
        }

        public IActionResult AktifHeader(int id)
        {
            var value = _headerService.TGetByHeader(id);
            value.HeaderStatus = true;
            _headerService.TUpdate(value);
            return RedirectToAction("Index");
        }
        public IActionResult PasifHeader(int id)
        {
            var value = _headerService.TGetByHeader(id);
            value.HeaderStatus = false;
            _headerService.TUpdate(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateHeader(int id)
        {
            var value = _headerService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateHeader(Header header)
        {
            var value = _headerService.TGetById(header.HeaderID);
            value.HeaderStatus = true;
            _headerService.TUpdate(header);
            return RedirectToAction("Index");
        }
    }
}
