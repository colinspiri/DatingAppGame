using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Match {
    private Character bachelor;
    private Character suitor;

    public Match(Character character1, Character character2) {
        bachelor = character1;
        suitor = character2;
    }

    public KeyValuePair<Character, Character> GetCharacters() {
        return new KeyValuePair<Character, Character>(bachelor, suitor);
    }

    public List<string> GetConversation() {
        return new List<string> {
            "hello there",
            "general kenobi",
            "i have the high ground",
        };
    }
}
