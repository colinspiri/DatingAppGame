using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {
    public Character bachelor;
    public Character suitor;

    public List<Message> messages;

    private bool startedDialogue = false;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!startedDialogue) {
            StartMessage(0);
            startedDialogue = true;
        }
    }

    private void StartMessage(int messageIndex) {
        Debug.Log("StartMessage(" + messageIndex + ")");
        Message message = messages[messageIndex];
        message.StartTyping("hello there");
        if (messageIndex + 1 < messages.Count) {
            message.onMessageSend += () => StartMessage(messageIndex + 1);
        }
    }
}
