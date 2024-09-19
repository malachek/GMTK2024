using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSelector : MonoBehaviour{

    [SerializeField] private List<DialogueListSO> dialogueListSOList;
    private PlantBase plantBase;
    private List<DialogueListSO> tempList = new List<DialogueListSO>();

    void Start(){
        SetTempList();
    }

    public void SetPlantBase(PlantBase plantBase){
        this.plantBase = plantBase;
    }

    public string SelectADialogue(){
        string dialogue = "";

        DialogueListSO dialogueList = SelectACategory();

        switch (dialogueList.dialogueCategory){
            case DialogueListSO.DialogueCategory.Light:
                if(plantBase.SunPoints < 2 ){
                    if(plantBase.IsTooSunny){
                        dialogue = dialogueList.dialogueValuesList[0].text;
                    }
                    else{
                        dialogue = dialogueList.dialogueValuesList[1].text;
                    }
                }
                else{
                    dialogue = dialogueList.dialogueValuesList[2].text;
                }
                break;
            case DialogueListSO.DialogueCategory.Crowding:
                dialogue = GetAssignedDialogue(dialogueList, plantBase.CrowdingPoints);
                break;
            case DialogueListSO.DialogueCategory.Water:
                dialogue = GetAssignedDialogue(dialogueList, plantBase.WaterPoints);
                break;
            case DialogueListSO.DialogueCategory.Soil:
                dialogue = GetAssignedDialogue(dialogueList, plantBase.SoilPoints);
                break;
        }
        return dialogue;
    }

    private string GetAssignedDialogue(DialogueListSO dialogueList, int value){
        foreach (DialogueValue dialogueValue in dialogueList.dialogueValuesList){
            if(dialogueValue.Value == value){
                return dialogueValue.text;
            }
        }
        return "Value Didn't correspond to any struct";
    }

    private DialogueListSO SelectACategory(){
        DialogueListSO list = tempList[Random.Range(0,tempList.Count-1)];
        return list;
    }

    private void SetTempList(){
        tempList = dialogueListSOList;
    }
}
