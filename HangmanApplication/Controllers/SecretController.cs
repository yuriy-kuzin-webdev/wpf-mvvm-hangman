using HangmanApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HangmanApplication.Controllers
{
    public class SecretController : ObservableObject
    {
        private List<StringBooleanModel> _word;
        public List<StringBooleanModel> Word
        {
            get => _word;
            set => OnPropertyChanged(ref _word, value);
        }
        public bool IsAllVisible
        {
            get => Word.All(pair => pair.IsVisible);
        }
        public SecretController(string secretWord)
        {
            Reset(secretWord);
        }
        public void Reset(string secretWord)
        {
            List<StringBooleanModel> word = new List<StringBooleanModel>();
            foreach (char c in secretWord)
                word.Add(new StringBooleanModel { IsVisible = false, Text = c.ToString() });
            Word = word;
        }
        public bool MakeVisible(string text)
        {
            IEnumerable<StringBooleanModel> matches = Word.Where(pair => pair.Text == text);

            if (matches.Count() == 0)
                return false;

            foreach (StringBooleanModel match in matches)
                match.IsVisible = true;

            return true;
        }
    }
}
