using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Criteria;

namespace DAL.Utils
{
    public class CloudinaryService
    {
        private Cloudinary _cloudinary;

        public CloudinaryService()
        {
            Account account = new Account(
                "dptt4ycyb",
                "989818666399175",
                "NlfO15Z1c99my1rmtqnRR3yAEaQ");
            _cloudinary = new Cloudinary(account);
        }

        public ImageCriteria UploadFile(Stream fileStream, string fileName)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, fileStream)
            };
            var uploadResult = _cloudinary.Upload(uploadParams);
            return new ImageCriteria
            {
                ImageUrl = uploadResult.SecureUrl.AbsoluteUri,
                ImagePublicId = uploadResult.PublicId
            };
        }

        public bool DeleteFile(string imageId)
        {
            var result = _cloudinary.DeleteResources(imageId);
            return true;
        }
    }
}
