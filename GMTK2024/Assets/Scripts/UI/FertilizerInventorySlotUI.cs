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

    private const string SELECTED = "PurchaseStatus";

    private void Start(){
        OnIdle();
    }

    private void OnIdle(){
        background.color = colorIdle;
        nameText.text = inventoryStackSO.baseDataSOArray[0].objectsName;
        countText.text = inventoryStackSO.itemsInStack.ToString();
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
