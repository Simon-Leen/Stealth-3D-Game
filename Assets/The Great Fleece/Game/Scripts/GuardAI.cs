using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> _wayPoints;
    [SerializeField]private int _currentTarget;
    private NavMeshAgent _agent;
    private bool _reverse;
    private bool _targetReached;
    private Animator _anim;
    public bool _coinTossed;
    public Vector3 _coinPos;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if(_agent == null)
        {
            Debug.LogError("Agent null in Guard");
        }
        _anim = GetComponent<Animator>();
        if(_anim == null)
        {
            Debug.LogError("Anim is null in Guard");
        }
     }

    void Update()
    {
        if (_wayPoints.Count > 0 && _wayPoints[_currentTarget] != null && _coinTossed == false)
        {
            _agent.SetDestination(_wayPoints[_currentTarget].position);
            
            float distance = Vector3.Distance(transform.position, _wayPoints[_currentTarget].position);

            if(distance < 1.0f && (_currentTarget == 0 || _currentTarget == _wayPoints.Count - 1))
            {
                if(_anim != null)
                {
                    _anim.SetBool("Walking", false);
                }
            }
            else
            {
                if (_anim != null)
                {
                    _anim.SetBool("Walking", true);
                }
            }

            if (distance < 1.0f && _targetReached == false && _wayPoints.Count > 1)
            {
                _targetReached = true;
                StartCoroutine(TargetDelay());
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, _coinPos);
            if(distance < 5f)
            {
                _anim.SetBool("Walking", false);
            }
        }
    }

    IEnumerator TargetDelay()
    {
        if (_currentTarget == 0 || _currentTarget == _wayPoints.Count - 1)
        {
            yield return new WaitForSeconds(3f);
        }
        if (_reverse)
        {
            _currentTarget--;
            if (_currentTarget == 0)
            {
                _reverse = false;
            }
        }
        else
        {
            _currentTarget++;
            if (_currentTarget == _wayPoints.Count -1)
            {
                _reverse = true;
            }
        }
        _targetReached = false;
    }
}
