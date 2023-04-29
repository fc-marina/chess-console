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
    }
}
