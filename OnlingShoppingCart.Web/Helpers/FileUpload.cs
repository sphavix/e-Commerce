namespace OnlingShoppingCart.Web.Helpers
{
    public class FileUpload
    {
        private readonly IWebHostEnvironment _environment;

        public FileUpload(IWebHostEnvironment environment)
        {
            _environment= environment;
        }

        public string UploadFile(IFormFile file)
        {
            string fileName = null;
            if(file != null)
            {
                string uploadFolder = Path.Combine(_environment.WebRootPath, "images");
                fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filePath = Path.Combine(uploadFolder, fileName);
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return fileName;
        }
    }
}
