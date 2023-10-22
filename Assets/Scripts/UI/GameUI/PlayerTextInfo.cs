using Scripts.Players;
using TMPro;
using UnityEngine;

namespace Scripts.UI
{
    public class PlayerTextInfo : BaseUIElement
    {
        [SerializeField] private TMP_Text _playerName;
        [SerializeField] private TMP_Text _playerScore;

        private IPlayer  _player;
        
        public void Init(IPlayer player)
        {
            _player = player;
            _playerName.text = _player.PlayerTag.ToString();
        }

        public override UIGroup UIGroup => UIGroup.GameUI;

        public override void UpdateUIVisual()
        {
            _playerScore.text = _player.Score.ToString();
        }
    }
}