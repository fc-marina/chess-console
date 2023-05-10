using board;

namespace chess
{
    internal class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            return mat;
        }

        public override string ToString()
        {
            return "k";
        }
    }
}
