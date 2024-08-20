using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedState : PlantState
{
    private int daysPassed = 0;

    public SeedState(PlantBase _plantBase) : base(_plantBase)
    {
        stateName = STATE.SEED;
    }

    private void HandleNewDay(int day)
    {
        daysPassed++;

        if(CanSprout())
        {
            nextState = new SproutState(plantBase);
            stage = EVENT.EXIT;
            return;
        }
    }

    private bool CanSprout()
    {
        return (daysPassed * plantBase.my_Points >= 4);
    }

    public override void Enter()
    {
        Debug.Log($"Plant: {plantBase.name} is Entering Seed State");
        TimeManager.OnNewDay += HandleNewDay;
        base.Enter();
    }

    //update isnt needed here, HandleNewDay does a better job in this case

    public override void Exit()
    {
        TimeManager.OnNewDay -= HandleNewDay;
        base.Exit();
    }
}
