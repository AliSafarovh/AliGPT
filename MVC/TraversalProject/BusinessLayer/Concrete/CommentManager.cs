using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public void Add(Comment entity)
        {
           _commentDal.Insert(entity);
        }

        public void Delete(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Comment GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Comment> TGetByDestinationId(int id)
        {
            return _commentDal.GetListByFilter(x => x.DestinationId == id);
        }

        public void Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
