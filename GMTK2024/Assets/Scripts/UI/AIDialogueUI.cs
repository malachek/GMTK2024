using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AIDialogueUI : MonoBehaviour{

    [SerializeField] private GameObject dialogue;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float timeToRead;
    [SerializeField] private Animator animator;

    void Start(){
        dialogue.SetActive(false);
        Hide();
    }

    void UpdateVisuals(string newText){
        text.text = newText;
    }

    public void TalkToPlayer(string newText){
        Show();
        UpdateVisuals(newText);
    }

    void Show(){
        dialogue.SetActive(true);
        animator.SetBool("State", true);
    }

    public void Hide(){
        animator.SetBool("State", false);
    }
}
