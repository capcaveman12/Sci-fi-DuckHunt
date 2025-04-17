using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int EnemiesSpawned;

    [SerializeField]
    public float SpawnRate;

    [SerializeField]
    public int MaxEnemies;

    public int EnemiesInScene;

    [SerializeField]
    private GameObject _enemy;

    [SerializeField]
    private Transform _startPoint;

    private static SpawnManager _instance;
    public static SpawnManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Spawn manager missing");
            }

            return _instance;
        }
    }

    private void Start()
    {
        PullEnemy();
        SpawnRate = 10.0f;
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        EnemiesInScene = PoolManager.Instance.activeEnemies;
    }

    public IEnumerator SpawnEnemy()
    {
        while (GameManager.Instance.GameIsRunning == true)
        {
            yield return new WaitForSeconds(SpawnRate);
            SpawnRate = 10.0f;
            PullEnemy();
            

        }
    }

    private void PullEnemy()
    {
        _enemy = PoolManager.Instance.RequestEnemy();
        _enemy.transform.position = _startPoint.position;
    }
}
