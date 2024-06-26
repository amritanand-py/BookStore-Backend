﻿using CommonLayer.Request_Model;
using ManagerLayer.Interfaces;
using RepoLayer.Entity;
using RepoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Services
{
    public class BookManager:IBookManager
    {
        public readonly IBookRepo BookmanagerObj;

        public BookEntity BookAddition(BookCreationReq model)
        {
            return BookmanagerObj.BookAddition(model);
        }
        public BookEntity GetByID(getbyID model)
        {
            return BookmanagerObj.GetByID(model);
        }
        public IEnumerable<BookEntity> GetBooks(int page, int pageSize)
        {
            return BookmanagerObj.GetBooks(page, pageSize);
        }
    }
}
