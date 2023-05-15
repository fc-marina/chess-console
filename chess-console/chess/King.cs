using board;

namespace chess
{
    internal class King : Piece
    {
        private ChessMatch match;
        public King(Board board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
        }

        private bool IsPossibleToMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        private bool IsRookToRoque(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece != null && piece is Rook && piece.Color == Color && piece.NumberOfMovements == 0;
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

            //# special move roque
            if (NumberOfMovements == 0 && !match.IsCheck)
            {
                Position position1 = new Position(Position.Row, Position.Column + 3);
                if (IsRookToRoque(position1))
                {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null)
                    {
                        mat[Position.Row, Position.Column + 2] = true;
                    }

                }
                Position position2 = new Position(Position.Row, Position.Column - 4);
                if (IsRookToRoque(position2))
                {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null)
                    {
                        mat[Position.Row, Position.Column - 2] = true;
                    }

                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
