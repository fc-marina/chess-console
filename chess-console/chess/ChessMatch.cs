using board;

namespace chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public bool GameOver { get; private set; }
        public int Turn { get; private set; }
        public Color Player { get; private set; }
        private HashSet<Piece> _pieces;
        private HashSet<Piece> _capturedPieces;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            Player = Color.White;
            GameOver = false;
            _pieces = new HashSet<Piece>();
            _capturedPieces = new HashSet<Piece>();
            PutPieces();
        }

        private void PutNewPiece(char column, int row, Piece piece)
        {
            Board.PutPiece(piece, new ChessPosition(column, row).ToPosition());
            _pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutNewPiece('a', 1, new Rook(Board, Color.White));
            PutNewPiece('h', 1, new Rook(Board, Color.White));
            PutNewPiece('b', 1, new Knight(Board, Color.White));
            PutNewPiece('g', 1, new Knight(Board, Color.White));
            PutNewPiece('c', 1, new Bishop(Board, Color.White));
            PutNewPiece('f', 1, new Bishop(Board, Color.White));
            PutNewPiece('d', 1, new Queen(Board, Color.White));
            PutNewPiece('e', 1, new King(Board, Color.White));
            PutNewPiece('a', 2, new Pawn(Board, Color.White));
            PutNewPiece('h', 2, new Pawn(Board, Color.White));
            PutNewPiece('b', 2, new Rook(Board, Color.White));
            PutNewPiece('g', 2, new Rook(Board, Color.White));
            PutNewPiece('c', 2, new Rook(Board, Color.White));
            PutNewPiece('f', 2, new Rook(Board, Color.White));
            PutNewPiece('d', 2, new Rook(Board, Color.White));
            PutNewPiece('e', 2, new Rook(Board, Color.White));

            PutNewPiece('a', 8, new Rook(Board, Color.Black));
            PutNewPiece('h', 8, new Rook(Board, Color.Black));
            PutNewPiece('b', 8, new Knight(Board, Color.Black));
            PutNewPiece('g', 8, new Knight(Board, Color.Black));
            PutNewPiece('c', 8, new Bishop(Board, Color.Black));
            PutNewPiece('f', 8, new Bishop(Board, Color.Black));
            PutNewPiece('d', 8, new Queen(Board, Color.Black));
            PutNewPiece('e', 8, new King(Board, Color.Black));
            PutNewPiece('a', 7, new Pawn(Board, Color.Black));
            PutNewPiece('h', 7, new Pawn(Board, Color.Black));
            PutNewPiece('b', 7, new Rook(Board, Color.Black));
            PutNewPiece('g', 7, new Rook(Board, Color.Black));
            PutNewPiece('c', 7, new Rook(Board, Color.Black));
            PutNewPiece('f', 7, new Rook(Board, Color.Black));
            PutNewPiece('d', 7, new Rook(Board, Color.Black));
            PutNewPiece('e', 7, new Rook(Board, Color.Black));
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> pieces = new HashSet<Piece>();
            foreach (Piece piece in _capturedPieces)
            {
                if(piece.Color == color)
                {
                    pieces.Add(piece);
                }
            }
            return pieces;
        }

        public HashSet<Piece> PiecesOnBoard(Color color)
        {
            HashSet<Piece> pieces = new HashSet<Piece>();
            foreach (Piece piece in _pieces)
            {
                if (piece.Color == color)
                {
                    pieces.Add(piece);
                }
            }
            pieces.ExceptWith(CapturedPieces(color));
            return pieces;
        }

        public void PerformMove(Position origin, Position final)
        {
            MakeMove(origin, final);
            Turn++;
            ChangePlayer();
        }

        public void ValidateOriginalPosition(Position position)
        {
            if (Board.Piece(position) == null)
            {
                throw new BoardException("Não existe peça na posição de origem escolhida!");
            }
            if (Player != Board.Piece(position).Color)
            {
                throw new BoardException("A peça de origem escolhida não é sua!");
            }
            if (!Board.Piece(position).IsThereAnyPossibleMovements())
            {
                throw new BoardException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidateFinalPosition(Position origin, Position final)
        {
            if (!Board.Piece(origin).IsPossibleToMoveToPosition(final))
            {
                throw new BoardException("Posição de destino inválida!");
            }
        }

        private void ChangePlayer()
        {
            if (Player is Color.White)
            {
                Player = Color.Black;
            }
            else
            {
                Player = Color.White;
            }
        }

        public void MakeMove(Position origin, Position final)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseNumberOfMovements();
            Piece capturedPiece = Board.RemovePiece(final);
            Board.PutPiece(piece, final);
            if (capturedPiece != null)
            {
                _capturedPieces.Add(capturedPiece);
            }
        }
    }
}
