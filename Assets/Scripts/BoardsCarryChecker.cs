using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardsCarryChecker : MonoBehaviour
{
    private Inventory inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (inventory.isFull[0] == true)
        {
            ArrowsStart.arrowBoardsCarry.SetActive(false);
            ArrowsStart.arrowBoardsDrop.SetActive(true);
            this.enabled = false;
        }
    }
}
