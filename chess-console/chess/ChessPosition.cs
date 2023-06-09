﻿using board;

namespace chess
{
    internal class ChessPosition
    {
        //public ChessPosition(int row, int column) : base(row, column)
        //{
        //}
        public char Column { get; set; }
        public int Row { get; set; }

        public ChessPosition(char column, int row)
        {
            Column = column;
            Row = row;
        }

        public Position ToPosition()
        {
            return new Position(8 - Row, Column - 'a');
        }

        public override string ToString()
        {
            return "" + Column + Row;
        }
    }
}
