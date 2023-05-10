using board;
using chess;
using chess_console;

try
{
    ChessMatch match = new ChessMatch();
    while (!match.GameOver)
    {
        try
        {
            Console.Clear();
            Screen.PrintMatch(match);
            //Screen.PrintBoard(match.Board);
            //Console.WriteLine();
            //Console.WriteLine("Turno: " + match.Turn);
            //Console.WriteLine("Aguardando jogador: " + match.Player);

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
}
catch (BoardException ex)
{
    Console.WriteLine(ex.Message);
}
Console.ReadLine();

