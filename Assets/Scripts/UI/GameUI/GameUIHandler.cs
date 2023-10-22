using Scripts.Managers;
using Scripts.Players;
using UnityEngine;

namespace Scripts.UI
{
    public class GameUIHandler : BaseUIElement
    {
        [SerializeField] private PlayerTextInfo _leftPlayerTextInfo;
        [SerializeField] private PlayerTextInfo _rightPlayerTextInfo;

        private void Start()
        {
            _leftPlayerTextInfo.Init(ScoreHandler.Players[PlayerTag.Red]);
            _rightPlayerTextInfo.Init(ScoreHandler.Players[PlayerTag.Blue]);
        }
        
        public override UIGroup UIGroup => UIGroup.GameUI;
        
        public override void UpdateUIVisual()
        {
        }
    }
}