using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/BaseDataSO/SeedSO")]
public class SeedSO : BaseDataSO{

    [Header("Seed Fields")]
    public int desiredSunlight;
    public int desiredWaterLevel;
    public int desiredSoilBracket;
    public List<string> goodNeighboorLabels;
    public List<string> badNeighboorLabels;
}
