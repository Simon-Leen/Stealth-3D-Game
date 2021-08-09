using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;
    private Vector3 _target;
    public GameObject _coinPrefab;
    public AudioClip _coinClip;
    private bool _hasCoin = true;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(rayOrigin, out hitInfo))
            {
                _agent.SetDestination(hitInfo.point);
                _target = hitInfo.point;
                _anim.SetBool("Walk", true);
            }
        }
        if (Input.GetMouseButtonDown(1) && _hasCoin)
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                _anim.SetTrigger("Throw");
                _hasCoin = false;
                Instantiate(_coinPrefab, hitInfo.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(_coinClip, hitInfo.point);
                SendAIToCoin(hitInfo.point);
            }
        }

        float distance = Vector3.Distance(transform.position, _target);
        if(distance < 1.5f)
        {
            _anim.SetBool("Walk", false);
        }
    }

    void SendAIToCoin(Vector3 coinPos)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
        foreach(var guard in guards)
        {
            NavMeshAgent _currentAgent = guard.GetComponent<NavMeshAgent>();
            GuardAI _currentGuard = guard.GetComponent<GuardAI>();
            Animator _currentAnim = guard.GetComponent<Animator>();

            _currentGuard._coinTossed = true;
            _currentGuard._coinPos = coinPos;
            _currentAgent.SetDestination(coinPos);
            _currentAnim.SetBool("Walking", true);
        }
    }
}
