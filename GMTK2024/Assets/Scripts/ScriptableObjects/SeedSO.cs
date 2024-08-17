using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/BaseDataSO/SeedSO")]
public class SeedSO : InventoryStackSO{

    [Header("Seed Fields")]
    public float lightIntensity;
    public float temperature;
    public float waterLevel;
    public EItemType soilType;
}
