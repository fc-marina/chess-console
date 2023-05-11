using board;
using chess;
using chess_console;

try
{
    ChessMatch match = new ChessMatch();
    while (!match.IsGameOver)
    {
        try
        {
            Console.Clear();
            Screen.PrintMatch(match);

            Console.WriteLine();
            Console.Write("Origem: ");
            Position origin = Screen.ReadChessPosition().ToPosition();
            match.ValidateOriginalPosition(origin);

            bool[,] possiblePositions = match.Board.Piece(origin).PossibleMovements();

            Console.Clear();
            Screen.PrintBoard(match.Board, possiblePositions);

            Console.WriteLine();
            Console.Write("Destino: ");
            Position final = Screen.ReadChessPosition().ToPosition();
            match.ValidateFinalPosition(origin, final);

            match.PerformMove(origin, final);
        }
        catch (BoardException ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
    }
    Console.Clear();
    Screen.PrintMatch(match);
}
catch (BoardException ex)
{
    Console.WriteLine(ex.Message);
}
Console.ReadLine();

