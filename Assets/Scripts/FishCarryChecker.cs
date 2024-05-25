using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCarryChecker : MonoBehaviour
{
    public static bool fishFlag;
    private Inventory inventory;

    private void Start()
    {
        fishFlag = false;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (inventory.isFull[0] == true && fishFlag)
        {
            ArrowsStart.arrowFishCarry.SetActive(false);
            ArrowsStart.arrowFishDrop.SetActive(true);
            this.enabled = false;
        }
    }
}
