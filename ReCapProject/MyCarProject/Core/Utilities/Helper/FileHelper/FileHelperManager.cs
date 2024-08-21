using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        #region FileDelete
        public void Delete(string filePath) //filePath CarImageManager'dan gelen dosyanin kaydedildigi adres adi
        {
            if (File.Exists(filePath)) // Exists bir metoddurki,yuklenen fail yolunu(filepath="wwwroot/images/example.jpg")
                                       // yoxlayir ve eger sekil varsa geri true doner, eger yoxdursa false doner
            {
                File.Delete(filePath); //true donerse fayli sil
            }
            Console.WriteLine("Yanlis bir yol yazdiniz");
        }

        #endregion


        #region File Update

                                //Fayl           movcud konum,    yeni konum
        public string Update(IFormFile formFile, string filePath, string root) 
        {
            if (File.Exists(filePath)) //dosya uzantisinda dosya varsa
            {
                File.Delete(filePath); //dosyani sil
            }
            return Upload(formFile, root); //yeni dosya ekle
        }

        #endregion


        #region File Upload
                             //fayl tipi     Yuklenecek konum
        public string Upload(IFormFile formFile, string root)
        {
            if (formFile.Length > 0)//faylin uzunlugunu yoxlayir.Mes:O kb-dan boyukdurse demeli fayl movcuddur.
            {
                if (!Directory.Exists(root))   //faylin yuklenecek qovlugun yoxlayir
                {
                    Directory.CreateDirectory(root); //eger qovluq movcud deyilse yeni qovluq yaradir
                }
                string existsion = Path.GetExtension(formFile.FileName); //existsion, faylın uzantısını alır. əgər faylın adı img.jpgdirsə,
                                                                         //existsion dəyəri .jpg olur.Bu uzantı, faylın düzgün formatda saxlanması üçün lazımdır.
                string guid = GuidHelper.GuidHelper.CreateGuid(); //Bu sətr, fayla unikal bir ad yaradır. GUID, hər fayl üçün unikal bir kimlik yaradır, bu da eyni adda başqa bir fayl ilə toqquşmanı önləyir.
                string filePath = guid + existsion; //unikal GUID və fayl uzantısını birləşdirərək yeni bir fayl adı yaradır, məsələn 12345abcd.jpg.

                using (FileStream fileStream = File.Create(root + filePath)) 
                {
                    formFile.CopyTo(fileStream);
                    fileStream.Flush(); 
                    return filePath;
                }
            }
            return null;
        }
        #endregion

       
    }
}