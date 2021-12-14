using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models
{
    public static class AddProfileImage
    {

        public static void ImageAdd(IFormFile image, out string fileName)
        {
            var extension = Path.GetExtension(image.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/",
                newImageName);
            var stream = new FileStream(location, FileMode.Create);
            image.CopyTo(stream);
            fileName = newImageName;
        }
    }
}
