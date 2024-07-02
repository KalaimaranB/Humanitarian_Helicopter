using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicControl : MonoBehaviour
{
    private GameObject GameManagement;
    private GameManagement gameManagement;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        GameManagement = GameObject.FindWithTag("GameManagement");
        gameManagement = GameManagement.GetComponent<GameManagement>();
        source = GetComponent<AudioSource>();
        source.volume = gameManagement.BackgroundMusicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        source.volume = gameManagement.BackgroundMusicVolume;
    }
}
