using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour{

    private Camera mainCamera;
    private PlayerInput playerInput;

    void Start(){
        mainCamera = Camera.main;
        playerInput = new PlayerInput();
    }
}
