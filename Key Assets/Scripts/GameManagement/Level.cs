using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public string LevelName;
    public GameObject LockedSign;
    public int LevelNum;


    private GameManagement gm;

    private void Start()
    {
        gm = GameObject.FindObjectOfType<GameManagement>();
    }
    // Update is called once per frame
    void Update()
    {
        if (gm.gameLevels[LevelNum-1].status == GameManagement.GameLevel.levelStatus.Locked)
        {
            LockedSign.SetActive(true);
        }
        if (gm.gameLevels[LevelNum-1].status == GameManagement.GameLevel.levelStatus.Unlocked || gm.gameLevels[LevelNum-1].status == GameManagement.GameLevel.levelStatus.Complete)
        {
            LockedSign.SetActive(false);
        }
    }

    public void OnMouseDown()
    {
        GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>().LoadLevel(LevelName);
    }
}
