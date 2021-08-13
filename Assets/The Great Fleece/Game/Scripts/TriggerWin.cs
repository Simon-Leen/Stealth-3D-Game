using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWin : MonoBehaviour
{
    public GameObject _cutsceen;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(GameManager.Instance.HasCard == true)
            {
                _cutsceen.SetActive(true);
            }
            else
            {
                Debug.Log("Need the KeyCard");
            }
        }
    }
}
