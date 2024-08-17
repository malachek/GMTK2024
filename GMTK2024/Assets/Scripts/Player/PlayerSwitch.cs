using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    [SerializeField] GodController godController;
    [SerializeField] SmallController smallController;

    public bool godIsActive {  get; private set; }

    private void Awake()
    {
        godIsActive = true;
        SwitchPlayer();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            SwitchPlayer();
        }
    }

    public void SwitchPlayer()
    {
        Debug.Log(godIsActive ? "switching from god to small" : "switching from small to god");
        godIsActive = !godIsActive;
        godController.enabled = godIsActive;
        smallController.enabled = !godIsActive;
    }
}
