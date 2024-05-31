using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardsCarryChecker : MonoBehaviour
{
    public static bool boardsFlag;
    private Inventory inventory;

    private void Start()
    {
        boardsFlag = false;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (inventory.isFull[0] == true && boardsFlag)
        {
            ArrowsStart.arrowBoardsCarry.SetActive(false);
            ArrowsStart.arrowBoardsDrop.SetActive(true);
            this.enabled = false;
        }
    }
}
