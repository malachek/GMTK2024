using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSelector : MonoBehaviour
{
    public GameObject[] plants; 
    private GameObject selectedPlant = null;

    public void SelectPrefab(int index)
    {
        if (index >= 0 && index < plants.Length)
        {
            selectedPlant = plants[index];
        }
    }

    public GameObject GetSelectedPrefab()
    {
        return selectedPlant;
    }
}
