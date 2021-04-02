using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCard : MonoBehaviour {
    [SerializeField] private Character character;

    public Image profilePicture;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI occupationText;
    public TextMeshProUGUI likesText;
    public TextMeshProUGUI dislikesText;
    public TextMeshProUGUI bioText;
    
    // Start is called before the first frame update
    void Start() {
        UpdateCard();
    }

    private void UpdateCard() {
        if (character == null) {
            Debug.Log("No character assigned for " + gameObject.name);
            return;
        }
        
        if(character.profilePicture != null) profilePicture.sprite = character.profilePicture;
        nameText.text = character.characterName;
        occupationText.text = character.occupation;
        likesText.text = character.GetLikesAsFormattedString();
        dislikesText.text = character.GetDislikesAsFormattedString();
        bioText.text = character.bio;
    }

    public void SetCharacter(Character newCharacter) {
        character = newCharacter;
        UpdateCard();
    }
}
