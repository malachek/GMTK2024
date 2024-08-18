using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantState
{
    public enum STATE
    {
        SEED, //2-4 turns after being planted, seed will sprout into a seedling
        SPROUT, //3 stages (25%, 50%, 75%) that are point-based (int addative)
        GROWN //100% grown stage - able to provide bonsus/complete bug quests
    }

    public enum EVENT
    {
        ENTER,
        UPDATE,
        EXIT
    }

    public STATE stateName;
    protected EVENT stage;
    protected PlantBase plantBase;
    protected PlantState nextState;

    public PlantState(PlantBase _plantBase)
    {
        stage = EVENT.ENTER;
        plantBase = _plantBase;
    }

    public virtual void Enter() {  stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }  
    public virtual void Exit() { stage = EVENT.EXIT; }

    public PlantState Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            Debug.Log($"{plantBase.gameObject.name} : goint to {nextState} now");
            return nextState;
        }

        return this;
    }
}
