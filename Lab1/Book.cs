using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    enum Style
    {
        Novel, Tale, Lyrics
    }

    class Book
    {
        public string Title { get; private set; }
        public Writer Author { get; private set; }
        public Style Style { get; private set; }
        public int PagesNumber { get; private set; }

        public Book(string bookTitle, Writer author, Style style, int pagesNumber)
        {
            Title = bookTitle;
            Author = author;
            Style = style;
            PagesNumber = pagesNumber;
        }
    }
}
