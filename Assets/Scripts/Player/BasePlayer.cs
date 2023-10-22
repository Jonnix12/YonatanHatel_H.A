using Scripts.Players.Controllers;

namespace Scripts.Players
{
    public abstract class BasePlayer : IPlayer
    {
        protected PlayerController  PlayerController { get; private set; }
        
        public PlayerTag PlayerTag { get; private set; }
        public int Score { get; private set; }

        protected BasePlayer(PlayerController playerController)
        {
            PlayerController = playerController;
            PlayerTag = PlayerController.PlayerTag;
        }
        
        public void AddScore(int score) =>
            Score += score;

        public void ResetScore()=>
            Score = 0;

        public abstract void Update();
        public abstract void FixedUpdate();
    }
}