using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Soil : MonoBehaviour
{
    public float SoilHealth { get; private set; } = 100f;

    public int healthBracket = 0;

    [SerializeField] MeshRenderer[] HealthStripMeshes;

    public delegate void SoilQualityChange(int healthBracket);
    public static event SoilQualityChange OnSoilQualityChange;

    void Awake()
    {
        TimeManager.OnNewDay += DegrateSoilHealth;
    }

    private void DegrateSoilHealth(int day)
    {
        float healthToLose = 2f * FindObjectsOfType<PlantAI>().Count(plantAI => plantAI.IsGrown());

        SoilHealth -= healthToLose;
        Debug.Log($"SOIL loses {healthToLose} health");

        int newHealthBracket = -1;
        switch (SoilHealth)
        {
            case >= 100f:
                newHealthBracket = 0;
                break;
            case >= 80f:
                newHealthBracket = 1;
                break;
            case >= 50f:
                newHealthBracket = 2;
                break;
            default:
                newHealthBracket = 3;
                break;
        }
        
        if (newHealthBracket != healthBracket)
        {
            OnSoilQualityChange?.Invoke(newHealthBracket);
            healthBracket = newHealthBracket;
            UpdateIndicatorStrip();
        }
    }

    private void UpdateIndicatorStrip()
    {
        for (int i = 0; i < 4; i++)
        {
            HealthStripMeshes[i].enabled = (healthBracket <= i);
        }
    }

    public void HealSoil(float healAmount)
    {
        SoilHealth += healAmount;
    }
}
