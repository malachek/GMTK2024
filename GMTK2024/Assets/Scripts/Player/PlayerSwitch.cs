using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerSwitch : MonoBehaviour
{
    [Header("GOD")]
    [SerializeField] GameObject godObject;
    
    public Transform CurrentGodCameraTransform;
    private Transform OriginalGodCameraTransform;


    [SerializeField] Transform GodPlantLookLocation;
    private static Transform S_GodPlantLookLocation;


    [Header("SMALL")]
    [SerializeField] GameObject smallObject;
    private static Transform smallObjectTransform;


    [Header("SWITCH BEHAVIOR")]

    [SerializeField] bool startInGod;
    public static bool godIsActive {  get; private set; }

    //public delegate void SwitchPlayerAction(string PlayerMode);
    //public static event SwitchPlayerAction OnSwitchPlayer;

    public delegate void SwitchToGod();
    public static event SwitchToGod OnSwitchToGod;

    public delegate void SwitchToSmall();
    public static event SwitchToSmall OnSwitchToSmall;



    private void Awake()
    {
        InitializeVariables();
        SetEnables();
        Debug.Log(godIsActive ? "Starting in GOD MODE" : "Starting in SMALL MODE");
    }

    private void InitializeVariables()
    {
        S_GodPlantLookLocation = GodPlantLookLocation;
        godIsActive = startInGod;
        OriginalGodCameraTransform = CurrentGodCameraTransform;
        smallObjectTransform = smallObject.transform;
    }

    /*void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            SwitchPlayer();
        }
    }*/

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

    public static Vector3 GetLookLocation()
    {
        if (godIsActive)
        {
            return S_GodPlantLookLocation.position;
        }
        else
        {
            return new Vector3(smallObjectTransform.position.x, 0f, smallObjectTransform.position.z); 
        }
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
