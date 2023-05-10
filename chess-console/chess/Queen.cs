using board;

namespace chess
{
    internal class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            return mat;
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
