using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Message : MonoBehaviour {
    private string message;
    
    public GameObject messageBox;
    public TextMeshProUGUI messageText;

    private enum MessageState {
        Hidden,
        Typing,
        Visible
    }
    private MessageState state;

    private float minTypingTime = 5f;
    private float maxTypingTime = 7f;
    private float typingTime;
    private float timer;

    private float typingTickTime = 1f;
    private int typingTickState = 0;
    
    public delegate void OnMessageSend();
    public OnMessageSend onMessageSend;
    
    // Start is called before the first frame update
    void Start() {
        state = MessageState.Hidden;
        typingTime = Random.Range(minTypingTime, maxTypingTime);
        messageBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == MessageState.Typing) {
            // count up time
            timer += Time.deltaTime;
            // if typing for long enough, switch to visible
            if (timer >= typingTime) {
                state = MessageState.Visible;
                messageText.text = message;
                onMessageSend?.Invoke();
            }
            else {
                // tick typing state
                if (timer >= typingTickTime) {
                    typingTime -= timer;
                    timer = 0;
                    typingTickState++;
                }
                // assign text based on typing state
                if (typingTickState % 3 == 0) {
                    messageText.text = ".";
                }
                else if (typingTickState % 3 == 1) {
                    messageText.text = ". .";
                }
                else if (typingTickState % 3 == 2) {
                    messageText.text = ". . .";
                }  
            }
        }
    }

    public void StartTyping(string message) {
        state = MessageState.Typing;
        this.message = message;
        messageBox.SetActive(true);
    }
}
