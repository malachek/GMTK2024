using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBase : MonoBehaviour
{
    public DecorationSprite plantSprite;

    public int my_Points { get; private set; }

    [Header("Scriptable Object")]
    [SerializeField] SeedSO plantsData;

    protected int my_DesiredSunlight;
    protected int my_DesiredWaterLevel;
    protected int my_DesiredSoilBracket;
    protected List<string> my_GoodNeighborLabels;
    protected List<string> my_BadNeighborLabels;
    protected float my_Income;

    public int SunPoints { get; private set; }
    public int WaterPoints { get; private set; }
    public int SoilPoints { get; private set; }
    public int CrowdingPoints { get; private set; }

    protected List<PlantBase> neightboringPlants;

    protected int myWaterLevel;

    public bool IsTooSunny { get; private set; }


    void Awake()
    {
        my_Points = 0;
        ParseData();

        plantSprite.SetSprite(plantsData.Sprite);

        GodController.OnRotateJar += CalculateSunlightPoints;
        Soil.OnSoilQualityChange += CalculateSoilPoints;
        Planting.OnPlantSeed += CalculateCrowdingPoints;

        TimeManager.OnNewDay += ResetWater;

        //uncomment for testing purposes
        TimeManager.OnNewDay += PointGenie;
    }

    private void PointGenie(int day)
    {
        Debug.Log("I AM A SCUM - DELETE THIS");
        my_Points++;
    }

    private void Start()
    {
        CalculateSunlightPoints();
        CalculateSoilPoints();
        CalculateCrowdingPoints();
    }

    void ParseData()
    {
        //do this for all data stored in SO_Plants (and SO_Decoration)
        my_DesiredSunlight = plantsData.DesiredSunlight;
        my_DesiredWaterLevel = plantsData.DesiredWaterLevel;
        my_DesiredSoilBracket = plantsData.DesiredSoilBracket;
        my_GoodNeighborLabels = plantsData.GoodNeighborLabels;
        my_BadNeighborLabels = plantsData.BadNeighborLabels;
        my_Income = plantsData.Income;
    }

    private void ResetWater(int day)
    {
        myWaterLevel = 0;
    }

    public void GetWatered(int waterAmount)
    {
        myWaterLevel += waterAmount;
        CalculateWaterPoints();
    }

    public float GetIncome()
    {
        return my_Income * (SunPoints + WaterPoints + SoilPoints + 8) / 16;
    }

    // DONE
    void CalculateSunlightPoints() 
    {
        (int newPoints , bool isTooSunny) = PlantConditionCalc.CalcSunPointsAndIsTooSunny(this.transform.position, my_DesiredSunlight);

        my_Points += (newPoints - SunPoints);
        SunPoints = newPoints;
        IsTooSunny = isTooSunny;

        /*Debug.Log($"POSITION: {this.transform.position}");
        Debug.Log($"{name} want {my_DesiredSunlight} light level. this equates to {newPoints}");
        if (newPoints < 2) Debug.Log(isTooSunny ? "Too Sunnyyyy" : "Too Darkkkk");*/
    }

    // TO DO
    void CalculateWaterPoints() 
    {
        int newPoints = PlantConditionCalc.CalcWaterPoints(myWaterLevel, my_DesiredWaterLevel);
        my_Points += (newPoints - WaterPoints);
        WaterPoints = newPoints;
        Debug.Log($"{gameObject.name} got waterred. waterlevel: {myWaterLevel} | desiredwater: {my_DesiredWaterLevel} | waterpoints: {WaterPoints}");   
        return;
    }

    // DONE
    void CalculateSoilPoints()
    {
        CalculateSoilPoints(FindObjectOfType<Soil>().healthBracket);
    }
    void CalculateSoilPoints(int soiLHealthBracket)
    {
        int newPoints = Mathf.Min(3 - (my_DesiredSoilBracket - soiLHealthBracket), 3);
        my_Points += (newPoints - SoilPoints);
        SoilPoints = newPoints;
        return;
    }

    // TO DO
    void CalculateCrowdingPoints()
    {
        return;
        //find neighbors
        /*int newPoints = PlantConditionCalc.CalcCrowdingPoints();
        my_Points += (newPoints - CrowdingPoints);
        CrowdingPoints = newPoints;
        return;*/
    }
}
