using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InsectNavMesh : MonoBehaviour
{

    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;

    // Changer en sous fonction triggerable
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        navMeshAgent.destination = movePositionTransform.position;
    }

}
