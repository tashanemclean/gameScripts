using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour 
{
    public static InventoryController Instance { get; set; }
    public PlayerWeaponController playerWeaponController;
    public ConsumableController consumableController;
    public Item sword;
    public Item staff;
    public Item PotionLog;

    void Start()
    {
        GameObject.Find("Hand").GetComponent<SkinnedMeshRenderer>().enabled = false;
        //
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        playerWeaponController = GetComponent<PlayerWeaponController>();
        consumableController = GetComponent<ConsumableController>();
        List<BaseStat> swordStats = new List<BaseStat>();
        swordStats.Add(new BaseStat(6, "Strength", "Your strength level"));
        staff = new Item(swordStats, "staff");
        sword = new Item(swordStats, "sword");

        PotionLog = new Item(new List<BaseStat>(), "potion_log", "Drink to become the drunken master!", "Drink", "Log Potion", false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            GameObject.Find("Hand").GetComponent<SkinnedMeshRenderer>().enabled = true;
            playerWeaponController.EquipWeapon(sword);

        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            consumableController.ConsumeItem(PotionLog);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            GameObject.Find("Hand").GetComponent<SkinnedMeshRenderer>().enabled = false;
            playerWeaponController.EquipWeapon(staff);
        }
    }
}
