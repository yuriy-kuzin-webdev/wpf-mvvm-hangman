using HangmanApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace HangmanApplication.Controllers
{
    public class GallowsController
    {
        public List<BooleanModel> Body { get; set; }
        public GallowsController()
        {
            Body = new List<BooleanModel>();
            while (Body.Count < 6)
                Body.Add(new BooleanModel { IsVisible = false });
        }
        public void Reset()
        {
            foreach (BooleanModel part in Body)
                part.IsVisible = false;
        }
        public bool MakeVisible()
        {
            Body.First(part => !part.IsVisible)
                .IsVisible = true;

            return Body.All(part => part.IsVisible);
        }
    }
}
