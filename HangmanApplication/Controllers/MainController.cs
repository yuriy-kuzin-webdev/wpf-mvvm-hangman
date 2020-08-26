using HangmanApplication.Models;
using System;
using System.Linq;
using System.Windows.Input;

namespace HangmanApplication.Controllers
{
    public class MainController
    {
        public GallowsController    Gallows { get; private set; }
        public LettersController    Letters { get; private set; }
        public SecretController     Secret  { get; private set; }
        public StringBooleanModel   Modal   { get; private set; }

        public ICommand ResetCommand { get; set; }
        public ICommand TryLetterCommand { get; set; }
        public MainController()
        {
            Gallows = new GallowsController();
            Letters = new LettersController();
            Secret = new SecretController(DataProvider.GetRandomWord());
            Modal = new StringBooleanModel { IsVisible = false };

            ResetCommand = new RelayCommand<object>(Reset);
            TryLetterCommand = new RelayCommand<string>(TryLetter);
        }
        private void TryLetter(string letter)
        {
            if (Modal.IsVisible)
                return;

            Letters.MakeInvisible(letter);
            if(Secret.MakeVisible(letter))
            {
                if (Secret.IsAllVisible)
                    SetModalText("You win");
                return;
            }

            if (Gallows.MakeVisible())
                SetModalText(String.Join("",Secret.Word.Select(pair => pair.Text)));

        }
        private void Reset(object param)
        {
            Modal.IsVisible = false;
            Secret.Reset(DataProvider.GetRandomWord());
            Gallows.Reset();
            Letters.Reset();
        }
        private void SetModalText(string text)
        {
            Modal.IsVisible = true;
            Modal.Text = text;
        }
    }
}
