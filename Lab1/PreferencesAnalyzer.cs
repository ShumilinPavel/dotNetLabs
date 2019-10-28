using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    static class PreferencesAnalyzer
    {
        private static double styleCoeff = 6;
        private static double writerCoeff = 2;
        private static double pagesCoeff = 2;
        private static double maxStyleScore = 10;

        public static double CalculateScore(Reader reader, Book book)
        {
            double writerScore = reader.Preferences.WritersPreferences.Contains(book.Author) ? 1 : 0;
            double styleScore = reader.Preferences.StylePreferences[book.Style] / maxStyleScore;
            double pagesScore = 1 - (Math.Abs(1.0 * reader.Preferences.PagesNumberPreference - book.PagesNumber)) /
                (book.PagesNumber + reader.Preferences.PagesNumberPreference);            
            return Math.Round(styleCoeff * styleScore + writerCoeff * writerScore + pagesCoeff * pagesScore);
        }
    }
}
