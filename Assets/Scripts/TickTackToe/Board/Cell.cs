using TickTackToe.Marks;
using TickTackToe.Tables;

namespace TickTackToe.Board
{
	public class Cell
	{
		private readonly Position _position;
		private readonly Mark _mark;

		public Mark Mark => _mark;

		public Cell(Position position, Mark mark)
		{
			_position = position;
			_mark = mark;
		}
	}
}
