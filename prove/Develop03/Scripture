using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ScriptureMemorization
{
    public class Scripture
    {
        public ScriptureReference Reference { get; private set; }
        public string Text { get; private set; }
        private List<Word> Words { get; set; }

        public Scripture(string reference, string text)
        {
            Reference = new ScriptureReference(reference);
            Text = text;
            Words = new List<Word>();
            foreach (var word in Regex.Matches(text, @"\b\w+\b").Cast<Match>())
            {
                Words.Add(new Word(word.Value));
            }
        }

        public void HideRandomWords(int count = 3)
        {
            var wordsToHide = Words.Where(w => !w.Hidden).ToList();
            if (wordsToHide.Count == 0)
                return;

            var random = new Random();
            var selectedWords = wordsToHide.OrderBy(x => random.Next()).Take(count);
            foreach (var word in selectedWords)
            {
                word.Hide();
            }
        }

        public bool IsFullyHidden()
        {
            return Words.All(word => word.Hidden);
        }

        public override string ToString()
        {
            var displayedText = string.Join(" ", Words);
            return $"{Reference}\n{displayedText}";
        }
    }
}
