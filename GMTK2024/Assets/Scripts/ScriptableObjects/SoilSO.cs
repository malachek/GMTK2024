using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/BaseDataSO/SoilSO")]
public class SoilSO : InventoryStackSO{

    [Header("Soil Fields")]
    public float waterLevel;
    public float soilDeploration;
    public float startingNutrients;
    public float health = 100;
    public int soilGrade;
}
