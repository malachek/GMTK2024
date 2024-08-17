using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/BaseDataSO/Fertilizer")]
public class FertilizerSO : InventoryStackSO{

    [Header("Fertilizer Fields")]
    public float healthBooster;
    public float waterLevelBooster;
    public float soilDeplorationBooster;
}
