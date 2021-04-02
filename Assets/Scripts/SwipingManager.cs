using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipingManager : MonoBehaviour {
    public List<Character> characterList;

    private Character bachelor;
    private Character suitor;
    private List<KeyValuePair<Character, Character>> matches;

    public GameObject suitorCardPrefab;

    public BachelorCard bachelorCard;
    public SuitorCard suitorCard;
    public SuitorCard nextSuitorCard;

    private bool accepted = false;

    // Start is called before the first frame update
    void Start() {
        matches = new List<KeyValuePair<Character, Character>>();
        
        // get starting bachelor and suitor
        bachelor = GetNextCharacter();
        bachelorCard.SetCharacter(bachelor);
        suitor = GetNextCharacter();
        suitorCard.SetCharacter(suitor);
        suitorCard.SetOnScreen();
        // create the next suitor card
        InstantiateNextSuitorCard();
    }

    // Update is called once per frame
    void Update() {
        if (accepted) return;
        
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
        
        // UpdateCards();
        // set bachelor card
        bachelorCard.SetAccepted();
        // bachelorCard.SetCharacter(bachelor);
        // goodbye to old suitor card
        suitorCard.SetAccepted();
        accepted = true;
        // hello to new suitor card
        // suitorCard = nextSuitorCard;
        // suitorCard.SetCharacter(suitor);
        // suitorCard.SetOnScreen();
        // // create the next suitor card
        // InstantiateNextSuitorCard();
    }

    private void RejectSuitor() {
        characterList.Add(suitor);
        suitor = GetNextCharacter();
        
        // goodbye to old suitor card
        suitorCard.SetRejected();
        // hello to new suitor card
        suitorCard = nextSuitorCard;
        suitorCard.SetCharacter(suitor);
        suitorCard.SetOnScreen();
        // create the next suitor card
        InstantiateNextSuitorCard();
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

    private void InstantiateNextSuitorCard() {
        nextSuitorCard = Instantiate(suitorCardPrefab).GetComponent<SuitorCard>();
        nextSuitorCard.transform.SetParent(suitorCard.transform.parent.transform, false);
    }
}
