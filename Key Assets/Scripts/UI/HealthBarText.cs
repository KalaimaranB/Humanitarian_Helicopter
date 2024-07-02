﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarText : MonoBehaviour
{
    private GameObject SceneControl;
    private SceneController sceneControl;
    private GameObject CurrentPlayer;
    // Start is called before the first frame update
    void Start()
    {
        SceneControl = GameObject.FindWithTag("SceneController");
        sceneControl = SceneControl.GetComponent<SceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneControl.Win == false)
        {
            gameObject.GetComponent<Text>().text = "Health: " + Mathf.Round(sceneControl.CurrentPlayer.GetComponent<BasicHelicopterController>().CurrentHealth);
        }
    }
}
