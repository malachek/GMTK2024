using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AntSeller : MonoBehaviour, IInteractable {

    [SerializeField] private GameObject dialogueBubbleUI;
    [SerializeField] private GameObject interactUI;
    [SerializeField] private Animator animatorDialogueBubbleUI;

    private const string STATE = "State";

    public event EventHandler Interacted;

    private void Start(){
        dialogueBubbleUI.SetActive(false);
        interactUI.SetActive(false);
    }

    public void Interact()
    {
        interactUI.SetActive(false);

        Interacted?.Invoke(this, EventArgs.Empty);

        animatorDialogueBubbleUI.SetBool(STATE, false);
    }

    public void OnSelected()
    {
        dialogueBubbleUI.SetActive(true);
        animatorDialogueBubbleUI.SetBool(STATE, true);
        interactUI.SetActive(true);
    }

    public void NotInteracting()
    {
        animatorDialogueBubbleUI.SetBool(STATE, false);
        interactUI.SetActive(false);
    }
}
