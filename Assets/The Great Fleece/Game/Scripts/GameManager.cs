using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Game Manager is NULL");
            }
            return _instance;
        }
    }

    public bool HasCard{get; set;}
    public GameObject _introCutscene;
    public Transform _activeCam;
    public Player _player;

    private void Awake()
    {
        _instance = this;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Camera.main.transform.position = _activeCam.position;
            Camera.main.transform.rotation = _activeCam.rotation;
            _player.gameObject.SetActive(true);
            AudioManager.Instance.gameObject.SetActive(true);
            _introCutscene.SetActive(false);
        }
    }

}
