using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject Player;
    private Vector3 Offset = new Vector3(0,0,-10);

    private GameObject SceneControl;
    private SceneController sceneControl;

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
            Player = sceneControl.CurrentPlayer;
            transform.position = Player.transform.position + Offset;
        }
    }
}
