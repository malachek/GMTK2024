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

    //public delegate void SwitchPlayerAction(string PlayerMode);
    //public static event SwitchPlayerAction OnSwitchPlayer;

    public delegate void SwitchToGod();
    public static event SwitchToGod OnSwitchToGod;

    public delegate void SwitchToSmall();
    public static event SwitchToSmall OnSwitchToSmall;


    [Header("Cameras")]

    public Transform CurrentGodCameraTransform;
    private Transform OriginalGodCameraTransform;

    private void Awake()
    {
        godIsActive = startInGod;
        SetEnables();
        Debug.Log(godIsActive ? "Starting in GOD MODE" : "Starting in SMALL MODE");
        OriginalGodCameraTransform = CurrentGodCameraTransform;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            SwitchPlayer();
        }
    }

    /*public static void TriggerSwitchPlayer(string PlayerMode)
    {
        OnSwitchPlayer?.Invoke(PlayerMode); //Either "GOD" or "SMALL"
    }*/

    

    //Calls SwitchPlayer event, flipflops between GOD and SMALL
    public void SwitchPlayer()
    {
        Debug.Log(godIsActive ? "switching from GOD to SMALL" : "switching from SMALL to GOD");
        godIsActive = !godIsActive;

        if (godIsActive)
        {
            TriggerSwitchToGod();
        }
        else
        {
            TriggerSwitchToSmall();
        }

        /*if (OnSwitchPlayer != null)
        {
            //OnSwitchPlayer(godIsActive ? "GOD" : "SMALL");
            TriggerSwitchPlayer(godIsActive ? "GOD" : "SMALL");
        }*/

        SetEnables();
    }
    public static void TriggerSwitchToGod()
    {
        OnSwitchToGod?.Invoke();
    }
    public static void TriggerSwitchToSmall()
    {
        OnSwitchToSmall?.Invoke();
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
