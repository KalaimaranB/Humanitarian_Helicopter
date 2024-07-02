using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseText : MonoBehaviour
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
        gameObject.GetComponent<Text>().text = (sceneControl.NumOfHouses-sceneControl.NumOfFinishedHouse).ToString() + " Houses Left";
    }
}
