namespace TickTackToe.Marks
{
	public class GameMarks
	{
		private readonly Mark _xMark;
		private readonly Mark _oMark;
		private readonly Mark _emptyMark;

		public Mark XMark => _xMark;
		public Mark OMark => _oMark;
		public Mark EmptyMark => _emptyMark;

		public GameMarks()
		{
			_xMark = new Mark('x');
			_oMark = new Mark('o');
			_emptyMark = new Mark('-');
		}
	}
}
