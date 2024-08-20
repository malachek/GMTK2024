using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/InventoryStackSO")]
public class InventoryStackSO : ScriptableObject{

    public EItemType stackType;
    public BaseDataSO[] baseDataSOArray;
    public int itemsInStack;

    private void AssignValues(EItemType stackType, BaseDataSO[] baseDataSOArray, int itemsInStack){

        this.stackType = stackType;
        this.baseDataSOArray = baseDataSOArray;
        this.itemsInStack = itemsInStack;
    }

    public static InventoryStackSO CreateInstance(EItemType stackType, BaseDataSO[] baseDataSOArray, int itemsInStack = 0){

        InventoryStackSO newInventoryStackSO = ScriptableObject.CreateInstance<InventoryStackSO>();
        newInventoryStackSO.AssignValues(stackType, baseDataSOArray, itemsInStack);
        return newInventoryStackSO;
    }
}
