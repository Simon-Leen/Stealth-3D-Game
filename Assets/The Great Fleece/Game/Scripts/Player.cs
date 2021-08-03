using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

            if(Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("Hit: " + hitInfo.point);
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = hitInfo.point;

                _agent.SetDestination(hitInfo.point);
            }
        }
    }
}
