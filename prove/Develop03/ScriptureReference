using System;

namespace ScriptureMemorization
{
    public class ScriptureReference
    {
        public string Book { get; private set; }
        public string Chapter { get; private set; }
        public string StartVerse { get; private set; }
        public string EndVerse { get; private set; }

        public ScriptureReference(string reference)
        {
            if (reference.Contains("-"))
            {
                var parts = reference.Split(new[] { ':', '-' });
                Book = parts[0].Split(' ')[0];
                Chapter = parts[0].Split(' ')[1];
                StartVerse = parts[1];
                EndVerse = parts[2];
            }
            else
            {
                var parts = reference.Split(':');
                Book = parts[0].Split(' ')[0];
                Chapter = parts[0].Split(' ')[1];
                StartVerse = parts[1];
                EndVerse = parts[1];
            }
        }

        public override string ToString()
        {
            return StartVerse == EndVerse 
                ? $"{Book} {Chapter}:{StartVerse}" 
                : $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
    }
}
