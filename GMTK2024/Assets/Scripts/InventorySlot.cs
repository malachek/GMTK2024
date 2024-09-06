using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour {

    [SerializeField] private EItemType eItemType;
    [SerializeField] private InventoryType inventoryType;
    [SerializeField] private InventorySlotUI inventorySlotUI;
    [SerializeField] private FertilizerInventorySlotUI fertilizerInventorySlotUI;
    [SerializeField] private Transform seedPack;
    [SerializeField] private Transform seedPackSpawnLocation;

    private InventoryStackSO inventoryStackSO;

    public enum InventoryType{
        Seed,
        Fertilizer,
        Decoration
    }

    private void Start(){
        switch (inventoryType){
            case InventoryType.Seed:
                inventoryStackSO = PlayerInventory.Instance.GetInventoryStackSO(eItemType, PlayerInventory.Instance.SeedsInventory);
                break;
            case InventoryType.Fertilizer:
                inventoryStackSO = PlayerInventory.Instance.GetInventoryStackSO(eItemType, PlayerInventory.Instance.FertilizerInventory);
                break;
            case InventoryType.Decoration:
                inventoryStackSO = PlayerInventory.Instance.GetInventoryStackSO(eItemType, PlayerInventory.Instance.DecorationsInventory);
                break;
        }
    }

    public void OnInteract(InteractGodMode interactGodMode)
    {
        Debug.Log("Interacted with inventory");
        if(inventoryStackSO.itemsInStack >= 1){
            BaseDataSO baseDataSO = inventoryStackSO.baseDataSOArray[inventoryStackSO.itemsInStack-1];
            
            switch (inventoryType){
                case InventoryType.Seed:
                    Instantiate(seedPack, seedPackSpawnLocation.position, Quaternion.identity);
                    inventoryStackSO.baseDataSOArray[inventoryStackSO.itemsInStack-1] = null;
                    inventoryStackSO.itemsInStack--;
                    inventorySlotUI.UpdateVisuals(inventoryStackSO.itemsInStack);
                    break;
                case InventoryType.Fertilizer:
                    interactGodMode.SetBaseDataSO(baseDataSO);
                    fertilizerInventorySlotUI.OnSelected();
                    break;
                case InventoryType.Decoration:
                    //For later
                    break;
            }
        }
    }
}
