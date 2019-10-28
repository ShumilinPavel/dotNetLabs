using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Review
    {
        public Book BookSubject { get; private set; }
        public string ReviewerName { get; private set; }
        public string Content { get; private set; }
        public double Score { get; private set; }

        public Review(Book book, string reviewerName, string content, double score)
        {
            BookSubject = book;
            ReviewerName = reviewerName;
            Content = content;
            Score = score;
        }
    }
}
