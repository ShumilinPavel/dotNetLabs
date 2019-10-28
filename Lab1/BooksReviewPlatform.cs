using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    static class BooksReviewPlatform
    {
        public static Dictionary<Book, List<Review>> BookToReviews { get; private set; }

        static BooksReviewPlatform()
        {
            BookToReviews = new Dictionary<Book, List<Review>>();
        }

        public static void PrintBooks()
        {
            Console.WriteLine("======");
            Console.WriteLine("Книги, размещенные на платформе");
            foreach (var book in BookToReviews.Keys)
            {
                Console.WriteLine("Название: \"{0}\", автор: {1}, жанр: {2}, страницы: {3}",
                    book.Title, book.Author.Name, book.Style, book.PagesNumber);
            }
            Console.WriteLine("======");
        }

        public static void AddBook(Book book)
        {
            if (BookToReviews.ContainsKey(book))
                return;
            BookToReviews.Add(book, new List<Review>());
            BookToReviews[book] = new List<Review>();
        }

        public static void AddBookReview(Review review, Book book)
        {
            if (!BookToReviews.ContainsKey(book))
                throw new Exception("Platfrom has no book which review is assigned to");
            BookToReviews[book].Add(review);
        }
    }
}
