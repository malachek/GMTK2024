using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSelector : MonoBehaviour
{
    public GameObject[] prefabs;  // Assign different prefabs in the Inspector
    private GameObject selectedPrefab;

    void Start()
    {
        // Set the first prefab as the default selection
        if (prefabs.Length > 0)
        {
            selectedPrefab = prefabs[0];
        }
    }

    public void SelectPrefab(int index)
    {
        if (index >= 0 && index < prefabs.Length)
        {
            selectedPrefab = prefabs[index];
        }
    }

    public GameObject GetSelectedPrefab()
    {
        return selectedPrefab;
    }
}
