using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCams : MonoBehaviour
{
    public GameObject _cutscene;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            MeshRenderer _renderer = GetComponent<MeshRenderer>();
            Color _color = new Color(0.3f, 0.1f, 0.1f, 0.3f);
            _renderer.material.SetColor("_TintColor", _color);

            Animator _anim = GetComponentInParent<Animator>();
            _anim.enabled = false;

            StartCoroutine("DelayCutscene");
        }
    }

    IEnumerator DelayCutscene()
    {
        yield return new WaitForSeconds(0.5f);
        _cutscene.SetActive(true);
    }
}
