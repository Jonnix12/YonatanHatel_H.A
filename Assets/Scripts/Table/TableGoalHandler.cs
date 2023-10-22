using System;
using Scripts.Players;
using UnityEngine;

namespace Scripts.Table
{
    public class TableGoalHandler : MonoBehaviour
    {
        [SerializeField] private PlayerTag _scoreTo;
    
        public event Action<PlayerTag> GoalReached;
    
        private void OnTriggerEnter(Collider other) =>
            GoalReached?.Invoke(_scoreTo);
    }
}
