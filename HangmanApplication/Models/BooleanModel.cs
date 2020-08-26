namespace HangmanApplication.Models
{
    public class BooleanModel : ObservableObject
    {
        private bool _isvisible;
        public bool IsVisible
        {
            get => _isvisible;
            set => OnPropertyChanged(ref _isvisible, value);
        }
    }
}
