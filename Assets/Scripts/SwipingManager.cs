using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipingManager : MonoBehaviour {
    public List<Character> characterList;

    private Character bachelor;
    private Character suitor;
    private List<KeyValuePair<Character, Character>> matches;

    public CharacterCard bachelorCard;
    public CharacterCard suitorCard;
    
    // Start is called before the first frame update
    void Start() {
        matches = new List<KeyValuePair<Character, Character>>();
        
        // get starting bachelor and suitor
        bachelor = GetNextCharacter();
        suitor = GetNextCharacter();
        UpdateCards();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Debug.Log("Match!");
            AcceptSuitor();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Debug.Log("Rejected!");
            RejectSuitor();
        }
    }

    private void AcceptSuitor() {
        matches.Add(new KeyValuePair<Character, Character>(bachelor, suitor));
        bachelor = GetNextCharacter();
        suitor = GetNextCharacter();
        
        UpdateCards();
    }

    private void RejectSuitor() {
        characterList.Add(suitor);
        suitor = GetNextCharacter();
        
        UpdateCards();
    }

    private Character GetNextCharacter() {
        if (characterList.Count == 0) {
            Debug.LogWarning("No more characters in characterList!");
            return null;
        }

        Character nextCharacter = characterList[0];
        characterList.RemoveAt(0);
        return nextCharacter;
    }

    private void UpdateCards() {
        bachelorCard.SetCharacter(bachelor);
        suitorCard.SetCharacter(suitor);
    }
}
