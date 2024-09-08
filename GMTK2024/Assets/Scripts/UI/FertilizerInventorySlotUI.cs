using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FertilizerInventorySlotUI : MonoBehaviour{

    [SerializeField] private Color colorIdle;
    [SerializeField] private Color colorSelected;
    [SerializeField] private Image background; 
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private Animator animator;
    [SerializeField] private InventoryStackSO inventoryStackSO;
    [SerializeField] private BaseDataSO baseDataSO;

    private const string SELECTED = "PurchaseStatus";

    private void Start(){
        ShopManager.Instance.OnSuccessfulPurchase +=  ShopManager_OnSuccessfulPurchase;
        OnIdle();
    }

    private void ShopManager_OnSuccessfulPurchase(object sender, EventArgs e)
    {
        countText.text = inventoryStackSO.itemsInStack.ToString();
    }

    private void OnIdle(){
        background.color = colorIdle;
        if(inventoryStackSO.baseDataSOArray[0] == null){
            countText.text = "0";
        }else{
            countText.text = inventoryStackSO.itemsInStack.ToString();
        }
        nameText.text = baseDataSO.objectsName.Substring(0, baseDataSO.objectsName.IndexOf(" ")+1);
    }

    public void OnSelected(){
        background.color = colorSelected;
        nameText.text = "SELECTED";
        countText.text = "";
        animator.SetTrigger(SELECTED);
        StartCoroutine(timer(1f));
    }

    IEnumerator timer(float time){
        
        yield return new WaitForSeconds(time);
        OnIdle();
    }
}
