using board;
using System;

namespace chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public bool GameOver { get; private set; }
        private int turn;
        private Color player;

        public ChessMatch()
        {
            Board = new Board(8,8);
            turn = 1;
            player = Color.White;
            GameOver = false;
            PutPieces();
        }

        private void PutPieces()
        {
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('a', 1).ToPosition());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('h', 1).ToPosition());
            Board.PutPiece(new Knight(Board, Color.White), new ChessPosition('b', 1).ToPosition());
            Board.PutPiece(new Knight(Board, Color.White), new ChessPosition('g', 1).ToPosition());
            Board.PutPiece(new Bishop(Board, Color.White), new ChessPosition('c', 1).ToPosition());
            Board.PutPiece(new Bishop(Board, Color.White), new ChessPosition('f', 1).ToPosition());
            Board.PutPiece(new Queen(Board, Color.White), new ChessPosition('d', 1).ToPosition());
            Board.PutPiece(new King(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('a', 2).ToPosition());
            Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('h', 2).ToPosition());
            Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('b', 2).ToPosition());
            Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('g', 2).ToPosition());
            Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('c', 2).ToPosition());
            Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('f', 2).ToPosition());
            Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('d', 2).ToPosition());
            Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('e', 2).ToPosition());

            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('a', 8).ToPosition());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('h', 8).ToPosition());
            Board.PutPiece(new Knight(Board, Color.Black), new ChessPosition('b', 8).ToPosition());
            Board.PutPiece(new Knight(Board, Color.Black), new ChessPosition('g', 8).ToPosition());
            Board.PutPiece(new Bishop(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
            Board.PutPiece(new Bishop(Board, Color.Black), new ChessPosition('f', 8).ToPosition());
            Board.PutPiece(new Queen(Board, Color.Black), new ChessPosition('d', 8).ToPosition());
            Board.PutPiece(new King(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
            Board.PutPiece(new Pawn(Board, Color.Black), new ChessPosition('a', 7).ToPosition());
            Board.PutPiece(new Pawn(Board, Color.Black), new ChessPosition('h', 7).ToPosition());
            Board.PutPiece(new Pawn(Board, Color.Black), new ChessPosition('b', 7).ToPosition());
            Board.PutPiece(new Pawn(Board, Color.Black), new ChessPosition('g', 7).ToPosition());
            Board.PutPiece(new Pawn(Board, Color.Black), new ChessPosition('c', 7).ToPosition());
            Board.PutPiece(new Pawn(Board, Color.Black), new ChessPosition('f', 7).ToPosition());
            Board.PutPiece(new Pawn(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
            Board.PutPiece(new Pawn(Board, Color.Black), new ChessPosition('e', 7).ToPosition());
        }

        public void MakeMove(Position origin, Position final)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseNumberOfMouvements();
            Piece capturedPiece = Board.RemovePiece(final);
            Board.PutPiece(piece, final);
        }
    }
}
