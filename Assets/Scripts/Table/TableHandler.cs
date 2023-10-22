using System;
using Scripts.Players;
using UnityEngine;

namespace Scripts.Table
{
    public class TableHandler : MonoBehaviour
    {
        public event Action<PlayerTag> OnPlayerScore;
        
        [SerializeField] private Transform _pacResetPosition;

        [SerializeField] private PacHandler _pacAsset;
        
        [SerializeField] private TableGoalHandler _blueGoal;
        [SerializeField] private TableGoalHandler _redGoal;

        private PacHandler _pacHandler;

        public static Vector3 PacPosition { get; private set; }        

        public static PlayerTag PacSide { get; private set; }
        
        private void Awake()
        {
            _blueGoal.GoalReached += PlayerScore;
            _redGoal.GoalReached += PlayerScore;
        }

        private void OnDestroy()
        {
            _blueGoal.GoalReached -= PlayerScore;
            _redGoal.GoalReached -= PlayerScore;
        }

        private void Start()
        {
            _pacHandler = Instantiate(_pacAsset);
            _pacHandler.ResetPac(_pacResetPosition.position);
        }

        private void Update()
        {
            PacPosition = _pacHandler.transform.position;
            PacSide = _pacHandler.transform.position.z < 0 ? PlayerTag.Blue : PlayerTag.Red;
        }

        private void PlayerScore(PlayerTag tag)
        {
            switch (tag)
            {
                case PlayerTag.Blue:
                    OnPlayerScore?.Invoke(tag);
                    break;
                case PlayerTag.Red:
                    OnPlayerScore?.Invoke(tag);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tag), tag, null);
            }
            
            ResetTable();
        }

        public void ResetTable()
        {
            _pacHandler.ResetPac(_pacResetPosition.position);
        }
    }
}