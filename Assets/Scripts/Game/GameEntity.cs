using CodeBase.Data;
using External.Framework;
using Prompt;
using TickTackToe;
using UniRx;
using UnityEngine;

namespace CodeBase.Game
{
    public class GameEntity : DisposableObject
    {
        public struct Ctx
        {
            public ContentProvider contentProvider;
            public RectTransform uiRoot;
        }
        
        private readonly Ctx _ctx;
        private TickTackToeEntity _tickTackToeEntity;
        private PromptEntity _promptEntity;
        
		private readonly ReactiveProperty<string> promptString = new ReactiveProperty<string>();
		private readonly ReactiveCommand _restartGame = new ReactiveCommand();
        
        public GameEntity(Ctx ctx)
        {
            _ctx = ctx;
            CreateTickTackToeEntity();
            CreatePromptEntity();
        }

        private void CreateTickTackToeEntity()
        {
            var tickTackToeCtx = new TickTackToeEntity.Ctx()
            {
                contentProvider = _ctx.contentProvider,
                uiRoot = _ctx.uiRoot,
                promptString = promptString,
                restartGame = _restartGame
            };
            _tickTackToeEntity = new TickTackToeEntity(tickTackToeCtx);
            AddToDisposables(_tickTackToeEntity);
        }

        private void CreatePromptEntity()
        {
            var gameOverContext = new PromptEntity.Ctx()
            {
                contentProvider = _ctx.contentProvider,
                uiRoot = _ctx.uiRoot,
                promptString = promptString,
                restartGame = _restartGame
            };
            _promptEntity = new PromptEntity(gameOverContext);
            AddToDisposables(_promptEntity);
        }
        
    }
}