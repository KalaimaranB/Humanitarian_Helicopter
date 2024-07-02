using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonData : MonoBehaviour
{
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
        gameObject.GetComponent<Text>().text = sceneControl.LiveNumOfDragons.ToString() + " Dragons Left";
    }
}
