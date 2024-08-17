using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<ItemStockSO> itemStockSOList;

    private void Start(){
        //Subscribe to an event that will call BuyItem when the player wants to buy an item.
    }


    // Should also have a player parameter or at least inventory
    public void BuyItem(StoreItemSO itemSO){

        foreach (ItemStockSO itemStockSO in itemStockSOList){
            if (itemStockSO.itemSO.itemType == itemSO.itemType){
                if(itemStockSO.inStock > 0){
                    if(Transaction(itemSO)){
                        //Transaction was completed Successfuly 

                        // Add item to players inventory

                        itemStockSO.itemSold++;
                        itemStockSO.inStock--;

                        if(itemStockSO.inStock != itemStockSO.stockLimit){
                            StartCoroutine(Restock(itemStockSO));
                        }
                    }
                } 
            }
        }

        Debug.Log("item was not found in the shop");
    }

    // should take a payer script as parameter
    private bool Transaction(StoreItemSO itemSO){

        bool isTransactionSuccessful = false;
        
        //Check and update price 

        //Check for money and do transaction
        
        return isTransactionSuccessful;
    }

    //Runs a timer in the background and increases the stock
    private IEnumerator Restock(ItemStockSO itemStockSO){
        for (int i = 0; i < 10; i++){
            if(itemStockSO.inStock == itemStockSO.stockLimit) break;
            yield return new WaitForSeconds(itemStockSO.restockTime);
            itemStockSO.inStock++;
        }
    }
}
