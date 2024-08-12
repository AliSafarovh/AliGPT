using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using DataAccess.Console.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Console
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult("Yuklenme Tamamlandi");
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult("Silinme Tamamlandi");
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new DataResult<List<Color>>(_colorDal.GetAll(), true, "Renglerin Siyahisi");
        }

      
        public IResult Update(Color color)
        {
            _colorDal.Update(color);

            return new SuccessResult("Mehsul Ugurla Deyisdirildi");
        }

        
    }
}
