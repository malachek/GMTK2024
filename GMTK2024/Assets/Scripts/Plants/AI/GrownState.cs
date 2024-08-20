using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static GrownState;

public class GrownState : PlantState
{
    static bool FirstHasBeenPlanted;

    public delegate void ReachedFullGrown();
    public static event ReachedFullGrown OnReachedFullGrown;

    public GrownState(PlantBase _plantBase) : base(_plantBase)
    {
        stateName = STATE.GROWN;
    }

    public override void Enter()
    {
        if(!FirstHasBeenPlanted)
        {
            OnReachedFullGrown?.Invoke();
            FirstHasBeenPlanted = true;
        }
        TimeManager.OnNewDay += HandleNewDay;
        Debug.Log($"Plant: {plantBase.name} is Entering Grown State");
        base.Enter();
    }

    private void HandleNewDay(int day)
    {
        Debug.Log($"{plantBase.name} grants ${plantBase.GetIncome()} <- pls optimize this code");
        GameObject.FindObjectOfType<PlayerInventory>().AddMoney(plantBase.GetIncome());
    }
}
