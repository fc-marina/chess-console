using board;
using chess;

namespace chess_console
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackgroundColor = Console.BackgroundColor;
            ConsoleColor changedBackgroundColor = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = changedBackgroundColor;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackgroundColor;
                    }
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalBackgroundColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackgroundColor;
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {

                if (piece.Color == Color.White)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }

        internal static void PrintMatch(ChessMatch match)
        {
            PrintBoard(match.Board);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turno: " + match.Turn);
            if (!match.IsGameOver)
            {
                Console.WriteLine("Aguardando jogador: " + match.Player);
                if (match.IsCheck)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + match.Player);

            }
        }

        private static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            PrintHashSet(match.CapturedPieces(Color.White));
            Console.Write("Pretas: ");
            ConsoleColor consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintHashSet(match.CapturedPieces(Color.Black));
            Console.ForegroundColor = consoleColor;
        }

        public static void PrintHashSet(HashSet<Piece> pieces)
        {
            Console.Write("[");
            foreach (Piece piece in pieces)
            {
                Console.Write(piece + " ");
            }
            Console.WriteLine("]");
        }
    }
}
