using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    [SerializeField]
    Transform _waypoint;

    [SerializeField]
    NavMeshAgent _agent;

    //int _index;
    // Start is called before the first frame update
    void Start()
    {
        //_index = Random.Range(0, _waypoints.Count);

        _agent.SetDestination(_waypoint.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
