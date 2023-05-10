﻿namespace board
{
    abstract class Piece
    {
        public Position? Position { get; set; }
        public Color Color { get; protected set; }
        public int NumberOfMovements { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Color = color;
            Board = board;
            NumberOfMovements = 0;
        }

        public void IncreaseNumberOfMouvements()
        {
            NumberOfMovements++;
        }

        public abstract bool[,] PossibleMovements();
    }
}
