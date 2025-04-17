using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public bool GameIsRunning = false;

    [SerializeField]
    public int score = 0;

    public int enemiesInScene;

    [SerializeField]
    public float _time = 60f;

    public int scoreToWin = 500;

    private Coroutine _runTimer;

    [SerializeField]
    bool _timerIsRunning = true;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Game Manager is missing");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        GameIsRunning = true;
        SpawnManager.Instance.StartCoroutine("SpawnEnemy");
        _runTimer = StartCoroutine(Timer());
    }

    private void Update()
    {
        enemiesInScene = SpawnManager.Instance.EnemiesInScene;

        if(_time <= 1.0f)
        {
            TimeUp();
        }

        if(score == scoreToWin)
        {
            Win();
        }
    }

    public int AddScore(int enemyScore)
    {
        score += enemyScore;

        return score;
    }

    public IEnumerator Timer()
    {
        while(_timerIsRunning == true)
        {
            yield return new WaitForSeconds(1.0f);
            _time --;
        }
    }

    private void TimeUp()
    {
        _timerIsRunning = false;
        UIManager.Instance.playerLost = true;
        GameIsRunning = false;
    }

    private void Win()
    {
        _timerIsRunning = false;
        UIManager.Instance.playerWon = true;
        GameIsRunning = false;
    }
}
