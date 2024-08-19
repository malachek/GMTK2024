using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour{

    [SerializeField] private float money;
    [SerializeField] private int maxInvetorySize;

    private InventoryStackSO[] inventory;
    private int itemsInInventory;

    private void Awake(){
        inventory = new InventoryStackSO[maxInvetorySize];
        PlayerInput playerInput = new PlayerInput();
    }

    public void AddItemToInventory(BaseDataSO baseDataSO){
        if(itemsInInventory <= maxInvetorySize){
            if(baseDataSO.stackMax >= 1){
                int index = SearchInInventory(baseDataSO);
                if(index > -1 && inventory[index].itemsInStack < inventory[index].baseDataSOArray.Length-1){
                    inventory[index].baseDataSOArray[inventory[index].itemsInStack] = baseDataSO;
                    inventory[index].itemsInStack++;
                }
                else{
                    InventoryStackSO newStack = new InventoryStackSO{
                        stackType = baseDataSO.eItemType,
                        baseDataSOArray = new BaseDataSO[baseDataSO.stackMax],
                        itemsInStack = 0
                    };
                    newStack.baseDataSOArray[newStack.itemsInStack] = baseDataSO;
                    newStack.itemsInStack++;
                    inventory[itemsInInventory] = newStack;
                    itemsInInventory++;
                }
            }
        }
    }

    private int SearchInInventory(BaseDataSO baseDataSO){
        int index = 0;
        foreach (InventoryStackSO inventoryStackSO in inventory){
            index++;
            if(inventoryStackSO.stackType == baseDataSO.eItemType){
                return index;
            }
        }
        return -1;
    }

    public BaseDataSO GetItemFromInventory(BaseDataSO baseDataSO){
        int index = SearchInInventory(baseDataSO);
        if(index > -1){
            inventory[index].itemsInStack--;
            BaseDataSO temp = inventory[index].baseDataSOArray[inventory[index].itemsInStack];
            inventory[index].baseDataSOArray[inventory[index].itemsInStack] = null;
            itemsInInventory--;
            return temp;
        }
        return null;
    }
}
