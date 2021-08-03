using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Transform _activeCam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Cam trigger");
            Camera.main.transform.position = _activeCam.position;
            Camera.main.transform.rotation = _activeCam.rotation;
        }
    }
}
