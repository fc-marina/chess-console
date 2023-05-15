using board;

namespace chess
{
    internal class Pawn : Piece
    {
        private ChessMatch match;
        public Pawn(Board board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
        }

        private bool IsThereAnyEnemy(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece != null && piece.Color != Color;
        }

        private bool IsPieceFree(Position position)
        {
            return Board.Piece(position) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            if (Color == Color.White)
            {
                position.DefineValues(Position.Row - 1, Position.Column);
                if (Board.IsPositionValid(position) && IsPieceFree(position))
                {
                    mat[position.Row, position.Column] = true;
                }
                position.DefineValues(Position.Row - 2, Position.Column);
                if (Board.IsPositionValid(position) && IsPieceFree(position) && NumberOfMovements == 0)
                {
                    mat[position.Row, position.Column] = true;
                }
                position.DefineValues(Position.Row - 1, Position.Column - 1);
                if (Board.IsPositionValid(position) && IsThereAnyEnemy(position))
                {
                    mat[position.Row, position.Column] = true;
                }
                position.DefineValues(Position.Row - 1, Position.Column + 1);
                if (Board.IsPositionValid(position) && IsThereAnyEnemy(position))
                {
                    mat[position.Row, position.Column] = true;
                }

                //# En passant
                if (Position.Row == 3)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.IsPositionValid(left) && IsThereAnyEnemy(left) && Board.Piece(left) == match.VulnerableEnPassant)
                    {
                        mat[left.Row - 1, left.Column] = true;

                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.IsPositionValid(right) && IsThereAnyEnemy(right) && Board.Piece(right) == match.VulnerableEnPassant)
                    {
                        mat[right.Row - 1, right.Column] = true;

                    }
                }
            }
            else
            {
                position.DefineValues(Position.Row + 1, Position.Column);
                if (Board.IsPositionValid(position) && IsPieceFree(position))
                {
                    mat[position.Row, position.Column] = true;
                }
                position.DefineValues(Position.Row + 2, Position.Column);
                if (Board.IsPositionValid(position) && IsPieceFree(position) && NumberOfMovements == 0)
                {
                    mat[position.Row, position.Column] = true;
                }
                position.DefineValues(Position.Row + 1, Position.Column - 1);
                if (Board.IsPositionValid(position) && IsThereAnyEnemy(position))
                {
                    mat[position.Row, position.Column] = true;
                }
                position.DefineValues(Position.Row + 1, Position.Column + 1);
                if (Board.IsPositionValid(position) && IsThereAnyEnemy(position))
                {
                    mat[position.Row, position.Column] = true;
                }

                //# En passant
                if (Position.Row == 4)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.IsPositionValid(left) && IsThereAnyEnemy(left) && Board.Piece(left) == match.VulnerableEnPassant)
                    {
                        mat[left.Row + 1, left.Column] = true;

                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.IsPositionValid(right) && IsThereAnyEnemy(right) && Board.Piece(right) == match.VulnerableEnPassant)
                    {
                        mat[right.Row + 1, right.Column] = true;

                    }
                }
            }
            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
