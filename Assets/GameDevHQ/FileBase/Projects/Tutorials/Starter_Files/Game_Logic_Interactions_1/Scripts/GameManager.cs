using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public bool GameIsRunning = false;

    [SerializeField]
    public int score = 0;

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
    }

    public int AddScore(int enemyScore)
    {
        score += enemyScore;

        return score;
    }
}
