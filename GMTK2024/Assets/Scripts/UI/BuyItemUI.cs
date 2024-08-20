using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyItemUI : MonoBehaviour{

    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private Image background;
    [SerializeField] private Color successColor;
    [SerializeField] private Color failedColor;
    [SerializeField] private Color successColorText;
    [SerializeField] private Color failedColorText;

    private const string ANIMATOR_TRIGGER = "PurchaseStatus";
    private Animator animator;

    void Start(){
        ShopManager.Instance.OnFailedPurchase += ShopManager_OnFailedPurchase;
        ShopManager.Instance.OnSuccessfulPurchase += ShopManager_OnSuccessfulPurchase;
        ShopManager.Instance.OnNotOnStock += ShopManager_OnNotOnStock;
        animator = GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    private void ShopManager_OnNotOnStock(object sender, EventArgs e)
    {
        gameObject.SetActive(true);
        statusText.text = "Not Available";
        statusText.color = failedColorText;
        background.color = failedColor;
        animator.SetTrigger(ANIMATOR_TRIGGER);
        StartCoroutine(Timer());
    }

    private void ShopManager_OnSuccessfulPurchase(object sender, EventArgs e)
    {
        gameObject.SetActive(true);
        statusText.text = "Successful Purchase";
        statusText.color = successColorText;
        background.color = successColor;
        animator.SetTrigger(ANIMATOR_TRIGGER);
        StartCoroutine(Timer());
    }

    private void ShopManager_OnFailedPurchase(object sender, EventArgs e)
    {
        gameObject.SetActive(true);
        statusText.text = "Not Enough Money";
        statusText.color = failedColorText;
        background.color = failedColor;
        animator.SetTrigger(ANIMATOR_TRIGGER);
        StartCoroutine(Timer());
    }

    IEnumerator Timer(){
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
