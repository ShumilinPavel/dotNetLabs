using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface IReader
    {
        void ReadBook(Book book);
        void PublishReview(Book book, string content);
        void PrintReadBooks();
        void PrintPublishedReviews();
        // Добавить изменения предпочтений??
    }

    class Reader : Human, IReader
    {
        public List<Book> ReadBooks { get; private set; }
        public List<Review> PublishedReviews { get; private set; }
        public Preferences Preferences { get; private set; }

        public Reader(string name, int age, Preferences preferenecs=null) : base(name, age)
        {
            ReadBooks = new List<Book>();
            PublishedReviews = new List<Review>();
            if (preferenecs != null)
                Preferences = preferenecs;
            else
                Preferences = new Preferences();
        }

        public void ReadBook(Book book)
        {
            if (ReadBooks.Contains(book))
                return;
            ReadBooks.Add(book);
        }

        public void PublishReview(Book book, string content)
        {
            if (!ReadBooks.Contains(book))
                throw new Exception("Reader did not read the book and try to review it");
            var score = PreferencesAnalyzer.CalculateScore(this, book);
            var review = new Review(book, Name, content, score);
            PublishedReviews.Add(review);
            BooksReviewPlatform.AddBookReview(review, book);
        }

        public void PrintReadBooks()
        {
            Console.WriteLine("======");
            Console.WriteLine("Книги, прочитанные {0}", Name);
            foreach (var book in ReadBooks)
            {
                Console.WriteLine("Название: \"{0}\", автор: {1}, жанр: {2}, страницы: {3}",
                                    book.Title, book.Author.Name, book.Style, book.PagesNumber);
            }
            Console.WriteLine("======");
        }

        public void PrintPublishedReviews()
        {
            Console.WriteLine("======");
            Console.WriteLine("Отзывы, написанные {0}", Name);
            foreach (var review in PublishedReviews)
            {
                Console.WriteLine("Отзыв на книгу \"{0}\" автора {1}", review.BookSubject.Title, review.BookSubject.Author.Name);
                Console.WriteLine("Оценка: {0}", review.Score);
                Console.WriteLine("Комментарий: {0}", review.Content);
            }
            Console.WriteLine("======");
        }
    }
}
