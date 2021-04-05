using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {
    public Matches currentMatches;
    private List<string> conversation;

    public List<Message> messages;

    private bool startedDialogue = false;

    private float timer = 0;

    // Start is called before the first frame update
    void Start() {
        conversation = currentMatches.GetCurrentMatch().GetConversation();
        if (currentMatches.NextMatch()) {
            Application.Quit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) {
            timer += Time.deltaTime;
        }
        if (!startedDialogue) {
            StartMessage(0);
            startedDialogue = true;
        }

        if (timer >= 2f) {
            SceneManager.LoadScene("MatchesSummaryScene");
        }
    }

    private void StartMessage(int messageIndex) {
        Message message = messages[messageIndex];
        message.StartTyping(conversation[messageIndex]);
        
        if (messageIndex + 1 < messages.Count) {
            message.onMessageSend += () => StartMessage(messageIndex + 1);
        }
        else {
            message.onMessageSend += () => {
                timer = 0.1f;
            };
        }
    }
}
