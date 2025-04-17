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
    private float _time;

    [SerializeField]
    private TMP_Text _timer;

    public bool playerLost = false;

    public bool playerWon = false;

    [SerializeField]
    private TMP_Text _wonText;

    [SerializeField]
    private TMP_Text _loseText;

    private Coroutine _wonRoutine;

    private Coroutine _loseRoutine;
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
        Timer();
        UpdateScore();
        UpdateEnemies();

        if(playerLost == true)
        {
            _loseRoutine = StartCoroutine(PlayerLost());
        }

        if(playerWon == true)
        {
            _wonRoutine = StartCoroutine(PlayerWon());
        }
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

    private void Timer()
    {
        _time = GameManager.Instance._time;
        int _minutes = Mathf.FloorToInt(_time / 60);
        int _seconds = Mathf.FloorToInt(_time % 60);
        _timer.text = string.Format("{0:00}:{1:00}", _minutes, _seconds);
    }

    IEnumerator PlayerLost()
    {
            _loseText.gameObject.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            _loseText.gameObject.SetActive(false);
            yield return new WaitForSeconds(2.0f);
            _loseText.gameObject.SetActive(true);
    }

    IEnumerator PlayerWon()
    {
            Debug.Log("Winner");
            _wonText.gameObject.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            _wonText.gameObject.SetActive(false);
            yield return new WaitForSeconds(2.0f);
            _wonText.gameObject.SetActive(true);
    }
}