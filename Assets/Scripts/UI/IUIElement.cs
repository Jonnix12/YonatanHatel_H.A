namespace Scripts.UI
{
    public interface IUIElement
    {
        public UIGroup UIGroup { get;  }
        
        public void Show();
        
        public void Hide();
        
        public void UpdateUIVisual();
    }

    public enum UIGroup
    {
        GameUI,
        PauseUI,
        EndGameUI,
        MainMenuUI
    }
}