using System;

namespace Model 
{
    public class Dice
    {
        public int DiceFaces { get; set; }
        private Random OwnRandom;
        public Dice(int size)
        {
            DiceFaces = size;
            OwnRandom = new Random();
        }

        public int Roll()
        {
            return OwnRandom.Next(1, DiceFaces + 1);
        }
    }
}