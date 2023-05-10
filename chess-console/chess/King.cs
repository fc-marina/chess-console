using board;

namespace chess
{
    internal class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {
        }

        private bool IsPossibleToMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            Position position = new Position(0, 0);

            position.DefineValues(Position.Row - 1, Position.Column);
            if (Board.IsPositionValid(position) && IsPossibleToMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            position.DefineValues(Position.Row - 1, Position.Column + 1);
            if (Board.IsPositionValid(position) && IsPossibleToMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            position.DefineValues(Position.Row, Position.Column + 1);
            if (Board.IsPositionValid(position) && IsPossibleToMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            position.DefineValues(Position.Row + 1, Position.Column + 1);
            if (Board.IsPositionValid(position) && IsPossibleToMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            position.DefineValues(Position.Row + 1, Position.Column);
            if (Board.IsPositionValid(position) && IsPossibleToMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            position.DefineValues(Position.Row + 1, Position.Column - 1);
            if (Board.IsPositionValid(position) && IsPossibleToMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            position.DefineValues(Position.Row, Position.Column - 1);
            if (Board.IsPositionValid(position) && IsPossibleToMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            position.DefineValues(Position.Row - 1, Position.Column - 1);
            if (Board.IsPositionValid(position) && IsPossibleToMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            return mat;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
