using HotelProject.DataAccessLayer.Migrations;

namespace HotelProject.WebUI.Helpers.Images
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string wwwroot;
        private const string imgFolder = "images";
        private const string appUserImagesFolder = "appUser-images";
        private const string roomImagesFolder = "room-images";
        private const string staffImagesFolder = "staff-images";

        public ImageHelper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            wwwroot = webHostEnvironment.WebRootPath;
        }

        private string ReplaceInvalidChars(string fileName)
        {
            return fileName.Replace("İ", "I")
                 .Replace("ı", "i")
                 .Replace("Ğ", "G")
                 .Replace("ğ", "g")
                 .Replace("Ü", "U")
                 .Replace("ü", "u")
                 .Replace("ş", "s")
                 .Replace("Ş", "S")
                 .Replace("Ö", "O")
                 .Replace("ö", "o")
                 .Replace("Ç", "C")
                 .Replace("ç", "c")
                 .Replace("é", "")
                 .Replace("!", "")
                 .Replace("'", "")
                 .Replace("^", "")
                 .Replace("+", "")
                 .Replace("%", "")
                 .Replace("/", "")
                 .Replace("(", "")
                 .Replace(")", "")
                 .Replace("=", "")
                 .Replace("?", "")
                 .Replace("_", "")
                 .Replace("*", "")
                 .Replace("æ", "")
                 .Replace("ß", "")
                 .Replace("@", "")
                 .Replace("€", "")
                 .Replace("<", "")
                 .Replace(">", "")
                 .Replace("#", "")
                 .Replace("$", "")
                 .Replace("½", "")
                 .Replace("{", "")
                 .Replace("[", "")
                 .Replace("]", "")
                 .Replace("}", "")
                 .Replace(@"\", "")
                 .Replace("|", "")
                 .Replace("~", "")
                 .Replace("¨", "")
                 .Replace(",", "")
                 .Replace(";", "")
                 .Replace("`", "")
                 .Replace(".", "")
                 .Replace(":", "")
                 .Replace(" ", "");
        }

        public async Task<string> UploadImage(string name, IFormFile formFile, string imageType, string folderName = null)
        {
            switch (imageType) 
            {
                case "appUser":
                    folderName = appUserImagesFolder;
                    break;
                case "room":
                    folderName = roomImagesFolder;
                    break;
                case "staff":
                    folderName = staffImagesFolder;
                    break;
                default:
                    folderName = "other-images";
                    break;
            }

            //O isimde klasör (wwwroot/images/room-images) yoksa klasörü oluşturur.
            if (!Directory.Exists($"{wwwroot}/{imgFolder}/{folderName}"))
            {
                Directory.CreateDirectory($"{wwwroot}/{imgFolder}/{folderName}");
            }

            string oldFileName = Path.GetFileNameWithoutExtension(formFile.FileName);   //resmin bilgisayarda kayıtlı olduğu adı getirir (Aile Odası)
            string fileExtension = Path.GetExtension(formFile.FileName);    //resmin uzantısını getirir (.jpg)

            name = ReplaceInvalidChars(name);   //(AileOdasi)
            DateTime dateTime = DateTime.Now;
            string newFileName = $"{name}_{dateTime.Millisecond}{fileExtension}";   //(AileOdasi_974.jpg)

            var path = Path.Combine($"{wwwroot}/{imgFolder}/{folderName}", newFileName);

            await using var stream = new FileStream(path, FileMode.Create);
            await formFile.CopyToAsync(stream);
            await stream.FlushAsync();

            //Database'e kaydetmek istediğimiz resim yolu (/images/room-images/AileOdasi_974.jpg)
            var imageName = $"/{imgFolder}/{folderName}/{newFileName}";
            return imageName;
        }

        public void Delete(string imageName)
        {
            var fileToDelete = Path.Combine($"{wwwroot}/{imageName}");
            if (File.Exists(fileToDelete))
            {
                File.Delete(fileToDelete);
            }
        }
    }
}
