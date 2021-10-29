
using Windows.UI.Xaml.Controls;

namespace MemoryGame2
{
    class Card
    {
        public bool MFlipped;
        public bool FLipped { get; set; }
        public string ImageSource { get; set; }
        public Card(string src)
        {
            ImageSource = src;
        }
    }
}

