using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBase : MonoBehaviour
{
    [SerializeField] DecorationSprite plantSprite;

    public float my_Points { get; private set; }

    [Header("Scriptable Object")]
    [SerializeField] SO_Plants plantsData;

    public int my_DesiredSunlight;
    public int my_CurrentSunPoints { get; private set; }

    void Awake()
    {
        my_Points = 0f;
        ParseData();

        plantSprite.SetSprite(plantsData.Sprite);

        //when jar is rotated, recalculate sunlight
        GodController.OnRotateJar += CalculateSunlight;
    }

    private void Start()
    {
        CalculateSunlight();
    }

    void ParseData()
    {
        //do this for all data stored in SO_Plants (and SO_Decoration)
        my_DesiredSunlight = plantsData.DesiredSunlight;
    }

    void CalculateSunlight()
    {
        int newPoints = PlantConditionCalc.CalcSunPoints(this.transform, my_DesiredSunlight);
        Debug.Log($"I want {my_DesiredSunlight} light level. this equates to {newPoints}");
        my_Points += (newPoints - my_CurrentSunPoints);
        my_CurrentSunPoints = newPoints;
    }

    void Update()
    {
        
    }
}
