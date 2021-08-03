using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLookAtPlayer : MonoBehaviour
{
    public Transform _target;

    void Update()
    {
        transform.LookAt(_target);
    }
}
