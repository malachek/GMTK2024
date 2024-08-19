using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BugsAI : MonoBehaviour{

    public enum BugState{
        Wandering,
        Talking,
    }

    [SerializeField] private GameObject plantBase;
    private BugState bugState;
    private NavMeshAgent agent;
    private Vector3 currentTargetPoint;
    private bool onTargetPoint;

    [SerializeField] private float range;
    [SerializeField] private float paddingDistance;

    private void Start(){
        bugState = BugState.Wandering;
        agent = GetComponent<NavMeshAgent>();
        currentTargetPoint = SetNewPoint();
        agent.SetDestination(currentTargetPoint);
    }

    private void Update(){
        switch (bugState){
            case BugState.Wandering:

                if((Mathf.Abs((currentTargetPoint - transform.position).magnitude) - paddingDistance) <= 0){
                    onTargetPoint = true;
                }else{
                    onTargetPoint = false;
                }

                if(onTargetPoint){
                    currentTargetPoint = SetNewPoint();
                    agent.SetDestination(currentTargetPoint);
                }

                break;
            case BugState.Talking:
                break;
        }
    }

    public void SetPlantBase(PlantBase plantBase){
        //this.plantBase = plantBases;
    }

    private Vector3 SetNewPoint(){
        float targetZPoint = Random.Range(-range, range);
        float targetXPoint = Random.Range(-range, range);
        Vector3 newPoint = new Vector3(plantBase.transform.position.x + targetXPoint, transform.position.y, plantBase.transform.position.z + targetZPoint);
        return newPoint;
    }
}
