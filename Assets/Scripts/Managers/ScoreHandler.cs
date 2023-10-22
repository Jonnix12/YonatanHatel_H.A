using System.Collections.Generic;
using Scripts.Players;
using UnityEngine;

namespace Scripts.Managers
{
    public class ScoreHandler
    {
        private readonly Dictionary<PlayerTag, IPlayer> _players;
        private readonly int _scoreToWin;

        public static Dictionary<PlayerTag, IPlayer> Players { get; private set; }
        public static IPlayer Winner { get; private set; }
        public ScoreHandler(int scoreToWin, params IPlayer[] players)
        {
            _players = new Dictionary<PlayerTag, IPlayer>();
            _scoreToWin = scoreToWin;
            
            foreach (var player in players)
                _players.Add(player.PlayerTag, player);
            
            Players = _players;
        }
        
        public void AddScoreToPlayer(PlayerTag  playerTag, int score)
        {
            if (!_players.TryGetValue(playerTag, out var player))
            {
                Debug.LogError($"Player with tag {playerTag} not found");
                return;
            }

            Debug.Log($"Add score to {playerTag}");
            player.AddScore(score);
        }
        
        
        public bool CheckWin(out IPlayer winner)
        {
            winner = null;
            
            foreach (var player in _players.Values)
            {
                if (player.Score < _scoreToWin) continue;

                winner = player;
                Winner = player;
                return true;
            }

            return false;
        }

        public void ResetScore()
        {
            foreach (var player in _players.Values)
                player.ResetScore();
        }
    }
}