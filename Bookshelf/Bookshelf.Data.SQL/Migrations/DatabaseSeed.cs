using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bookshelf.Data.Sql;
using Bookshelf.Data.SQL.DAO;
using Org.BouncyCastle.Crypto.Tls;



/*using Bookshelf.Common.Enums;
using Bookshelf.Common.Extensions;
using Bookshelf.Data.Sql.DAO;
*/

namespace Bookshelf.Data.SQL.Migrations
{
    public class DatabaseSeed
    {
        private readonly BookshelfDbContext _context;

        public DatabaseSeed(BookshelfDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            // users > books > authors > reviews

            #region createUsers

            var userList = BuildUserList();
            _context.User.AddRange(userList);
            _context.SaveChanges();

            #endregion

            #region createAuthors

            var authorList = BuildAuthorList();
            _context.Author.AddRange(authorList);
            _context.SaveChanges();
            
            #endregion
            
            #region createBooks

            var bookList = BuildBookList(authorList);
            _context.Book.AddRange(bookList);
            _context.SaveChanges();

            #endregion
            

            
            #region createReviews

            var reviewList = BuildReviewList(userList, bookList);
            _context.Review.AddRange(reviewList);
            _context.SaveChanges();

            #endregion

            #region createBookPreferences
            var bookPreferenceList = BuildBookPreferenceList(userList, bookList);
            _context.BookPreference.AddRange(bookPreferenceList);
            _context.SaveChanges();
            
            #endregion
            
            #region createAuthorPreferences
            var authorPreferenceList = BuildAuthorPreferenceList(userList, authorList);
            _context.AuthorPreference.AddRange(authorPreferenceList);
            _context.SaveChanges();
            
            #endregion



            #region createReviewPreferences
            var reviewPreferenceList = BuildReviewPreferenceList(userList, reviewList);
            _context.ReviewPreference.AddRange(reviewPreferenceList);
            _context.SaveChanges();

            #endregion



        }

// prawdziwe rzeczy fr
        
        private IEnumerable<User> BuildUserList()
        {
            var userList = new List<User>();
            /*var user1 = new User()
            {
                Username = "UberKox21",
                Email = "UberKox21@o2.pl",
                Password = "jestemGigaChadem"
            };
            userList.Add(user1);*/

            for (int i = 0; i < 20; i++)
            {
                userList.Add(new User()
                {
                    Username = "FajnyUser",
                    Email = "fajnyemail.google.com",
                    Password = "FajneHaslo29"
                });
            }
            

            return userList;
        }
        
        private IEnumerable<Author> BuildAuthorList()
        {
            var authorList = new List<Author>();
            var author1 = new Author()
            {
                FirstName = "Andrzej",
                LastName = "Sapiący"
            };
            authorList.Add(author1);

            return authorList;
        }

        /*private IEnumerable<Book> BuildBookList(IEnumerable<Author> authorList)
        {
            var bookList = new List<Book>();
            var random = new Random();
            var authorIndex = random.Next(0, authorList.Count());  
            var book1 = new Book()
            {
                AuthorId = authorList.ToList()[authorIndex].AuthorId,
                Title = "wiedzmim tom 1",
                PagesNumber = 420
            };
            bookList.Add(book1);

            return bookList;

        }*/
        
        private IEnumerable<Book> BuildBookList(IEnumerable<Author> authorList)
        {
            var bookList = new List<Book>();
            /*var book1 = new Book()
            {
                AuthorId = authorList.ToList()[0].AuthorId,
                Title = "wiedzmim tom 1",
                PagesNumber = 420
            };
            bookList.Add(book1);*/
            for (int i = 0; i < 5; i++)
            {
                bookList.Add(new Book()
                {
                    AuthorId = authorList.ToList()[0].AuthorId,
                    Title = "wiedzmin",
                    PagesNumber = 123
                });
            }
            
            return bookList;

        }

        
        private IEnumerable<Review> BuildReviewList(IEnumerable<User> userList, IEnumerable<Book> bookList)
        {
            var reviewList = new List<Review>();
            var review1 = new Review()
            {
                UserId = userList.ToList()[18].UserId,
                BookId = bookList.ToList()[0].BookId,
                ReviewText = "niesamowita ksiazka. zabrala mnie w podroz"
            };
            var review2 = new Review()
            {
                UserId = userList.ToList()[18].UserId,
                BookId = bookList.ToList()[0].BookId,
                ReviewText = "druga mega ksiazka. zabrala mnie w podroz lololo"
            };
            
            reviewList.Add(review1);
            reviewList.Add(review2);

            return reviewList;
        }

// preferences bla bla chyba to tera powinno byc frfrr


        private IEnumerable<BookPreference> BuildBookPreferenceList(
            IEnumerable<User> userList, IEnumerable<Book> bookList)
        {
            var bookPreferenceList = new List<BookPreference>();
            foreach (var user in userList)
            {
                foreach (var book in bookList)
                {
                    bookPreferenceList.Add(new BookPreference()
                    {
                        UserId = user.UserId,
                        BookId = book.BookId,
                        Reading = false,
                        WantToRead = true,
                        Finished = false,
                        Favorite = true,
                        UserRating = 5
                    });
                }

            }

            return bookPreferenceList;
        }



        private IEnumerable<AuthorPreference> BuildAuthorPreferenceList(
            IEnumerable<User> userList, IEnumerable<Author> authorList)
        {
            var authorPreferenceList = new List<AuthorPreference>();
            foreach (var user in userList )
            {
                foreach (var author in authorList)
                {
                    authorPreferenceList.Add(new AuthorPreference()
                    {
                        UserId = user.UserId,
                        AuthorId = author.AuthorId,
                        Like = true,
                        Dislike = false,
                        Favorite = true
                    });
                }
            }

            return authorPreferenceList;
        }



        private IEnumerable<ReviewPreference> BuildReviewPreferenceList(
            IEnumerable<User> userList, IEnumerable<Review> reviewList)
        {
            var reviewPrederenceList = new List<ReviewPreference>();
            foreach (var user in userList)
            {
                foreach (var review in reviewList)
                {
                    reviewPrederenceList.Add(new ReviewPreference()
                    {
                        UserId = user.UserId,
                        ReviewId = review.ReviewId,
                        Dislike = false,
                        Like = true
                    });
                }
            }

            return reviewPrederenceList;
        }

    }
}