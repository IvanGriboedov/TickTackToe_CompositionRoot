using Game;
using Prompt;
using TickTackToe;
using TickTackToe.View;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Data
{
    [CreateAssetMenu(fileName = "ContentProvider", menuName = "GameData/ContentProvider")]
    public class ContentProvider : ScriptableObject
    {
       [FormerlySerializedAs("_boardView")] public BoardView3X3 _boardView3X3;
       public PromptView _promptView;
       public CellSpriteData CellSpriteData;
       public PromptText PromptText;
    }
}