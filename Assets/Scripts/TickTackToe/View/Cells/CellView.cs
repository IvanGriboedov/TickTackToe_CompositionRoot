using UnityEngine;
using UnityEngine.UI;

namespace TickTackToe.View.Cells
{
	[RequireComponent(typeof(Button),typeof(Image))]
	public class CellView :MonoBehaviour
	{

		private Button _button;
		private Image _image;

		public Button Button => _button;

		private void Awake()
		{
			_button = GetComponent<Button>();
			_image = GetComponent<Image>();
		}

		public void ChangeSprite(Sprite newSprite)
		{
			_image.sprite = newSprite;
		}
		
		
	}
}