using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
	[CreateAssetMenu(fileName = "PromptText", menuName = "ScriptableObject/PromptText")]
	public class PromptText : ScriptableObject
	{
		public string TurnPlayerX => _turnPlayerX;

		public string TurnPlayerO => _turnPlayerO;

		public string WinPlayerX => _winPlayerX;

		public string WinPlayerO => _winPlayerO;

		public string Draw => _draw;

		[SerializeField] private string _turnPlayerX;
		[SerializeField] private string _turnPlayerO;
		[SerializeField] private string _winPlayerX;
		[FormerlySerializedAs("_windPlayerO")] [SerializeField] private string _winPlayerO;
		[SerializeField] private string _draw;

	}
}