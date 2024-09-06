using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interact : MonoBehaviour{

    [SerializeField] private float range;

    private Camera mainCamera;
    private IInteractable interactable;

    void Start(){
        mainCamera = Camera.main;
    }

    void Update(){
        CheckInteractableObject();
    }

    private void CheckInteractableObject(){

        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.TransformDirection(Vector3.forward), out hit, range)){
            GameObject target = hit.collider.gameObject;
            if (target.GetComponent<IInteractable>() != null && interactable == null){
                interactable = target.GetComponent<IInteractable>();
                Debug.Log("Selected");
                interactable.OnSelected();
            }
            if(Input.GetMouseButtonDown(0) && interactable != null){
                interactable.Interact();
                Debug.Log("interacted");
            }
        }else{
            interactable?.NotInteracting();
            interactable = null;
        }     
    }
}
