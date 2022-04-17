using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private CameraPositionController cameraPositionController;
    [SerializeField] private Transform playerSpawnPos;
    [SerializeField] private ScoreboardPanel scoreboardPanel;
    [SerializeField] private Text timeText;
    
    public static UnityEvent<bool> EndGameEvent;


    private float _startTime;
    private bool _gameIsPlaying;
    private void Awake()
    {
        EndGameEvent = new UnityEvent<bool>();
        EndGameEvent.AddListener(win =>
        {
            if (win)
            {
                WinGame();
            }
            else
            {
                LoseGame();
            }
        });
    }

    private void Start()
    {
        Player curPlayer = Instantiate(player.gameObject, playerSpawnPos.position, Quaternion.identity).GetComponent<Player>();
        curPlayer.Init(this);
        cameraPositionController.SetPlayer(curPlayer.transform);
    }

    public void StartGame()
    {
        _startTime = Time.time;
        _gameIsPlaying = true;
    }
    
    private void Update()
    {
        if (_startTime != 0)
        {
            timeText.text = Convert.ToString(Math.Round(Time.time - _startTime, 2));
        }
    }
    
    private void WinGame()
    {
        if (_gameIsPlaying)
        {
            _gameIsPlaying = false;
            float curTime = (float)Math.Round(Time.time - _startTime, 2);
            PlayerPrefs.SetFloat("LastTime", curTime);
            if ((PlayerPrefs.GetFloat("BestTime") > curTime) || (!PlayerPrefs.HasKey("BestTime")))
            {
                PlayerPrefs.SetFloat("BestTime", curTime);
            }

            scoreboardPanel.OpenScore(true);
        }
    }

    private void LoseGame()
    {
        if (_gameIsPlaying)
        {
            _gameIsPlaying = false;
            scoreboardPanel.OpenScore(false);
        }
    }
}
