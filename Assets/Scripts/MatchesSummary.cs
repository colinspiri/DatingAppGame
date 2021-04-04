using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchesSummary : MonoBehaviour {
    public Matches currentMatches;

    public TextMeshProUGUI matchesText;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        // set current as "active"
        // move to dialogue scene on player input
        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("MatchDialogueScene");
        }
    }

    private void UpdateUI() {
        string text  = "Matches: \n";
        if (currentMatches.GetMatches() == null) return;
        foreach (Match match in currentMatches.GetMatches()) {
            text += "" + match.GetCharacters().Key.characterName + " matched with " +
                           match.GetCharacters().Value.characterName;
        }
        matchesText.text = text;
    }
}
