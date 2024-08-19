using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBase : MonoBehaviour
{
    public DecorationSprite plantSprite;

    public float my_Points { get; private set; }

    [Header("Scriptable Object")]
    [SerializeField] SO_Plants plantsData;

    protected int my_DesiredSunlight;
    protected int my_CurrentSunPoints { get; private set; }
    protected int my_CurrentWaterPoints { get; private set; }

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
        int newPoints = PlantConditionCalc.CalcSunPoints(this.transform.position, my_DesiredSunlight);
        //Debug.Log($"I want {my_DesiredSunlight} light level. this equates to {newPoints}");
        my_Points += (newPoints - my_CurrentSunPoints);
        my_CurrentSunPoints = newPoints;
    }
    public void WaterPlant(int waterAmount)
    {
        // Simply add water points to the plant's total points
        my_Points += waterAmount;
        Debug.Log($"{gameObject.name} got watered. Points: {my_Points}");
    }
    void Update()
    {
        // when Player press I to water the plant, it will add 1 point
       // if (Input.GetKeyDown(KeyCode.I))
      //  {
          //  WaterPlant(1);
       // }
    }
}
