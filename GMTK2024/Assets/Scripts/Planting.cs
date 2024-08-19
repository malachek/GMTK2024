using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Planting : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    private PrefabSelector plantSelector;
    void Start()
    {
        plantSelector = FindObjectOfType<PrefabSelector>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            //create ray
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject selectedPrefab = plantSelector.GetSelectedPrefab();

                if (selectedPrefab != null)
                {
                    Instantiate(selectedPrefab, hit.point, Quaternion.identity);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
