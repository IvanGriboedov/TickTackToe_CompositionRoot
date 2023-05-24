using TickTackToe.Board;
using TickTackToe.Marks;
using TickTackToe.Players;
using TickTackToe.Tables;
using UniRx;

namespace TickTackToe
{
	public class TickTackToe3X3
	{
		private readonly GameBoard3X3 _gameBoard3X3;
		private readonly Table3X3 _table3X3;
		private readonly GameMarks _marks;

		public GameBoard3X3 GameBoard3X3 => _gameBoard3X3;

		private readonly Player _playerX;
		private readonly Player _playerO;

		private Player _currentPlayer;

		private readonly Referee3X3 _referee3X3;
		public Referee3X3 Referee3X3 => _referee3X3;

		public readonly ReactiveCommand<Mark> GameOver = new ReactiveCommand<Mark>();
		private bool _isGameOver = false;

		public bool IsGameOver => _isGameOver;

		public TickTackToe3X3(Table3X3 table, GameMarks marks)
		{
			_marks = marks;
			_table3X3 = table;
			_gameBoard3X3 = new GameBoard3X3(_marks, _table3X3);
			_referee3X3 = new Referee3X3(_gameBoard3X3, _table3X3);
			
			_playerX = new Player(_marks.XMark);
			_playerO = new Player(_marks.OMark);

			_currentPlayer = _playerX;
		}

		public void RestartGame()
		{
			_gameBoard3X3.RefreshBoard();
			_isGameOver = false;
			
			_currentPlayer = _playerX;
		}

		public void Turn(Position position)
		{
			if (_isGameOver)
				return;
			
			_gameBoard3X3.MarkBoard(_currentPlayer.PMark, position);
			FindWinner();

			if (NoOpenCells())
				return;

			SwapTurn();
			//CurrentPlayer = _currentPlayer.PlayerMark;
		}

		private void FindWinner()
		{
			bool isWinner = _referee3X3.CheckWinner(_currentPlayer.PMark);

			if (!isWinner)
				return;
			
			GameOver.Execute(_currentPlayer.PMark);
			_isGameOver = true;
		}
		
		private bool NoOpenCells()
		{
			bool hasEmptyCell = _gameBoard3X3.HasEmptyCell();
			
			if (hasEmptyCell)
				return false;
			
			GameOver.Execute(_marks.EmptyMark);
			_isGameOver = true;
			return true;

		}

		private void SwapTurn()
		{
			Player swapTo = _currentPlayer == _playerX ? _playerO : _playerX;
			_currentPlayer = swapTo;
		}
	}
}