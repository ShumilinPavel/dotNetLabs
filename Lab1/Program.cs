using System;
using System.Collections.Generic;

namespace Lab1
{
    class Program
    {
        static void Main()
        {
            var Peter = new Writer("Peter", 25);
            Peter.WriteBook("The chance", 144, Style.Novel);
            Peter.WriteBook("The chance chapter II", 250, Style.Novel);
            Peter.PublishBook(Peter.WrittenBooks[0]);
            Peter.PublishBook(Peter.WrittenBooks[1]);
            Peter.PrintWrittenBooks();

            var booksOnPlatform = new List<Book>(BooksReviewPlatform.BookToReviews.Keys);

            var Alice = new Reader("Alice", 31);
            Alice.ReadBook(booksOnPlatform[0]);
            Alice.PublishReview(Alice.ReadBooks[0], "Good enough! Keep going!");
            Alice.PrintReadBooks();
            Alice.PrintPublishedReviews();
            Alice.ReadBook(booksOnPlatform[1]);
            Alice.PublishReview(Alice.ReadBooks[1], "I like the sequel more! Amazing work!");

            var BobsPreferences = new Preferences(new Dictionary<Style, double>() {
                { Style.Novel, 4 },
                { Style.Lyrics, 5 },
                { Style.Tale, 10 }
            }, 250);
            var Bob = new Reader("Bob", 18, BobsPreferences);
            Bob.ReadBook(booksOnPlatform[0]);
            Bob.PublishReview(Bob.ReadBooks[0], "I didn`t get it");

            BooksReviewPlatform.PrintBooks();

            Peter.PrintBookReviews(Peter.WrittenBooks[0]);
        }
    }
}
