using Microsoft.AspNetCore.Mvc;

namespace FaylYükləmə.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly string _uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

        public FileUploadController()
        {
            // Yükləmə qovluğu yoxdursa, yaradılır
            if (!Directory.Exists(_uploadFolder))
            {
                Directory.CreateDirectory(_uploadFolder);
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Message = "Dosya seçilməyib.";
                return View("Index");
            }

            var filePath = Path.Combine(_uploadFolder, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            ViewBag.Message = $"Dosya uğurla yükləndi: {file.FileName}";
            return View("Index");
        }
    }
}
