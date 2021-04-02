using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterCard : MonoBehaviour {
    [SerializeField] private CharacterCardData cardData;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCharacter(Character character) {
        cardData.SetCharacter(character);
    }
}
