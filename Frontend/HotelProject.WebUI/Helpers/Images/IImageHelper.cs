using Microsoft.AspNetCore.Http;

namespace HotelProject.WebUI.Helpers.Images
{
    public interface IImageHelper
    {
        Task<string> UploadImage(string name, IFormFile formFile, string imageType, string folderName = null);
        void Delete(string imageName);
    }
}
