using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour{

    [SerializeField] private float money;
    [SerializeField] private int maxInvetorySize;
    [SerializeField] private InventoryStackSO[] seedsInventory, fertilizerInventory;
    private int itemsInInventory;

    public float Money {get => money; private set => money = value;}
    public InventoryStackSO[] SeedsInventory {get {return seedsInventory;} private set{}}
    public InventoryStackSO[] FertilizerInventory {get {return fertilizerInventory;} private set{}}

    public static PlayerInventory Instance {get; private set;}

    private void Awake(){
        Instance = this;
    }

    public void AddItemToInventory(BaseDataSO baseDataSO, InventoryStackSO[] inventory){
        //if(itemsInInventory <= maxInvetorySize){
            if(baseDataSO.stackMax >= 1){
                int index = SearchInInventory(baseDataSO, inventory);
                if(index > -1 && (inventory[index] != null)){
                    if(inventory[index].itemsInStack < inventory[index].baseDataSOArray.Length-1){
                        inventory[index].baseDataSOArray[inventory[index].itemsInStack] = baseDataSO;
                        inventory[index].itemsInStack++;
                        itemsInInventory++;
                    }
                }
            }
        //}
    }

    private int SearchInInventory(BaseDataSO baseDataSO, InventoryStackSO[] inventory){
        int index = 0;
        foreach (InventoryStackSO inventoryStackSO in inventory){
            index++;
            if(inventoryStackSO != null){
                if(inventoryStackSO.stackType == baseDataSO.eItemType){
                    return index;
                }
            }
        }
        return -1;
    }

    public BaseDataSO GetItemFromInventory(BaseDataSO baseDataSO, InventoryStackSO[] inventory){
        int index = SearchInInventory(baseDataSO, inventory);
        if(index > -1){
            inventory[index].itemsInStack--;
            BaseDataSO temp = inventory[index].baseDataSOArray[inventory[index].itemsInStack];
            inventory[index].baseDataSOArray[inventory[index].itemsInStack] = null;
            itemsInInventory--;
            return temp;
        }
        return null;
    }

    public void RemoveMoney(float amount){
        money -= amount;
    }

    public void AddMoney(float amount){
        money += amount;
    }
}
