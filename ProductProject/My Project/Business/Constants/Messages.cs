using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Mehsul Yuklendi:";
        public static string ProductNameInvalid = "Bu adda Mehsul artiq movcuddur";
        public static string MaintenanceTime="Sistem Bakimda";
        public static string ProductListed="Mehsullarin Siyahisi";
        public static string ProductDeleted = "Mehsul Silindi";
        public static string ProductUpdated = "Mehsul Deyisdirilidi";
        public static string ProductCountOfCategoryError = "Daxil Etdiyiniz mehsulun en Kategorisinde en az 10 Mehsul olmalidir";

        public static string CategoryLimitedExceded = "kategori Limiti Asildi";
    }
}
