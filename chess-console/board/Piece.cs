﻿namespace board
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; set; }
        public int NumberOfMovements { get; set; }
        public Board Board { get; set; }

        public Piece(Position position, Color color, Board board)
        {
            Position = position;
            Color = color;
            Board = board;
            NumberOfMovements = 0;
        }
    }
}
