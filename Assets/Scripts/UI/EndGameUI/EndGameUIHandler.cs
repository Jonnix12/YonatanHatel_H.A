using Scripts.Managers;
using TMPro;
using UnityEngine;

namespace Scripts.UI
{
    public class EndGameUIHandler : BaseUIElement
    {
        [SerializeField] private TMP_Text _winnerName;
        public override UIGroup UIGroup => UIGroup.EndGameUI;

        public override void Show()
        {
            base.Show();
            _winnerName.text = ScoreHandler.Winner.PlayerTag.ToString();
        }

        public override void UpdateUIVisual()
        {
                
        }
    }
}


