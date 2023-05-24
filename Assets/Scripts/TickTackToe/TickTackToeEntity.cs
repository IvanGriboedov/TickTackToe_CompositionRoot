using CodeBase.Data;
using External.Framework;
using TickTackToe.PresenterModel;
using TickTackToe.Tables;
using TickTackToe.View;
using TickTackToe.View.Cells;
using UniRx;
using UnityEngine;

namespace TickTackToe
{
	public class TickTackToeEntity : DisposableObject
	{
		private readonly Ctx _ctx;

		public struct Ctx
		{
			public ContentProvider contentProvider;
			public RectTransform uiRoot;
			public ReactiveProperty<string> promptString;
			public ReactiveCommand restartGame;
		}
		
		private readonly ReactiveCommand<Position> _clickedOnCell = new ReactiveCommand<Position>();
		private readonly ReactiveCommand<ChangeSpriteCellView> _changeCellState = new ReactiveCommand<ChangeSpriteCellView>();

		private BoardPm _pm;
		private BoardView3X3 _view3X3;
		private readonly TickTackToe3X3 _tickTackToe3X3;
		private readonly Table3X3 _table3X3;

		public TickTackToeEntity(Ctx ctx)
		{
			_ctx = ctx;
			_table3X3 = new Table3X3();
			
			CreatePm();
			CreateView();
		}
		
		private void CreatePm()
		{
			var boardPmCtx = new BoardPm.Ctx()
			{
				clickedOnCell = _clickedOnCell,
				changeCellState = _changeCellState,
				promptString = _ctx.promptString,
				restartGame =  _ctx.restartGame,
				contentProvider = _ctx.contentProvider,
				table3X3 = _table3X3
			};
			_pm = new BoardPm(boardPmCtx);
			AddToDisposables(_pm);
		}

		private void CreateView()
		{
			_view3X3 = Object.Instantiate(_ctx.contentProvider._boardView3X3, _ctx.uiRoot);
			_view3X3.Init(new BoardView3X3.Ctx()
			{
				clickedOnCell = _clickedOnCell,
				changeCellState = _changeCellState,
				table3X3 = _table3X3
			});
		}

		protected override void OnDispose()
		{
			base.OnDispose();
			if (_view3X3 != null)
				Object.Destroy(_view3X3.gameObject);
		}
	}

}