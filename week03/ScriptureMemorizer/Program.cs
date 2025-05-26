using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    // Class to represent a word in the scripture
    public class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public void Show()
        {
            _isHidden = false;
        }

        public bool IsHidden => _isHidden;

        public string GetDisplayText()
        {
            if (_isHidden)
            {
                string underscores = "";
                for (int i = 0; i < _text.Length; i++)
                {
                    underscores += "_";
                }
                return underscores;
            }
            return _text;
        }
    }

    // Class to represent a scripture reference
    public class ScriptureReference
    {
        private string _book;
        private int _chapter;
        private int _startVerse;
        private int? _endVerse;

        public ScriptureReference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = verse;
            _endVerse = null;
        }

        public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }

        public string GetDisplayText()
        {
            if (_endVerse.HasValue)
            {
                return _book + " " + _chapter + ":" + _startVerse + "-" + _endVerse;
            }
            return _book + " " + _chapter + ":" + _startVerse;
        }
    }

    // Class to manage the scripture text and its words
    public class Scripture
    {
        private ScriptureReference _reference;
        private List<Word> _words;

        public Scripture(ScriptureReference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            // Split text into words manually
            string currentWord = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    if (currentWord != "")
                    {
                        _words.Add(new Word(currentWord));
                        currentWord = "";
                    }
                }
                else
                {
                    currentWord += text[i];
                }
            }
            if (currentWord != "")
            {
                _words.Add(new Word(currentWord));
            }
        }

        public void HideRandomWords(int count)
        {
            Random random = new Random();
            List<Word> visibleWords = new List<Word>();

            // Collect visible words
            for (int i = 0; i < _words.Count; i++)
            {
                if (!_words[i].IsHidden)
                {
                    visibleWords.Add(_words[i]);
                }
            }

            // Only hide words if there are visible words left
            if (visibleWords.Count == 0) return;

            // Ensure we don't try to hide more words than are available
            if (count > visibleWords.Count)
            {
                count = visibleWords.Count;
            }

            // Hide random visible words
            for (int i = 0; i < count; i++)
            {
                int index = random.Next(0, visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
        }

        public bool IsCompletelyHidden()
        {
            for (int i = 0; i < _words.Count; i++)
            {
                if (!_words[i].IsHidden)
                {
                    return false;
                }
            }
            return true;
        }

        public string GetDisplayText()
        {
            string result = _reference.GetDisplayText() + ": ";
            for (int i = 0; i < _words.Count; i++)
            {
                result += _words[i].GetDisplayText();
                if (i < _words.Count - 1)
                {
                    result += " ";
                }
            }
            return result;
        }

        public void ShowHint()
        {
            Random random = new Random();
            List<Word> hiddenWords = new List<Word>();

            // Collect hidden words
            for (int i = 0; i < _words.Count; i++)
            {
                if (_words[i].IsHidden)
                {
                    hiddenWords.Add(_words[i]);
                }
            }

            // Show one random hidden word
            if (hiddenWords.Count > 0)
            {
                int index = random.Next(0, hiddenWords.Count);
                hiddenWords[index].Show();
            }
        }
    }

    // Class to manage a library of scriptures
    public class ScriptureLibrary
    {
        private List<Scripture> _scriptures;
        private Random _random;

        public ScriptureLibrary()
        {
            _scriptures = new List<Scripture>();
            _random = new Random();
            InitializeScriptures();
        }

        private void InitializeScriptures()
        {
            // Hardcoded scriptures instead of file loading
            _scriptures.Add(new Scripture(
                new ScriptureReference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life"
            ));
            _scriptures.Add(new Scripture(
                new ScriptureReference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths"
            ));
            _scriptures.Add(new Scripture(
                new ScriptureReference("Psalm", 23, 1),
                "The Lord is my shepherd I shall not want"
            ));
        }

        public Scripture GetRandomScripture()
        {
            return _scriptures[_random.Next(0, _scriptures.Count)];
        }
    }

    class Program
    {
        // Exceeded requirements by implementing the following features beyond the core requirements:
        // 1. Added a hint system to address memorization challenges: Users can type 'hint' to reveal one randomly selected hidden word, helping them when they struggle to recall specific parts of the scripture.
        // 2. Implemented a scripture library: A collection of three hardcoded scriptures (John 3:16, Proverbs 3:5-6, Psalm 23:1) is maintained, and a random scripture is selected at the start of the program, enhancing variety and replayability.
        // 3. Ensured random word selection only picks visible words: The program only hides words that are not already hidden, meeting the stretch goal and making the memorization process more effective and predictable.
        static void Main(string[] args)
        {
            ScriptureLibrary library = new ScriptureLibrary();
            Scripture currentScripture = library.GetRandomScripture();

            while (!currentScripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(currentScripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to continue, type 'hint' for a hint, or 'quit' to exit:");

                string input = Console.ReadLine();
                if (input != null)
                {
                    input = input.ToLower();
                }

                if (input == "quit")
                {
                    break;
                }
                else if (input == "hint")
                {
                    currentScripture.ShowHint();
                }
                else
                {
                    currentScripture.HideRandomWords(3);
                }
            }

            // Display final state
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine("\nScripture fully hidden! Program complete.");
        }
    }
}
