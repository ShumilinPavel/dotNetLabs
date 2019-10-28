using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface IWriter
    {
        void WriteBook(string name, int pagesNumber, Style style);
        void PrintWrittenBooks();
        void PublishBook(Book book);
        void PrintBookReviews(Book book);
        // получить средний балл по книге
        // получить статистику по книге
    }

    class Writer : Human, IWriter
    {
        public List<Book> WrittenBooks { get; private set; }

        public Writer(string name, int age) : base(name, age)
        {
            WrittenBooks = new List<Book>();
        }

        public void WriteBook(string bookTitle, int pagesNumber, Style style)
        {
            var newBook = new Book(bookTitle, this, style, pagesNumber);
            WrittenBooks.Add(newBook);
        }

        public void PrintWrittenBooks()
        {
            Console.WriteLine("======");
            Console.WriteLine("Книги, написанные {0}", Name);
            foreach (var book in WrittenBooks)
            {
                Console.WriteLine("Название: \"{0}\", жанр: {1}, страницы: {2}", book.Title, book.Style, book.PagesNumber);
            }
            Console.WriteLine("======");
        }

        //public Book GetBook(string title)
        //{
        //    foreach (var book in WrittenBooks)
        //    {
        //        if (book.Title == title)
        //            return book;
        //    }
        //    throw new Exception();
        //}

        public void PublishBook(Book book)
        {
            if (WrittenBooks.Contains(book))
                BooksReviewPlatform.AddBook(book);
            else
                throw new Exception("Writer did not write this book");
        }

        public void PrintBookReviews(Book book)
        {
            if (!WrittenBooks.Contains(book))
                throw new Exception("Writer did not write this book");
            if (!BooksReviewPlatform.BookToReviews.ContainsKey(book))
                throw new Exception("Book is not published on review platfrom");
            Console.WriteLine("======");
            Console.WriteLine("{0} запросил отзывы по книге \"{1}\"", Name, book.Title);
            foreach (var review in BooksReviewPlatform.BookToReviews[book])
            {
                Console.WriteLine("Имя рецензента: {0}, оценка: {1}", review.ReviewerName, review.Score);
                Console.WriteLine("Комментарий: {0}", review.Content);
            }
            Console.WriteLine("======");
        }
    }
}
