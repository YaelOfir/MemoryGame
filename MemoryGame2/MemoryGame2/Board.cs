using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame2
{
    class Board
    {
        public Card[] Cards { get; set; }
        private List<string> images { get; set; }
        public Board(int size)
        {
            //size interpetation
            Shuffle(size);
            Cards = new Card[size * size];
            for (int i = 0; i < size * size; i++)
            {
                Cards[i] = new Card(images[i]);
            }
        }
        public Card GetCard(int num)
        {
            return Cards[num];
        }
        //Shuffle the cards
        private void Shuffle(int num)
        {
            images = new List<string>();
            List<string> sources = new List<string>();
            for (int i = 1; i <= (num * num) / 2; i++)
            {
                sources.Add($"ms-appx:///Assets/{i}.png");
                sources.Add($"ms-appx:///Assets/{i}.png");
            }
            Random rand = new Random();
            for (int i = 0; i < num * num; i++)
            {
                int imgIndex = rand.Next(0, sources.Count);
                images.Add(sources[imgIndex]);
                sources.RemoveAt(imgIndex);
            }
        }
    }
}

