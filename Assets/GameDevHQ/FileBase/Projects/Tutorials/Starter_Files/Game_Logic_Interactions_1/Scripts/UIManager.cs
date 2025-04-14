using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreTxt;

    public int score;

    private static UIManager _instance;
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
        UpdateScore();
    }

    private void UpdateScore()
    {
        score = GameManager.Instance.score;
        scoreTxt.text = "Score: " + score.ToString();
    }
}