using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlantAI : MonoBehaviour
{
    PlantBase plantBase;
    PlantState currentState;
    [SerializeField] Transform bug;
    private Transform location;

    private bool spawned;

    void Awake()
    {
        plantBase = GetComponent<PlantBase>();
        currentState = new SeedState(plantBase);
        location = FindFirstObjectByType<Soil>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
        if(currentState.stateName == SeedState.STATE.GROWN && !spawned){
            spawned = true;
            Transform BugAI = Instantiate(bug, transform.position, Quaternion.identity);
            BugAI.SetParent(GameObject.Find("NavMesh Surface").transform);
            BugAI.GetComponent<BugsAI>().SetPlantBase(plantBase);
        }
    }

    public bool IsGrown()
    {
        return (currentState.stateName == PlantState.STATE.GROWN);
    }
}
