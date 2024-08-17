using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwitch : MonoBehaviour
{
    [SerializeField] GameObject godObject;
    [SerializeField] GameObject smallObject;

    [SerializeField] bool startInGod;
    public bool godIsActive {  get; private set; }

    public delegate void SwitchPlayerAction();
    public static event SwitchPlayerAction OnSwitchPlayer;

    private void Awake()
    {
        godIsActive = startInGod;
        SetEnables();
        Debug.Log(godIsActive ? "Starting in GOD MODE" : "Starting in SMALL MODE");
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
        if (OnSwitchPlayer != null)
        {
            OnSwitchPlayer();
        }
        Debug.Log(godIsActive ? "switching from god to small" : "switching from small to god");
        godIsActive = !godIsActive;
        SetEnables();
    }

    private void SetEnables()
    {
        godObject.SetActive(false);
        smallObject.SetActive(false);

        if (godIsActive)
        {
            godObject.SetActive(true);
        }
        else
        {
            smallObject.SetActive(true);
        }
    }
}
