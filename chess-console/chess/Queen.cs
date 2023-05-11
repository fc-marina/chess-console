using board;

namespace chess
{
    internal class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
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

            position.DefineValues(Position.Row - 1, Position.Column - 1);
            while (Board.IsPositionValid(position) && IsPossibleToMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.DefineValues(position.Row - 1, position.Column - 1);
            }

            position.DefineValues(Position.Row - 1, Position.Column + 1);
            while (Board.IsPositionValid(position) && IsPossibleToMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.DefineValues(position.Row - 1, position.Column + 1);
            }

            position.DefineValues(Position.Row + 1, Position.Column + 1);
            while (Board.IsPositionValid(position) && IsPossibleToMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.DefineValues(position.Row + 1, position.Column + 1);
            }

            position.DefineValues(Position.Row + 1, Position.Column - 1);
            while (Board.IsPositionValid(position) && IsPossibleToMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.DefineValues(position.Row + 1, position.Column - 1);
            }
            position.DefineValues(Position.Row - 1, Position.Column);
            while (Board.IsPositionValid(position) && IsPossibleToMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Row = position.Row - 1;
            }

            position.DefineValues(Position.Row + 1, Position.Column);
            while (Board.IsPositionValid(position) && IsPossibleToMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Row = position.Row + 1;
            }

            position.DefineValues(Position.Row, Position.Column + 1);
            while (Board.IsPositionValid(position) && IsPossibleToMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column = position.Column + 1;
            }

            position.DefineValues(Position.Row, Position.Column - 1);
            while (Board.IsPositionValid(position) && IsPossibleToMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column = position.Column - 1;
            }
            return mat;
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
