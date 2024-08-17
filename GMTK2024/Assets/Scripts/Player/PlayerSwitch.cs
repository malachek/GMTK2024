using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class PlayerSwitch : MonoBehaviour
{
    [SerializeField] GodController godController;
    [SerializeField] ThirdPersonController smallController;

    private StarterAssetsInputs _input;

    public bool godIsActive {  get; private set; }


    public bool switchPlayerInput;

    private void Awake()
    {
        _input = FindObjectOfType<StarterAssetsInputs>();
        Debug.Log(_input.name);
        godIsActive = true;
        SwitchPlayer();
    }

    void Update()
    {
        SwitchPlayer();
    }

    public void SwitchPlayer()
    {
        if(_input.switchPlayer)
        {
            _input.switchPlayer = false;
            Debug.Log(godIsActive ? "switching from god to small" : "switching from small to god");
            godIsActive = !godIsActive;
            godController.enabled = godIsActive;
            smallController.enabled = !godIsActive;
        }
    }
}
