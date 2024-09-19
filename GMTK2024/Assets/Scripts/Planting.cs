using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Planting : MonoBehaviour
{
    //[SerializeField] private CinemachineVirtualCamera mainCamera;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask groundMask; 
    [SerializeField] private LayerMask packMask;
    [SerializeField] private Material previewMaterial; 

    private PrefabSelector plantSelector;
    private GameObject previewInstance;
    private GameObject lastSelectedPrefab;

    [SerializeField] GameObject SoilTop;

    public delegate void PlantSeed();
    public static event PlantSeed OnPlantSeed;

    void Start()
    {
        plantSelector = FindObjectOfType<PrefabSelector>();
    }

    void Update()
    {
        HandlePrefabSelection();

        // Check selected prefab
        GameObject selectedPrefab = plantSelector.GetSelectedSeedPrefab();
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
            if (!IsClickingOnSelectableObject())
            {
                PlacePrefab();
            }
        }
    }

    void HandlePrefabSelection()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, float.MaxValue, packMask))
            {
                SeedPackSelection selector = hit.collider.GetComponent<SeedPackSelection>();
                if (selector != null)
                {
                    plantSelector.SelectPrefab(selector.seedPackIndex);
                    lastSelectedPrefab = null; 
                    selector.DestroyPack();
                }
            }
        }
    }

    void CreatePreview(GameObject prefab)
    {
        previewInstance = Instantiate(prefab);
        previewInstance.layer = 0;
        SetPreviewMaterial(previewInstance, previewMaterial);
    }

    void UpdatePreviewPosition()
    {
        //Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, groundMask))
        {
            previewInstance.transform.position = hit.point;
        }
    }

    void PlacePrefab()
    {
        if (previewInstance != null)
        {
            plantSelector.PlantMusicQueue();
            // Instantiate the actual prefab at the preview's position
            var justPlanted = Instantiate(plantSelector.GetSelectedPlantPrefab(), previewInstance.transform.position, Quaternion.identity);
            SetParent(justPlanted.transform, SoilTop.transform);
            plantSelector.DeselectPrefab();
            OnPlantSeed?.Invoke();
        }
    }

    void SetParent(Transform child, Transform parent)
    {
        child.SetParent(parent);
        //child.localPosition = Vector3.zero;
        //child.localRotation = Quaternion.identity;
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

    bool IsClickingOnSelectableObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, packMask))
        {
            return hit.collider.GetComponent<SeedPackSelection>() != null;
        }
        return false;
    }
}
