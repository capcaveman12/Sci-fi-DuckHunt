using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreTxt;

    public int score;

    public TMP_Text enemies;

    private static UIManager _instance;

    [SerializeField]
    private float _time = 60f;

    [SerializeField]
    private TMP_Text _timer;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("spawn manager is missing");
            }

            return _instance;
        }
    }

    private void Start()
    {

    }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        _timer.text = _time.ToString();
        _time -= Time.deltaTime;
        UpdateScore();
        UpdateEnemies();
    }

    private void UpdateScore()
    {
        score = GameManager.Instance.score;
        scoreTxt.text = "Score: " + score.ToString();
    }

    private void UpdateEnemies()
    {
        enemies.text = "Enemies: " + GameManager.Instance.enemiesInScene.ToString();
    }
}