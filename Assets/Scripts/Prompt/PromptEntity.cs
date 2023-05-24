using CodeBase.Data;
using External.Framework;
using UniRx;
using UnityEngine;

namespace Prompt
{
	public class PromptEntity : DisposableObject
	{
		private readonly Ctx _ctx;

		public struct Ctx
		{
			public ContentProvider contentProvider;
			public RectTransform uiRoot;
			public ReactiveProperty<string> promptString;
			public ReactiveCommand restartGame;
		}
		

		private PromptPm _pm;
		private PromptView _view;

		public PromptEntity(Ctx ctx)
		{
			_ctx = ctx;
			CreatePm();
			CreateView();
		}
		
		private void CreatePm()
		{
			var gameOverPmCtx = new PromptPm.Ctx()
			{
				promptString = _ctx.promptString,
				restartGame = _ctx.restartGame 
			};
			_pm = new PromptPm(gameOverPmCtx);
			AddToDisposables(_pm);
		}

		private void CreateView()
		{
			_view = Object.Instantiate(_ctx.contentProvider._promptView, _ctx.uiRoot);
			_view.Init(new PromptView.Ctx()
			{
				promptString = _ctx.promptString,
				restartGame = _ctx.restartGame 
			});
		}

		protected override void OnDispose()
		{
			base.OnDispose();
			if (_view != null)
				Object.Destroy(_view.gameObject);
		}
	}
}