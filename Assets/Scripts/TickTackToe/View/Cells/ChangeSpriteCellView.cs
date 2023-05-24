using UnityEngine;

namespace TickTackToe.View.Cells
{
	public struct ChangeSpriteCellView
	{
		public Sprite Sprite;
		public int Row;
		public int Column;

		public ChangeSpriteCellView(Sprite sprite, int row, int column)
		{
			Sprite = sprite;
			Row = row;
			Column = column;
		}
	}
}