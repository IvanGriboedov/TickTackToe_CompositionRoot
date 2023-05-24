using UnityEngine;

namespace TickTackToe
{
	[CreateAssetMenu(menuName = "Create CellSpriteData", fileName = "ScriptableObject/CellSpriteData")]
	public class CellSpriteData : ScriptableObject
	{
		[SerializeField] private Sprite _xSprite;
		[SerializeField] private Sprite _oSprite;
		 
		[SerializeField] private Sprite _xWinSprite;
		[SerializeField] private Sprite _oWinSprite;
		 
		[SerializeField] private Sprite _emptySprite;

		public Sprite XSprite => _xSprite;

		public Sprite OSprite => _oSprite;

		public Sprite XWinSprite => _xWinSprite;

		public Sprite OWinSprite => _oWinSprite;

		public Sprite EmptySprite => _emptySprite;
	}
	
}