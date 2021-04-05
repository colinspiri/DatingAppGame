using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Match {
    private Character bachelor;
    private Character suitor;

    public enum MatchState {
        GoodMatch,
        NeutralMatch,
        BadMatch
    }
    private MatchState matchState;

    public Match(Character character1, Character character2) {
        bachelor = character1;
        suitor = character2;
        
        // get match status
        if(character1.goodMatches.Contains(character2)) matchState = MatchState.GoodMatch;
        else if (character1.badMatches.Contains(character2)) matchState = MatchState.BadMatch;
        else matchState = MatchState.NeutralMatch;
    }

    public KeyValuePair<Character, Character> GetCharacters() {
        return new KeyValuePair<Character, Character>(bachelor, suitor);
    }

    public List<string> GetConversation() {
        // if match is good
        if (matchState == MatchState.GoodMatch) {
            return new List<string> {
                bachelor.pickupLine,
                "oh yeah!",
                "bet, let's meet in person",
            };
        }
        // if match is neutral
        if (matchState == MatchState.NeutralMatch) {
            return new List<string> {
                bachelor.pickupLine,
                "eh, sure",
                "... okay.",
            };
        }
        // if match is bad
        if (matchState == MatchState.BadMatch) {
            return new List<string> {
                bachelor.pickupLine,
                "um, no thanks",
                "oops sorry about that, have a nice day",
            };
        }
        return new List<string>();
    }
}
