using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {
    public Matches currentMatches;
    private List<string> conversation;

    public List<Message> messages;

    private bool startedDialogue = false;

    // Start is called before the first frame update
    void Start() {
        conversation = currentMatches.GetCurrentMatch().GetConversation();
        currentMatches.NextMatch();
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
        Message message = messages[messageIndex];
        message.StartTyping(conversation[messageIndex]);
        
        if (messageIndex + 1 < messages.Count) {
            message.onMessageSend += () => StartMessage(messageIndex + 1);
        }
    }
}
