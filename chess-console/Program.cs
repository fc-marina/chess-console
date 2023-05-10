using board;
using chess;
using chess_console;

try
{
    ChessMatch match = new ChessMatch();
    while (!match.GameOver)
    {
        Console.Clear();
        Screen.PrintBoard(match.Board);

        Console.WriteLine();
        Console.Write("Origem: ");
        Position origin = Screen.ReadChessPosition().ToPosition();

        bool[,] possiblePositions = match.Board.Piece(origin).PossibleMovements();

        Console.Clear();
        Screen.PrintBoard(match.Board, possiblePositions);

        Console.WriteLine();
        Console.Write("Destino: ");
        Position final = Screen.ReadChessPosition().ToPosition();

        match.MakeMove(origin, final);
    }
}
catch (BoardException ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadLine();