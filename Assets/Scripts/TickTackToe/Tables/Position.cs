namespace TickTackToe.Tables
{
	public class Position
	{
		private readonly int _row;
		private readonly int _column;

		public int Row => _row;
		public int Column => _column;

		public Position(int row, int column)
		{
			_row = row;
			_column = column;
		}
	}
}