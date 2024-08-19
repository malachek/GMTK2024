using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WaterSpray : MonoBehaviour
{
    [Header("Cursor Settings")]
    [SerializeField] private GameObject cursorPrefab; // Prefab for the cursor
    private GameObject cursorInstance;

    [SerializeField] private float cursorRadius = 1.0f; // The size of the cursor's area that will be affected
    [SerializeField] private LayerMask plantLayer; // this is the layer to detect plants

    private bool isCursorActive = false;

    void Start()
    {
        // forcursor at start, but keep it inactive
        cursorInstance = Instantiate(cursorPrefab);
        //cursorInstance.transform.localScale = new Vector3(1, 1, 1); // Adjust the scale based on radius
        cursorInstance.SetActive(false);
    }

    void Update()
    {
        HandleCursorActivation();
        if (isCursorActive)
        {
            HandleCursorMovement();
        }
    }

    private void HandleCursorActivation()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            isCursorActive = !isCursorActive;
            cursorInstance.SetActive(isCursorActive);

            if (!isCursorActive)
            {
                Debug.Log("Watering stop.");
            }
            else
            {
                Debug.Log("Watering work.");
            }
        }
    }

    private void HandleCursorMovement()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            cursorInstance.transform.position = hit.point;

            // Check for watering input
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                WaterPlantsInCursorArea();
            }
        }
    }

    private void WaterPlantsInCursorArea()
    {
        Collider[] hitColliders = Physics.OverlapSphere(cursorInstance.transform.position, cursorRadius);
        //Debug.Log($"col length: {hitColliders.Length}");
        foreach (Collider hitCollider in hitColliders)
        {
            //Debug.Log($"Collided with : {hitCollider.gameObject.name}");
;           hitCollider.gameObject.GetComponent<PlantBase>()?.GetWatered(1) ;
        }
    }
}
