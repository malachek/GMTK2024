using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MousePosition3D : MonoBehaviour {
    //[SerializeField] private CinemachineVirtualCamera mainCamera;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;
    //[SerializeField] private LayerMask buttonMask;

    private void Update() {
        //Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask)) {
            transform.position = raycastHit.point;
        }
    }
}
