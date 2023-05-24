using TickTackToe.Board;
using TickTackToe.Marks;
using TickTackToe.Tables;

namespace TickTackToe.Players
{
	public class BotRandom
	{
		private readonly GameBoard3X3 _board3X3;
		private readonly Table3X3 _table3X3;
		private readonly GameMarks _gameMarks;

		public BotRandom(GameBoard3X3 board3X3, Table3X3 table3X3, GameMarks gameMarks)
		{
			_board3X3 = board3X3;
			_table3X3 = table3X3;
			_gameMarks = gameMarks;
		}

		public Position Turn()
		{
			if (!_board3X3.HasEmptyCell())
				return _table3X3.Positions[0,0];
			
			while (true)
			{
				int rndRow = UnityEngine.Random.Range(0, 3);
				int rndColumn = UnityEngine.Random.Range(0, 3);

				Position rndPos = _table3X3.Positions[rndRow, rndColumn];
				
				Cell cell = _board3X3.Board[rndPos];
				if (cell.Mark == _gameMarks.EmptyMark)
				{
					return rndPos;
				}
			}

		}
		
	}
}