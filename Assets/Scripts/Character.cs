using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterName", menuName = "Character")]
public class Character : ScriptableObject {
    public string characterName;
    
    public Sprite profilePicture;
    
    public string bio;
    public string occupation;

    public List<string> likes;
    public List<string> dislikes;

    public List<Character> goodMatches;
    public List<Character> badMatches;

    public string GetLikesAsFormattedString() {
        return GetFormattedStringFromList(likes);
    }

    public string GetDislikesAsFormattedString() {
        return GetFormattedStringFromList(dislikes);
    }

    private string GetFormattedStringFromList(List<string> list) {
        string output = "";
        for (int i = 0; i < list.Count; i++) {
            // add element
            output += list[i];
            // add comma & conjuction
            if (i + 1 < list.Count) {
                output += ", ";
                if (i + 1 == list.Count - 1) output += "and ";
            }
        }

        return output;
    }
}
