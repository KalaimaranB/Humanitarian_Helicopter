using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Vector3 LeftBound;
    public Vector3 RightBound;
    public float Speed;

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
        if (gameObject.GetComponent<BasicDragonControl>().CurrentHealth > 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);

        }
        if (gameObject.transform.position.x <= LeftBound.x)
        {
            transform.rotation = Quaternion.Euler(0,90,0);
        }
        if (gameObject.transform.position.x >=RightBound.x)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }

        
    }
}
