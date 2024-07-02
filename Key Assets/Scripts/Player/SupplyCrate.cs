using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyCrate : MonoBehaviour
{
    public float DragonHealthIncrease = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dragon")
        {
            collision.gameObject.GetComponent<BasicDragonControl>().CurrentHealth += DragonHealthIncrease;
        }

        Destroy(gameObject);
    }
}
