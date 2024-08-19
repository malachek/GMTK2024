using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBase : MonoBehaviour
{
    public DecorationSprite plantSprite;

    public int my_Points { get; private set; }

    [Header("Scriptable Object")]
    [SerializeField] SO_Plants plantsData;

    protected int my_DesiredSunlight;
    protected int my_DesiredWaterLevel;
    protected int my_DesiredSoil;
    protected List<string> my_GoodNeighborLabels;
    protected List<string> my_BagNeighborLabels;

    public int SunPoints { get; private set; }
    public int WaterPoints { get; private set; }
    public int SoilPoints { get; private set; }
    public int CrowdingPoints { get; private set; }

    protected List<PlantBase> neightboringPlants;


    void Awake()
    {
        my_Points = 0;
        ParseData();

        plantSprite.SetSprite(plantsData.Sprite);

        //when jar is rotated, recalculate sunlight
        GodController.OnRotateJar += CalculateSunlightPoints;
        // {}.OnWaterPlants += CalculateWaterPoints;
        // {}.OnSoilDegredation += CaclculateSoilPoints;
        // {}.OnNewPlantPlaced += CalculateCrowdingPoints;
    }

    private void Start()
    {
        CalculateSunlightPoints();
    }

    void ParseData()
    {
        //do this for all data stored in SO_Plants (and SO_Decoration)
        my_DesiredSunlight = plantsData.DesiredSunlight;
        my_DesiredWaterLevel = plantsData.DesiredWaterLevel;
        my_DesiredSoil = plantsData.DesiredSoilQuality;
        my_GoodNeighborLabels = plantsData.GoodNeighborLabels;
        my_BagNeighborLabels = plantsData.BadNeighborLabels;
    }

    // DONE
    void CalculateSunlightPoints() 
    {
        int newPoints = PlantConditionCalc.CalcSunPoints(this.transform.position, my_DesiredSunlight);
        //Debug.Log($"I want {my_DesiredSunlight} light level. this equates to {newPoints}");
        my_Points += (newPoints - SunPoints);
        SunPoints = newPoints;
    }

    // TO DO
    void CalculateWaterPoints() 
    {
        int newPoints = PlantConditionCalc.CalcWaterPoints();
        my_Points += (newPoints - WaterPoints);
        WaterPoints = newPoints;
        return;
    }

    // TO DO
    void CalculateSoilPoints()
    {
        int newPoints = PlantConditionCalc.CalcSoilPoints();
        my_Points += (newPoints - SoilPoints);
        SoilPoints = newPoints;
        return;
    }

    // TO DO
    void CalculateCrowdingPoints()
    {
        //find neighbors
        int newPoints = PlantConditionCalc.CalcCrowdingPoints();
        my_Points += (newPoints - CrowdingPoints);
        CrowdingPoints = newPoints;
        return;
    }
}
