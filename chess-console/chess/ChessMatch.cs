﻿using board;

namespace chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public bool IsGameOver { get; private set; }
        public int Turn { get; private set; }
        public Color Player { get; private set; }
        public bool IsCheck { get; private set; }
        public Piece? VulnerableEnPassant { get; private set; }
        private HashSet<Piece> _pieces;
        private HashSet<Piece> _capturedPieces;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            Player = Color.White;
            IsGameOver = false;
            IsCheck = false;
            _pieces = new HashSet<Piece>();
            _capturedPieces = new HashSet<Piece>();
            VulnerableEnPassant = null;
            PutPieces();
        }

        public bool IsCheckmate(Color color)
        {
            if (!IsUnderCheck(color))
            {
                return false;
            }
            foreach (Piece piece in PiecesOnBoard(color))
            {
                bool[,] mat = piece.PossibleMovements();
                for (int i = 0; i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origen = piece.Position;
                            Position final = new Position(i, j);
                            Piece capturedPiece = MakeMove(origen, final);
                            bool isCheck = IsUnderCheck(color);
                            UndoMovement(origen, final, capturedPiece);
                            if (!isCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
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
            PutNewPiece('e', 1, new King(Board, Color.White, this));
            PutNewPiece('a', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('h', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('b', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('g', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('c', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('f', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('d', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('e', 2, new Pawn(Board, Color.White, this));

            PutNewPiece('a', 8, new Rook(Board, Color.Black));
            PutNewPiece('h', 8, new Rook(Board, Color.Black));
            PutNewPiece('b', 8, new Knight(Board, Color.Black));
            PutNewPiece('g', 8, new Knight(Board, Color.Black));
            PutNewPiece('c', 8, new Bishop(Board, Color.Black));
            PutNewPiece('f', 8, new Bishop(Board, Color.Black));
            PutNewPiece('d', 8, new Queen(Board, Color.Black));
            PutNewPiece('e', 8, new King(Board, Color.Black, this));
            PutNewPiece('a', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('h', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('b', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('g', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('c', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('f', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('d', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('e', 7, new Pawn(Board, Color.Black, this));
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> pieces = new HashSet<Piece>();
            foreach (Piece piece in _capturedPieces)
            {
                if (piece.Color == color)
                {
                    pieces.Add(piece);
                }
            }
            return pieces;
        }

        private Piece? King(Color color)
        {
            foreach (Piece piece in PiecesOnBoard(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool IsUnderCheck(Color color)
        {
            Piece king = King(color);
            if (king == null)
            {
                throw new BoardException("Não há rei da cor " + color + " no tabuleiro!");
            }

            foreach (Piece piece in PiecesOnBoard(OppositeColor(color)))
            {
                bool[,] mat = piece.PossibleMovements();
                if (mat[king.Position.Row, king.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        private Color OppositeColor(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
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
            Piece capturedPiece = MakeMove(origin, final);

            if (IsUnderCheck(Player))
            {
                UndoMovement(origin, final, capturedPiece);
                throw new BoardException("Você não pode se colocar em xeque!");
            }

            Piece piece = Board.Piece(final);

            // #jogada especial promocao
            if (piece is Pawn)
            {
                if ((piece.Color == Color.White && final.Row == 0) || (piece.Color == Color.Black && final.Row == 7))
                {
                    piece = Board.RemovePiece(final);
                    _pieces.Remove(piece);
                    Piece queen = new Queen(Board, piece.Color);
                    Board.PutPiece(queen, final);
                    _pieces.Add(queen);
                }
            }

            if (IsUnderCheck(OppositeColor(Player)))
            {
                IsCheck = true;
            }
            else
            {
                IsCheck = false;
            }

            if (IsCheckmate(OppositeColor(Player)))
            {
                IsGameOver = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }

            if (piece is Pawn && (final.Row == origin.Row - 2 || final.Row == origin.Row + 2))
            {
                VulnerableEnPassant = piece;
            }
            else
            {
                VulnerableEnPassant = null;
            }
        }

        private void UndoMovement(Position origin, Position final, Piece? capturedPiece)
        {
            Piece piece = Board.RemovePiece(final);
            piece.DecreaseNumberOfMovements();
            if (capturedPiece != null)
            {
                Board.PutPiece(capturedPiece, final);
                _capturedPieces.Remove(capturedPiece);
            }
            Board.PutPiece(piece, origin);

            if (piece is King && final.Column == origin.Column + 2)
            {
                Position originRook = new Position(origin.Row, origin.Column + 3);
                Position finalRook = new Position(origin.Row, origin.Column + 1);
                Piece piece1 = Board.RemovePiece(finalRook);
                piece1.DecreaseNumberOfMovements();
                Board.PutPiece(piece1, originRook);
            }

            if (piece is King && final.Column == origin.Column - 2)
            {
                Position originRook = new Position(origin.Row, origin.Column - 4);
                Position finalRook = new Position(origin.Row, origin.Column - 1);
                Piece piece1 = Board.RemovePiece(finalRook);
                piece1.DecreaseNumberOfMovements();
                Board.PutPiece(piece1, originRook);
            }

            // en passant
            if (piece is Pawn)
            {
                if (origin.Column != final.Column && capturedPiece == VulnerableEnPassant)
                {
                    Piece pawn = Board.RemovePiece(final);
                    Position positionPawn;
                    if (piece.Color == Color.White)
                    {
                        positionPawn = new Position(3, final.Column);
                    }
                    else
                    {
                        positionPawn = new Position(4, final.Column);
                    }
                    Board.PutPiece(pawn, positionPawn);
                }
            }
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
            if (!Board.Piece(origin).PossibleMovement(final))
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

        public Piece MakeMove(Position origin, Position final)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseNumberOfMovements();
            Piece? capturedPiece = Board.RemovePiece(final);
            Board.PutPiece(piece, final);
            if (capturedPiece != null)
            {
                _capturedPieces.Add(capturedPiece);
            }

            //# special move roque
            if (piece is King && final.Column == origin.Column + 2)
            {
                Position originRook = new Position(origin.Row, origin.Column + 3);
                Position finalRook = new Position(origin.Row, origin.Column + 1);
                Piece piece1 = Board.RemovePiece(originRook);
                piece1.IncreaseNumberOfMovements();
                Board.PutPiece(piece1, finalRook);
            }

            if (piece is King && final.Column == origin.Column - 2)
            {
                Position originRook = new Position(origin.Row, origin.Column - 4);
                Position finalRook = new Position(origin.Row, origin.Column - 1);
                Piece piece1 = Board.RemovePiece(originRook);
                piece1.IncreaseNumberOfMovements();
                Board.PutPiece(piece1, finalRook);
            }

            //# en passant
            if (piece is Pawn)
            {
                if (origin.Column != final.Column && capturedPiece == null)
                {
                    Position pawnPosition;
                    if (piece.Color == Color.White)
                    {
                        pawnPosition = new Position(final.Row + 1, final.Column);
                    }
                    else
                    {
                        pawnPosition = new Position(final.Row - 1, final.Column);
                    }
                    capturedPiece = Board.RemovePiece(pawnPosition);
                    _capturedPieces.Add(capturedPiece);
                }
            }
            return capturedPiece;
        }
    }
}
