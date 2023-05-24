using System;
using CodeBase.Data;
using External.Framework;
using Game;
using TickTackToe.Board;
using TickTackToe.Marks;
using TickTackToe.Players;
using TickTackToe.Tables;
using TickTackToe.View.Cells;
using UniRx;

namespace TickTackToe.PresenterModel
{
	public class BoardPm : DisposableObject
	{
		public struct Ctx
		{
			public Table3X3 table3X3;
			public ReactiveCommand<Position> clickedOnCell;
			
			public ReactiveProperty<string> promptString;
			public ReactiveCommand restartGame;
			
			public ReactiveCommand<ChangeSpriteCellView> changeCellState;
			public ContentProvider contentProvider;
		}	
		
		private readonly Ctx _ctx;

		private readonly GameMarks _gameMarks;

		private bool _isPlayerFirst = true;

		private Mark _winnerMark;
        
		private readonly TickTackToe3X3 _tickTackToe3X3;
		private readonly BotRandom _randomBot;
		
		public BoardPm(Ctx ctx)
		{
			_ctx = ctx;
			_gameMarks = new GameMarks();
			_tickTackToe3X3 = new TickTackToe3X3(_ctx.table3X3, _gameMarks);
			_randomBot = new BotRandom(_tickTackToe3X3.GameBoard3X3, _ctx.table3X3, _gameMarks);
			
			_ctx.clickedOnCell.Subscribe(TickGame);
			_ctx.restartGame.Subscribe(RestartGame);	
			_tickTackToe3X3.GameOver.Subscribe(GameOverShow);

			AddToDisposables(_ctx.clickedOnCell.Subscribe(TickGame));
			AddToDisposables(_ctx.restartGame.Subscribe(RestartGame));
			AddToDisposables(_tickTackToe3X3.GameOver.Subscribe(GameOverShow));
		}

		private void TickGame(Position pos)
		{
			if (_tickTackToe3X3.IsGameOver)
				return;

			//player Turn
			if (!_tickTackToe3X3.GameBoard3X3.Board[pos].Mark.Equals(_gameMarks.EmptyMark))
				return;

			_tickTackToe3X3.Turn(pos);
			DrawBoard(_tickTackToe3X3);

			//bot turn
			Position rndPos = _randomBot.Turn();
			_tickTackToe3X3.Turn(rndPos);

			DrawBoard(_tickTackToe3X3);

			if (_tickTackToe3X3.IsGameOver)
				DrawWinningCells(_tickTackToe3X3, _winnerMark);
		}

		private void RestartGame(Unit unit)
		{
			_ctx.promptString.Value = string.Empty;
			_tickTackToe3X3.RestartGame();
			DrawBoard(_tickTackToe3X3);

			_isPlayerFirst = !_isPlayerFirst;
			if (_isPlayerFirst)
				return;

			//bot first turn
			Position rndPos = _randomBot.Turn();
			_tickTackToe3X3.Turn(rndPos);
			DrawBoard(_tickTackToe3X3);
		}

		private void GameOverShow(Mark winner)
		{
			PromptText promptText = _ctx.contentProvider.PromptText;
			DrawWinningCells(_tickTackToe3X3, winner);
			_winnerMark = winner;
		}

		private void DrawBoard(TickTackToe3X3 tickTackToe3X3)
		{
			foreach ((Position position, Cell cell) in tickTackToe3X3.GameBoard3X3.Board)
			{
				Mark mark = cell.Mark;
				int column = position.Column;
				int row = position.Row;
				
				CellSpriteData spriteData= _ctx.contentProvider.CellSpriteData;
				
				if (mark.Equals(_gameMarks.XMark))
				{
					_ctx.changeCellState.Execute(new ChangeSpriteCellView(spriteData.XSprite, row, column));
				}
				else if(mark.Equals(_gameMarks.OMark))
				{
					_ctx.changeCellState.Execute(new ChangeSpriteCellView(spriteData.OSprite, row, column));
				}
				else if(mark.Equals(_gameMarks.EmptyMark))
				{
					_ctx.changeCellState.Execute(new ChangeSpriteCellView(spriteData.EmptySprite, row, column));
				}
			}
		}
		private void DrawWinningCells(TickTackToe3X3 tickTackToe3X3, Mark winner)
		{
			CellSpriteData spriteData= _ctx.contentProvider.CellSpriteData;
			foreach (Position pos in tickTackToe3X3.Referee3X3.WinningPositions)
			{
				int column = pos.Column;
				int row = pos.Row;
				
				if (winner.Equals(_gameMarks.XMark))
				{
				    _ctx.changeCellState.Execute(new ChangeSpriteCellView(spriteData.XWinSprite, row, column));
				    _ctx.promptString.Value = _ctx.contentProvider.PromptText.WinPlayerX;
				}
				else if(winner.Equals(_gameMarks.OMark))
				{
					_ctx.changeCellState.Execute(new ChangeSpriteCellView(spriteData.OWinSprite, row, column));
				    _ctx.promptString.Value = _ctx.contentProvider.PromptText.WinPlayerO;
				}
			}
		}
		

	}
}
