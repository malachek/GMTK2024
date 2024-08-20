using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSelector : MonoBehaviour
{
    public GameObject[] seedPacks;
    public GameObject[] plantBases;

    private GameObject selectedPlant = null;
    private int selectedPlantIndex = -1;

    [SerializeField] MusicHandler musicPlayer;

    public void SelectPrefab(int index)
    {
        if (index >= 0 && index < seedPacks.Length)
        {
            selectedPlant = seedPacks[index];
            selectedPlantIndex = index;
            //Debug.Log($"Selected: {selectedPlant.name}");
        }
    }

    public void DeselectPrefab()
    {
        selectedPlant = null;
        selectedPlantIndex = -1;
    }

    public void PlantMusicQueue()
    {
        musicPlayer.UnMutePattern(selectedPlantIndex);
    }

    public GameObject GetSelectedSeedPrefab()
    {
        //Debug.Log($"Attempting to plant {selectedPlant.name}");
        if(selectedPlantIndex == -1) return null;
        return seedPacks[selectedPlantIndex];
        return selectedPlant;
    }

    public GameObject GetSelectedPlantPrefab()
    {
        return plantBases[selectedPlantIndex];
    }
}
