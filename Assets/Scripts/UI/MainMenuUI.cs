using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] GameObject mainMenu, inventoryAndEquipment;
    [SerializeField] Button play, inventory, shop, exit;

    private void Awake()
    {
        play.onClick.AddListener(() => Play());
        inventory.onClick.AddListener(() => InventoryMenu());
        shop.onClick.AddListener(() => ShopMenu());
        exit.onClick.AddListener(() => ExitGame());
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void ShopMenu()
    {
        //add shop
    }

    private void InventoryMenu()
    {
        inventoryAndEquipment.SetActive(true);
        mainMenu.SetActive(false);
    }

    private void Play()
    {
        SceneManager.LoadScene(1); // refactor here
    }
}
