using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwipingManager : MonoBehaviour {
    public List<Character> characterList;

    private Character bachelor;
    private Character suitor;
    public Matches currentMatches;

    public GameObject bachelorCardPrefab;
    public GameObject suitorCardPrefab;

    public BachelorCard bachelorCard;
    public SuitorCard suitorCard;
    public SuitorCard nextSuitorCard;
    
    // Start is called before the first frame update
    void Start() {
        // get starting bachelor and suitor
        bachelor = GetNextCharacter();
        bachelorCard.SetCharacter(bachelor);
        suitor = GetNextCharacter();
        suitorCard.SetCharacter(suitor);
        suitorCard.SetOnScreen();
        // create the next suitor card
        InstantiateNextSuitorCard();
        currentMatches.Reset();
    }

    // Update is called once per frame
    void Update() {
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
        Debug.Log("adding " + bachelor.characterName + " and " + suitor.characterName + " to matches.");
        currentMatches.AddMatch(bachelor, suitor);        
        Debug.Log("current matches now has " + currentMatches.matches.Count);
        bachelor = GetNextCharacter();
        suitor = GetNextCharacter();
        
        // UpdateCards();
        // set bachelor card
        bachelorCard.SetAccepted();
        InstantiateNewBachelorCard();
        // bachelorCard.SetCharacter(bachelor);
        // goodbye to old suitor card
        suitorCard.SetAccepted();
        suitorCard = nextSuitorCard;
        suitorCard.SetCharacter(suitor);
        suitorCard.SetOnScreen();
        InstantiateNextSuitorCard();
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
            SceneManager.LoadScene("MatchesSummaryScene");
            return null;
        }

        Character nextCharacter = characterList[0];
        characterList.RemoveAt(0);
        return nextCharacter;
    }

    private void InstantiateNewBachelorCard() {
        bachelorCard = Instantiate(bachelorCardPrefab).GetComponent<BachelorCard>();
        bachelorCard.transform.SetParent(suitorCard.transform.parent.transform, false);
        bachelorCard.SetCharacter(bachelor);
    }

    private void InstantiateNextSuitorCard() {
        nextSuitorCard = Instantiate(suitorCardPrefab).GetComponent<SuitorCard>();
        nextSuitorCard.transform.SetParent(suitorCard.transform.parent.transform, false);
    }
}
