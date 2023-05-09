using board;
using chess;
using chess_console;

//try
//{
//    Board board = new Board(8, 8);
//    board.PutPiece(new Rook(board, Color.Black), new Position(0, 0));
//    board.PutPiece(new Rook(board, Color.Black), new Position(1, 3));
//    board.PutPiece(new King(board, Color.Black), new Position(2, 3));
//    Screen.PrintBoard(board);
//}
//catch (BoardException ex)
//{
//    Console.WriteLine(ex.Message);
//}
ChessPosition position = new ChessPosition('c', 7);
Console.WriteLine(position);
Console.WriteLine(position.ToPosition());
Console.ReadLine();