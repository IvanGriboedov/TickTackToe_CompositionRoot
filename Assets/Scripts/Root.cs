using CodeBase.Data;
using CodeBase.Game;
using External.Framework;
using UnityEngine;

namespace CodeBase
{
    public class Root : DisposableObject
    {
        public struct Ctx
        {
            public ContentProvider contentProvider;
            public RectTransform uiRoot;
        }
        private readonly Ctx _ctx;
        
        public Root(Ctx ctx)
        {
            _ctx = ctx;
            CreateGameEntity();
        }

    
        private void CreateGameEntity()
        {
            var ctx = new GameEntity.Ctx
            {
                contentProvider = _ctx.contentProvider,
                uiRoot = _ctx.uiRoot
            };
        
            AddToDisposables(new GameEntity(ctx));
        }
    }
}