using TickTackToe.Tables;
using TickTackToe.View.Cells;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace TickTackToe.View
{
	public class BoardView3X3 : MonoBehaviour
	{
		public struct Ctx
		{
			public ReactiveCommand<Position> clickedOnCell;
			public ReactiveCommand<ChangeSpriteCellView> changeCellState;
			public Table3X3 table3X3;
		}
		
        private Ctx _ctx;

		[SerializeField] private RowOfCells[] _rows = new RowOfCells[3];
		public void Init(Ctx ctx)
		{
			_ctx = ctx;
			
			_ctx.changeCellState.Subscribe(_ =>
			{
				_rows[_.Row].Column[_.Column].ChangeSprite(_.Sprite);
			});
			
			AddListenersToButtons();
		}

		private void AddListenersToButtons()
		{
			_rows[0].Column[0].Button.onClick.AddListener(() => _ctx.clickedOnCell.Execute(_ctx.table3X3.Positions[0,0]));
			_rows[0].Column[1].Button.onClick.AddListener(() => _ctx.clickedOnCell.Execute(_ctx.table3X3.Positions[0,1]));
			_rows[0].Column[2].Button.onClick.AddListener(() => _ctx.clickedOnCell.Execute(_ctx.table3X3.Positions[0,2]));
			_rows[1].Column[0].Button.onClick.AddListener(() => _ctx.clickedOnCell.Execute(_ctx.table3X3.Positions[1,0]));
			_rows[1].Column[1].Button.onClick.AddListener(() => _ctx.clickedOnCell.Execute(_ctx.table3X3.Positions[1,1]));
			_rows[1].Column[2].Button.onClick.AddListener(() => _ctx.clickedOnCell.Execute(_ctx.table3X3.Positions[1,2]));
			_rows[2].Column[0].Button.onClick.AddListener(() => _ctx.clickedOnCell.Execute(_ctx.table3X3.Positions[2,0]));
			_rows[2].Column[1].Button.onClick.AddListener(() => _ctx.clickedOnCell.Execute(_ctx.table3X3.Positions[2,1]));
			_rows[2].Column[2].Button.onClick.AddListener(() => _ctx.clickedOnCell.Execute(_ctx.table3X3.Positions[2,2]));
		}

		private void ChangeButtonSprite(Sprite sprite, int row, int column)
		{
			_rows[row].Column[column].GetComponent<Image>().sprite = sprite;
		}

	}
}