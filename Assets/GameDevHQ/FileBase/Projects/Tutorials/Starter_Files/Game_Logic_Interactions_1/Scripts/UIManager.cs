using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public int EnemiesSpawned;

    [SerializeField]
    public int SpawnRate = 1;

    [SerializeField]
    public int MaxEnemies;

    public int EnemiesInScene;

    [SerializeField]
    private GameObject _enemy;

    [SerializeField]
    private Transform _startPoint;

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

    private void Awake()
    {
        _instance = this;
    }
}