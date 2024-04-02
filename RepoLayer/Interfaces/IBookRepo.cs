using CommonLayer.Request_Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Interfaces
{
    public interface IBookRepo
    {
        public BookEntity BookAddition(BookCreationReq model);
        public BookEntity GetByID(getbyID model);
        public IEnumerable<BookEntity> GetBooks(int page, int pageSize);

    }
}
