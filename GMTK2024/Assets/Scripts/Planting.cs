using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Planting : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask; // Layer mask for the ground or surfaces where the object can be placed
    [SerializeField] private Material previewMaterial; // Material to use for the preview (semi-transparent)

    private PrefabSelector plantSelector;
    private GameObject previewInstance;
    private GameObject lastSelectedPrefab;

    void Start()
    {
        plantSelector = FindObjectOfType<PrefabSelector>();
    }

    void Update()
    {
        // Check selected prefab
        GameObject selectedPrefab = plantSelector.GetSelectedPrefab();
        if (selectedPrefab == null)
        {
            DestroyPreview(); // Destroy the preview if no prefab is selected
            return;
        }

        // Check if selected prefab changed
        if (selectedPrefab != lastSelectedPrefab)
        {
            DestroyPreview(); // Destroy the previous preview
            CreatePreview(selectedPrefab); // Create a new preview
            lastSelectedPrefab = selectedPrefab;
        }

        UpdatePreviewPosition();

        //instantiate
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            PlacePrefab();
        }
    }

    void CreatePreview(GameObject prefab)
    {
        previewInstance = Instantiate(prefab);
        SetPreviewMaterial(previewInstance, previewMaterial);
    }

    void UpdatePreviewPosition()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, layerMask))
        {
            previewInstance.transform.position = hit.point;
        }
    }

    void PlacePrefab()
    {
        if (previewInstance != null)
        {
            // Instantiate the actual prefab at the preview's position
            Instantiate(plantSelector.GetSelectedPrefab(), previewInstance.transform.position, Quaternion.identity);
        }
    }

    void SetPreviewMaterial(GameObject obj, Material material)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.material = material;
        }
    }

    void DestroyPreview()
    {
        if (previewInstance != null)
        {
            Destroy(previewInstance);
            previewInstance = null;
        }
    }
}
