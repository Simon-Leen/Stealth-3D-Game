using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKeyCard : MonoBehaviour
{
    public GameObject _cutscene;
    public Transform _activeCam;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _cutscene.SetActive(true);
            GameManager.Instance.HasCard = true;
            StartCoroutine("EndCutscene");
            Camera.main.transform.position = _activeCam.position;
            Camera.main.transform.rotation = _activeCam.rotation;
        }
    }
    IEnumerator EndCutscene()
    {
        yield return new WaitForSeconds(6f);
        _cutscene.SetActive(false);
    }
}
