namespace Scripts.Players
{
    public interface IPlayer
    {
        public PlayerTag PlayerTag { get; }
        public int Score { get; }
        
        public void AddScore(int score);
        public void ResetScore();
    }
    
    public enum PlayerTag
    {
        Blue,
        Red
    }
}