using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrownState : PlantState
{
    public GrownState(PlantBase _plantBase) : base(_plantBase)
    {
        stateName = STATE.GROWN;
    }

    public override void Enter()
    {
        Debug.Log($"Plant: {plantBase.name} is Entering Grown State");
        base.Enter();
    }
}
