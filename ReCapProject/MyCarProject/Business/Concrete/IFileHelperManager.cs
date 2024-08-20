using Business.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FileHelperManager : IFileHelperService
    {
        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                var extension = Path.GetExtension(file.FileName);
                var newFileName = Guid.NewGuid().ToString() + extension;
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                var path = Path.Combine(root, newFileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return newFileName;
            }
            return null;
        }

        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }

}
