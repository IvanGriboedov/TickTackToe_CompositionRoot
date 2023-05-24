using System.Collections.Generic;
using TickTackToe.Marks;
using TickTackToe.Tables;

namespace TickTackToe.Board
{
	public class Referee3X3
	{
		private readonly GameBoard3X3 _board3X3;
		private readonly Table3X3 _table3X3;
		
		private Dictionary<Position, Cell> Board => _board3X3.Board;
		private Position[,] Positions => _table3X3.Positions;
		
		private readonly Position[] _winningPositions = new Position[3];
		public Position[] WinningPositions => _winningPositions;
		
		public Referee3X3(GameBoard3X3 board3X3, Table3X3 table3X3)
		{
			_board3X3 = board3X3;
			_table3X3 = table3X3;
		}

		public bool CheckWinner(Mark mark)
		{
			return CheckWinningRows(mark) || CheckWinningColumns(mark) || CheckWinningDiagonals(mark);
		}
		private bool CheckCellMark(Position position, Mark checkingMark)
		{
			return Board[position].Mark.Equals(checkingMark);
		}
		private void SetWinningCells(Position cell1, Position cell2, Position cell3)
		{
			_winningPositions[0] = cell1;
			_winningPositions[1] = cell2;
			_winningPositions[2] = cell3;
		}	
	
		private bool CheckWinningRows(Mark mark)
		{
			for (int i = 0; i < 3; i++)
			{
				bool isWinning = CheckCellMark(Positions[i, 0], mark) 
				                 && CheckCellMark(Positions[i, 1], mark) 
				                 && CheckCellMark(Positions[i, 2], mark);
				
				if (isWinning)
				{
					SetWinningCells(Positions[i,0], Positions[i,1], Positions[i,2]);
					return true;
				}
			}
			return false;
		}
		
		private bool CheckWinningColumns(Mark mark)
		{
			for (int i = 0; i < 3; i++)
			{
				bool isWinning = CheckCellMark(Positions[0, i], mark) 
				                 && CheckCellMark(Positions[1, i], mark) 
				                 && CheckCellMark(Positions[2, i], mark);

				if (isWinning)
				{
					SetWinningCells(Positions[0,i], Positions[1,i], Positions[2,i]);
					return true;
				}
			}

			return false;
		}

		private bool CheckWinningDiagonals(Mark mark)
		{
			bool diagonal1 = CheckCellMark(Positions[0,0], mark) 
			                 && CheckCellMark(Positions[1,1], mark) 
			                 && CheckCellMark(Positions[2,2], mark);

			bool diagonal2 = CheckCellMark(Positions[0, 2], mark)
			                 && CheckCellMark(Positions[1, 1], mark) 
			                 && CheckCellMark(Positions[2, 0], mark);
			
			if (diagonal1)
				SetWinningCells(Positions[0,0], Positions[1,1], Positions[2,2]);
			
			if (diagonal2) 
				SetWinningCells(Positions[0,2], Positions[1,1], Positions[2,0]);
			
			bool isWinning = diagonal1 || diagonal2;
			return isWinning;
		}	
	}
}