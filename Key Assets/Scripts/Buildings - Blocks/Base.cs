using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Helicopter")
        {
            if (collision.gameObject.GetComponent<TransportCopter>())
            {
                if(collision.gameObject.GetComponent<TransportCopter>().CurrentPeople>0)
                {
                    MessageBoard.SendMessageToBoard("Dropped off all passengers!");
                    collision.gameObject.GetComponent<TransportCopter>().CurrentPeople = 0;
                }
            }
        }
    }
}
