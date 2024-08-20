using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlantAI : MonoBehaviour
{
    PlantBase plantBase;
    PlantState currentState;
    [SerializeField] Transform bug;

    void Awake()
    {
        plantBase = GetComponent<PlantBase>();
        currentState = new SeedState(plantBase);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
        if(currentState.stateName == SeedState.STATE.GROWN){
            Instantiate(bug, transform. position, Quaternion.identity);
        }
    }

    public bool IsGrown()
    {
        return (currentState.stateName == PlantState.STATE.GROWN);
    }
}
