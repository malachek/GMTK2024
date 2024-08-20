using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AIDialogueUI : MonoBehaviour{

    [SerializeField] private GameObject dialogue;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float timeToRead;

    void Start(){
        Hide();
    }

    void UpdateVisuals(string newText){
        text.text = newText;
    }

    public void TalkToPlayer(string newText){
        Show();
        UpdateVisuals(newText);
        StartCoroutine(Timer());
    }

    void Show(){
        dialogue.SetActive(true);
    }

    public void Hide(){
        dialogue.SetActive(false);
    }

    IEnumerator Timer(){
        yield return new WaitForSeconds(timeToRead);
    }
}
