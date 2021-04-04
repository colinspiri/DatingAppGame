using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMatches", menuName = "Matches")]
public class Matches : ScriptableObject {
    public List<Match> matches;

    private int index = 0;

    public void AddMatch(Character bachelor, Character suitor) {
        matches.Add(new Match(bachelor, suitor));
    }

    public Match GetCurrentMatch() {
        return matches[index];
    }
    public void NextMatch() {
        index++;
    }

    public List<Match> GetMatches() {
        return matches;
    }
}