using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBoard : MonoBehaviour
{
    public Message CurrentMessage;
    public Text messageBoard;
    public float messageDisplayTime;

    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.TimerFinished += Timer_TimerFinished;
    }

    private void Timer_TimerFinished(object sender, System.EventArgs e)
    {
        CurrentMessage = new Message("");
    }

    // Update is called once per frame
    void Update()
    {
        messageBoard.text = CurrentMessage.message;
    }

    public static void SendMessageToBoard(string text)
    {
        if (text.Length > 50)
        {
            Debug.LogWarning("This message is pretty long. Try shortening it.");
        }
        Message M = new Message(text);
        MessageBoard board = GameObject.FindObjectOfType<MessageBoard>();
        board.CurrentMessage = M;

        board.gameObject.GetComponent<Timer>().SetTimer(board.messageDisplayTime);
        board.gameObject.GetComponent<Timer>().StartTimer();
    }

    [System.Serializable]
    public class Message
    {
        public string message;
        public Message (string text)
        {
            message = text;
        }
    }

    
}
