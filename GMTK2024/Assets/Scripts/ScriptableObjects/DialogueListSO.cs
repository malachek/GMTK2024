using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/DialogueListSO")]
public class DialogueListSO : ScriptableObject{

    public List<DialogueValue> dialogueValuesList;
    public DialogueCategory dialogueCategory;

    public enum DialogueCategory{
        Light,
        Water,
        Soil,
        Crowding
    }
}
