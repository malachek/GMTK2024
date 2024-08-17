using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryStackSO : ScriptableObject{

    public EItemType stackType;
    public BaseDataSO[] baseDataSOArray;
    public int itemsInStack;
}
