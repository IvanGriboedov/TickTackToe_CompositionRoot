using External.Framework;
using UniRx;

namespace Prompt
{
	public class PromptPm : DisposableObject
	{
		public struct Ctx
		{
			 public ReactiveProperty<string> promptString;
			 public ReactiveCommand restartGame;
		}

		private Ctx _ctx;

		public PromptPm(Ctx ctx)
		{
			_ctx = ctx;
		}
		
	}
}