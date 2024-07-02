using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject GameManagement;
    private GameManagement gameManagement;
    // Start is called before the first frame update
    void Start()
    {
        GameManagement = GameObject.FindWithTag("GameManagement");
        gameManagement = GameManagement.GetComponent<GameManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Helicopter")
        {
            gameManagement.Coins += 1;
            Destroy(gameObject);
        }
    }
}
