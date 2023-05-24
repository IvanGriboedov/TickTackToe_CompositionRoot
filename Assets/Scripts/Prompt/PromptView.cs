using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Prompt
{
	public class PromptView : MonoBehaviour
	{
		public struct Ctx
		{
			 public ReactiveProperty<string> promptString;
			 public ReactiveCommand restartGame;
		}

		[SerializeField] private TextMeshProUGUI _text;
		[SerializeField] private Button _restartButton;
		
		private Ctx _ctx;

		public void Init(Ctx ctx)
		{
			_ctx = ctx;
			_ctx.promptString.Subscribe(PrintText);
			AddListenerToButton();
		}
		private void AddListenerToButton()
		{
			_restartButton.onClick.AddListener(() => _ctx.restartGame.Execute());
		}

		private void PrintText(string promptedText)
		{
			_text.text = promptedText;
		}


	}
}