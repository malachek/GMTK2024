using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAI : MonoBehaviour
{
    PlantBase plantBase;
    PlantState currentState;

    void Awake()
    {
        plantBase = GetComponent<PlantBase>();
        currentState = new SeedState(plantBase);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
    }

    public bool IsGrown()
    {
        return (currentState.stateName == PlantState.STATE.GROWN);
    }
}
