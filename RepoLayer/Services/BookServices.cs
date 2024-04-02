using CommonLayer.Encryption;
using CommonLayer.Request_Model;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Services
{
    public class BookServices :IBookRepo
    {
        public readonly BookStoreContext BookStoreContext;
        public BookServices(BookStoreContext BookStoreContext)
        {
            this.BookStoreContext = BookStoreContext;
        }
        /*     --------------------------------------------------------------------------------------*/
        public BookEntity BookAddition(BookCreationReq model)
        {
            BookEntity newBook = new BookEntity();
            newBook.Title = model.Title;
            newBook.Author = model.Author;
            newBook.Stocks = model.Stocks;
            newBook.Price = model.Price;
            newBook.Rating = (decimal)model.Rating;
            newBook.RatingCount = (int)model.RatingCount;
            newBook.CoverUrl = model.CoverUrl;
            newBook.DiscountedPrice = (decimal)model.DiscountedPrice;
            newBook.Details = model.Details;
            newBook.CreatedAt = DateTime.UtcNow; // Set the creation timestamp to current UTC time
            newBook.UpdatedAt = DateTime.UtcNow;
            BookStoreContext.BooksTable.Add(newBook);
            BookStoreContext.SaveChanges();
            return newBook;
        }

        /*     --------------------------------------------------------------------------------------*/
        public BookEntity GetByID(getbyID model)
        {
            var book = BookStoreContext.BooksTable.FirstOrDefault(x => x.BookId == model.BookId);
            if (book == null)
            {
                    throw new Exception("note not avail");
                
            }
            return book;
           
        }
    }
}
