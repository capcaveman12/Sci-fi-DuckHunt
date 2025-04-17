using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private List<GameObject> _enemyPool;

    [SerializeField]
    public List<GameObject> _activeEnemyList;

    [SerializeField]
    int _enemiesInList = 5;

    [SerializeField]
    GameObject _startingPoint;

    [SerializeField]
    GameObject _enemyContainer;

    public int activeEnemies = 0;

    private static PoolManager _instance;
    public static PoolManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("_instance is null");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        activeEnemies = _activeEnemyList.Count;
    }

    private void Start()
    {
        _enemyPool = GenerateEnemies(_enemiesInList);
    }

    List<GameObject> GenerateEnemies(int amountofenemies)
    {
        for(int i= 0; i < amountofenemies; i++)
        {
            GameObject enemy = Instantiate(_enemyPrefab);
            enemy.transform.parent = _enemyContainer.transform;
            enemy.SetActive(false);
            _enemyPool.Add(enemy);
        }
       
        return _enemyPool;
    }

    public GameObject RequestEnemy()
    {
        foreach(var enemy in _enemyPool)
        {
            if(enemy.activeInHierarchy == false)
            {
                enemy.SetActive(true);
                enemy.transform.position = _startingPoint.transform.position;
                _activeEnemyList.Add(enemy);
                return enemy;
            }
        }

        GameObject newEnemy = Instantiate(_enemyPrefab);
        newEnemy.transform.parent = _enemyContainer.transform;
        newEnemy.SetActive(true);
        _enemyPool.Add(newEnemy);
        _activeEnemyList.Add(newEnemy);

        return newEnemy;
    }

    /*public void SubtractEnemy()
    {
        activeEnemies -= 1;
    }*/
}
