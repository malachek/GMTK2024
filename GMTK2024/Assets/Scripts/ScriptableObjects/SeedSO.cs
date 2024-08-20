using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SeedSO")]
public class SeedSO : BaseDataSO{

    [Header("Seed Fields")]
    public int DesiredSunlight;
    public int DesiredWaterLevel;
    public int DesiredSoilBracket;
    public float Income;
    public List<string> GoodNeighborLabels;
    public List<string> BadNeighborLabels;
}
