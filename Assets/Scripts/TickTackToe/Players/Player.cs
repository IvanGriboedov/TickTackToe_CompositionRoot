using TickTackToe.Marks;

namespace TickTackToe.Players
{
	public class Player
	{
		public Mark PMark => _pMark;
		private readonly Mark _pMark;

		public Player(Mark pMark)
		{
			_pMark = pMark;
		}
	}
}