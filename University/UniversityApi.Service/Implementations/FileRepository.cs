using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApi.Service.Interfaces;

namespace UniversityApi.Service.Implementations
{
    public class FileRepository : IFileRepository
    {
        public void FileDelete(string rootFolder, string folder, string file)
        {
           string fullPath = Path.Combine(rootFolder, folder,file);
            if (File.Exists(fullPath)) 
            {
                File.Delete(fullPath);

            }
        }

        public async Task<string> FileUpload(string rootFolder, string folder, IFormFile file)
        {
           string folderPath = Path.Combine(rootFolder, folder);
            string fileName =Guid.NewGuid().ToString() + "_"+ file.FileName;
            string fullPath =Path.Combine(folderPath, fileName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }
            return fileName;
          }
    }
}
