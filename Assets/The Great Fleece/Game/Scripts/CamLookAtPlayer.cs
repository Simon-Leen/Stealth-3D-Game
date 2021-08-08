using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLookAtPlayer : MonoBehaviour
{
    public Transform _target;
    public Transform _startCamera;

    private void Start()
    {
        transform.position = _startCamera.position;
        transform.rotation = _startCamera.rotation;
    }

    void Update()
    {
        transform.LookAt(_target);
    }
}
