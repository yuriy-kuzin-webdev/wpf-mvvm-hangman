using HangmanApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace HangmanApplication.Controllers
{
    public class LettersController
    {
        public List<StringBooleanModel> Letters { get; set; }
        public LettersController()
        {
            Letters = new List<StringBooleanModel>();
            char c = 'A';
            while (c <= 'Z')
                Letters.Add(new StringBooleanModel { IsVisible = true, Text = c++.ToString() });
        }
        public void Reset()
        {
            foreach (StringBooleanModel pair in Letters)
                pair.IsVisible = true;
        }
        public void MakeInvisible(string text)
            => Letters.First(pair => pair.Text == text).IsVisible = false;
    }
}
