using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanApplication.Models
{
    public class StringBooleanModel : BooleanModel
    {
        private string _text;
        public string Text
        {
            get => _text;
            set => OnPropertyChanged(ref _text, value);
        }
    }
}
