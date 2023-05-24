using System;
using System.Collections.Generic;
using TickTackToe.Marks;
using TickTackToe.Tables;

namespace TickTackToe.Board
{
	public class GameBoard3X3
	{
		private readonly Dictionary<Position, Cell> _board = new Dictionary<Position, Cell>();
		public Dictionary<Position, Cell> Board => _board;
		

		private readonly Table3X3 _coordinate3X3;
		private Position[,] Positions => _coordinate3X3.Positions;

		private readonly GameMarks _marks;

		public GameBoard3X3(GameMarks marks, Table3X3 coordinate3X3)
		{
			_marks = marks;
			_coordinate3X3 = coordinate3X3;
			InitBoard();
		}

		public void RefreshBoard()
		{
			_board.Clear();
			InitBoard();
		} 
		private void InitBoard()
		{
			for (var i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Position coord = Positions[i, j];
					_board.Add(coord, new Cell(coord, _marks.EmptyMark));
				}
			}
		}
		public void MarkBoard(Mark mark, Position position)
		{
			Cell cell = _board[position];
			if (!cell.Mark.Equals(_marks.EmptyMark))
			{
				throw new InvalidOperationException("This cell is marked");
			}
			_board[position] = new Cell(position, mark);
		}

		public bool HasEmptyCell()
		{
			foreach ((Position key, Cell cell) in _board)
			{
				if (cell.Mark.Equals(_marks.EmptyMark))
				{
					return true;
				}
			}
			return false;
		}

		private bool CheckCellMark(Position position, Mark checkingMark)
		{
			return _board[position].Mark.Equals(checkingMark);
		}
	}
}