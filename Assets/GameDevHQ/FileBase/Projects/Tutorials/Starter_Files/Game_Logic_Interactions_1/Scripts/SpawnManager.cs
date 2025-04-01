using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
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

    private SpawnManager _instance;
    public SpawnManager Instance
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

    private void Awake()
    {
        _instance = this;
    }

    IEnumerator SpawnEnemy()
    {
        while (GameManager.Instance.GameIsRunning == true)
        {
            yield return new WaitForSeconds(SpawnRate);
            PullEnemy();
            

        }
    }

    private void PullEnemy()
    {
        _enemy = PoolManager.Instance.RequestEnemy();
        _enemy.transform.position = _startPoint.position;
    }
}
