using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Helicopter")
        {
            collision.gameObject.GetComponent<BasicHelicopterController>().KeyCount += 1;
            MessageBoard.SendMessageToBoard("Collected Key");
            Destroy(gameObject);
        }
    }
}
