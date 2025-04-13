using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    private enum AIState
    {
        Running,
        Hiding,
        Death
    }

    [SerializeField]
    private AIState _currentState;

    [SerializeField]
    List<GameObject> _waypoints;

    [SerializeField]
    NavMeshAgent _agent;

    [SerializeField]
    private Animator _enemyAnimator;

    [SerializeField]
    int _index = 0;

    [SerializeField]
    GameObject _currentPoint;

    [SerializeField]
    float _seconds;

    [SerializeField]
    float _secMin;

    [SerializeField]
    float _secMax;

    [SerializeField]
    GameObject _startingPoint;

    private void OnEnable()
    {
        _currentPoint = _waypoints[_index];
        _agent.SetDestination(_currentPoint.transform.position);
        _agent = GetComponent<NavMeshAgent>();
        _enemyAnimator = GetComponent<Animator>();
        _currentState = AIState.Running;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case AIState.Running:
                _enemyAnimator.SetBool("Hiding", false);
                _enemyAnimator.SetFloat("Speed", _agent.speed);
                break;
            case AIState.Hiding:
                _enemyAnimator.SetBool("Hiding", true);
                 break;
            case AIState.Death:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Waypoint")
        {
            Invoke("Hide", 1.0f);
        }
        else if(other.tag == "End")
        {
            Recycle();
        }
    }

    private void Hide()
    {
        _seconds = Random.Range(_secMin, _secMax);
        _agent.ResetPath();
        _agent.isStopped = true;
        transform.Rotate(0, -90, 0);
        _currentState = AIState.Hiding;

        if(_index <= _waypoints.Count)
        {
            _index += 1;
            _currentPoint = _waypoints[_index];
            Invoke("MoveAgent", _seconds);
        }
        else if(_index > _waypoints.Count)
        {
            _index = _waypoints.Count;
        }
    }

    private void MoveAgent()
    {
        transform.Rotate(0, 0, 0);
        _currentState = AIState.Running;
        _agent.SetDestination(_currentPoint.transform.position);
        _agent.isStopped = false;
    }

    private void Recycle()
    {
        this.gameObject.SetActive(false);
        transform.position = _startingPoint.transform.position;
        _index = 0;
        _currentPoint = _waypoints[0];
    }










}
