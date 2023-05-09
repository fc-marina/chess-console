using board;
using chess;
using chess_console;

try
{
    Board board = new Board(8, 8);
    board.PutPiece(new Rook(board, Color.White), new Position(0, 0));
    board.PutPiece(new Knight(board, Color.Black), new Position(1, 3));
    board.PutPiece(new King(board, Color.White), new Position(1, 4));
    board.PutPiece(new Queen(board, Color.Black), new Position(3, 2));
    Screen.PrintBoard(board);
}
catch (BoardException ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadLine();