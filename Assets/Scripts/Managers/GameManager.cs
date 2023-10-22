using System;
using Scripts.Players;
using Scripts.Players.AI;
using Scripts.Players.Controllers;
using Scripts.Table;
using Scripts.UI;
using UnityEngine;

namespace Scripts.Managers
{
    public class GameManager : MonoBehaviour
{
    [SerializeField] private int _scoreToWin;
    
    [SerializeField] private TableHandler _tableHandler;

    [SerializeField] private PlayerController _bluePac;
    [SerializeField] private PlayerController _redPac;
    
    private ScoreHandler _scoreHandler;
    
    private Player _player;
    private AI _ai;

    private bool _inFocus;

    private bool _isAfterFirstFrame;

    private void Awake()
    {
        _tableHandler.OnPlayerScore += PlayerScore;

        _isAfterFirstFrame = false;
        
        _inFocus = false;

        _player = new Player(_bluePac);
        _ai = new AI(_redPac);
        
        _scoreHandler = new ScoreHandler(_scoreToWin,_player, _ai);
    }

    private void OnDestroy()
    {
        _tableHandler.OnPlayerScore -= PlayerScore;
    }

    private void Update()
    {
        if (!_isAfterFirstFrame)
        {
            _isAfterFirstFrame = true;
            UIManager.HidUIGroup(UIGroup.EndGameUI);
            UIManager.HidUIGroup(UIGroup.PauseUI);
            UIManager.HidUIGroup(UIGroup.GameUI);
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame();

        if (!_inFocus)
            return;
        
        _player.Update();
        _ai.Update();
    }

    private void FixedUpdate()
    {
        if (!_inFocus)
            return;
        
        _player.FixedUpdate();
        _ai.FixedUpdate();
    }

    private void OnValidate()
    {
        _tableHandler ??= FindObjectOfType<TableHandler>();
        
        ValidatePlayer(_bluePac, PlayerTag.Blue);
        ValidatePlayer(_redPac, PlayerTag.Red);
    }

    public void StartGame()
    {
        UIManager.HidUIGroup(UIGroup.MainMenuUI);
        UIManager.ShowUIGroup(UIGroup.GameUI,true);
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _inFocus = true;
    }

    public void StartNewGame()
    {
        _scoreHandler.ResetScore();
        _tableHandler.ResetTable();
        
        UIManager.HidUIGroup(UIGroup.EndGameUI);
        
        ResumeGame();
    }

    public void ResumeGame()
    {
        UIManager.ShowUIGroup(UIGroup.GameUI,true);
        UIManager.HidUIGroup(UIGroup.PauseUI);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _inFocus = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    private void PauseGame()
    {
        UIManager.HidUIGroup(UIGroup.GameUI);
        
        UIManager.ShowUIGroup(UIGroup.PauseUI);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _inFocus = false;
    }

    private void PlayerScore(PlayerTag playerTag)
    {
        _scoreHandler.AddScoreToPlayer(playerTag, 1);
        
        if (_scoreHandler.CheckWin(out var winner))
            PlayerWin(winner);
        
        UIManager.UpdateVisualUIGroup(UIGroup.GameUI);
    }

    private void PlayerWin(IPlayer player)
    {
        _inFocus = false;
        UIManager.ShowUIGroup(UIGroup.EndGameUI);
        Debug.Log($"{player.PlayerTag} as won!");
    }
    
    private void ValidatePlayer(PlayerController player,PlayerTag playerTag)
    {
        if (player is not null) return;
        
        Debug.LogWarning($"{playerTag} pac is null reference it in the inspector");
        var playerControllers = FindObjectsOfType<PlayerController>();

        foreach (var controller in playerControllers)
        {
            if (controller.PlayerTag != playerTag) continue;
            
            player = controller;
            return;
        }
        
        throw  new Exception($"{playerTag} pac not found");
    }
}   
}