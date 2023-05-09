namespace board
{
    class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        private Piece[,] _pieces;

        public Board(int rows, int columns)
        {
            Columns = columns;
            Rows = rows;
            _pieces = new Piece[rows, columns];
        }

        public Piece Piece(int row, int column)
        {
            return _pieces[row, column];
        }

        public Piece Piece(Position position)
        {
            return _pieces[position.Row, position.Column];
        }

        public void PutPiece(Piece piece, Position position)
        {
            if (DoesPieceExists(position))
            {
                throw new BoardException("There is already a piece at that position!");
            }
            _pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public bool IsPositionValid(Position position)
        {
            if (position.Row < 0 || position.Row >= Rows || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public bool DoesPieceExists(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }

        public void ValidatePosition(Position position)
        {
            if (!IsPositionValid(position))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}
