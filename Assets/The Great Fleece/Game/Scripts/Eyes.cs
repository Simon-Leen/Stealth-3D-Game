using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    public GameObject gameOverCutScene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameOverCutScene.SetActive(true);
        }
    }
}
