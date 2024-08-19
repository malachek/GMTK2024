using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SproutState : PlantState
{
    private int daysPassed = 0;

    private int growthQuarter = 1; // 1 - 4
    private int daysInQuarter = 0;

    public SproutState(PlantBase _plantBase) : base(_plantBase)
    {
        stateName = STATE.SEED;
    }

    private void HandleNewDay(int day)
    {
        daysPassed++;
        daysInQuarter++;

        if (CanGrow())
        {
            Grow();
        }
    }

    private void Grow()
    {
        daysInQuarter = 0;
        if(growthQuarter < 4)
        {
            growthQuarter++;
            Debug.Log("Growing to Quarter " + growthQuarter);
            plantBase.plantSprite.ScaleTo(growthQuarter/4f);
        }

        if (growthQuarter == 4)
        {
            nextState = new GrownState(plantBase);
            stage = EVENT.EXIT;
            return;
        }
    }

    private bool CanGrow()
    {
        if (daysInQuarter == 0) return false;

        switch (growthQuarter)
        {
            case 1:
                return (plantBase.my_Points >= 3);

            case 2:
                return (plantBase.my_Points >= 5);

            case 3:
                return (plantBase.my_Points >= 7);

            case 4:
                return (plantBase.my_Points >= 9);
        }
        return false;
    }

    public override void Enter()
    {
        Debug.Log($"Plant: {plantBase.name} is Entering Sprout State");
        TimeManager.OnNewDay += HandleNewDay;
        plantBase.plantSprite.ScaleTo(growthQuarter / 4);
        base.Enter();
    }

    //update isnt needed here, HandleNewDay does a better job in this case

    public override void Exit()
    {
        TimeManager.OnNewDay -= HandleNewDay;
        base.Exit();
    }
}
