using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userdal;
        public UserManager(IUserDal userDal)
        {
            _userdal = userDal;
        }

        public IResult Add(User user)
        {
            _userdal.Add(user);
            return new SuccessResult("Yuklenme Tamamlandi");
        }

        public IResult Delete(User user)
        {
            _userdal.Delete(user);
            return new SuccessResult("Silinme Tamamlandi");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new DataResult<List<User>>(_userdal.GetAll(), true, "Istifadecilerin Siyahisi");
        }


        public IResult Update(User user)
        {
            _userdal.Update(user);

            return new SuccessResult("Mehsul Ugurla Deyisdirildi");
        }

        IDataResult<User> IUserService.GetById(int userId)
        {
            return new SuccessDataResult<User>(_userdal.Get(r => r.UserId == userId));
        }

    }
}
