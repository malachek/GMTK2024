using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManagerUI : MonoBehaviour{
    [SerializeField] private Button exitButton;
    [SerializeField] private Button openShopButton;
    [SerializeField] private Button goBackButton;
    [SerializeField] private Button seedsButton;
    [SerializeField] private Button fertilizerButton;
    [SerializeField] private Button decorationsButton;

    [SerializeField] private TextMeshProUGUI moneyText;

    [SerializeField] private GameObject seedsContainer;
    [SerializeField] private GameObject fertilizersContainer;
    [SerializeField] private GameObject decorationsContainer;
    [SerializeField] private GameObject mainMenuShop;
    [SerializeField] private GameObject shopUI;

    void Start(){
        moneyText.text = PlayerInventory.Instance.Money.ToString();

        exitButton.onClick.AddListener(OnExitShop);
        goBackButton.onClick.AddListener(OnGoBack);
        seedsButton.onClick.AddListener(OnSeedsSection);
        fertilizerButton.onClick.AddListener(OnFertilizersSection);
        decorationsButton.onClick.AddListener(OnDecorationsSection);
        openShopButton.onClick.AddListener(Show);

        ShopManager.Instance.OnSuccessfulPurchase += ShopManager_OnSuccessfulPurchase;

        seedsContainer.SetActive(false);
        fertilizersContainer.SetActive(false);
        decorationsContainer.SetActive(false);

        shopUI.SetActive(false);
    }

    private void Show()
    {
        shopUI.SetActive(true);
    }

    private void ShopManager_OnSuccessfulPurchase(object sender, EventArgs e)
    {
        moneyText.text = PlayerInventory.Instance.Money.ToString();
    }

    private void OnDecorationsSection()
    {
        mainMenuShop.SetActive(false);
        decorationsContainer.SetActive(true);
    }

    private void OnFertilizersSection()
    {
        mainMenuShop.SetActive(false);
        fertilizersContainer.SetActive(true);
    }

    private void OnSeedsSection()
    {
        mainMenuShop.SetActive(false);
        seedsContainer.SetActive(true);
    }

    private void OnGoBack()
    {
        mainMenuShop.SetActive(true);
        seedsContainer.SetActive(false);
        fertilizersContainer.SetActive(false);
        decorationsContainer.SetActive(false);
    }

    private void OnExitShop()
    {
        seedsContainer.SetActive(false);
        fertilizersContainer.SetActive(false);
        decorationsContainer.SetActive(false);
        mainMenuShop.SetActive(true);
        shopUI.SetActive(false);
    }
}
