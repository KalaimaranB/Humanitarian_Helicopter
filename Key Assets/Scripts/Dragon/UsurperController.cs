using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsurperController : MonoBehaviour
{
    Animator anim;
    public bool WalkAnim = false;
    public bool FlyAnim = false;
    public float Damage = 100;
    public GameObject Coin;
    BoxCollider bc;


    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
        if (WalkAnim == true)
        {
            anim.SetTrigger("Walk");
        }
        if (FlyAnim== true)
        {
            anim.SetTrigger("FlyForward");
            bc.center = new Vector3 (bc.center.x,7,bc.center.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<BasicDragonControl>().CurrentHealth<=0)
        {
            MessageBoard.SendMessageToBoard("You killed a dragon!");
            Instantiate(Coin, transform.position, Coin.transform.rotation);
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Helicopter")
        {
            collision.gameObject.GetComponent<BasicHelicopterController>().CurrentHealth -= Damage;
        }
    }
}
