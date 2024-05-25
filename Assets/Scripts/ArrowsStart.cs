using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsStart : MonoBehaviour
{
    public static GameObject arrowNPC1;
    public static GameObject arrowNPC2;
    public static GameObject arrowNPC3;
    public static GameObject arrowCans;
    public static GameObject arrowBoardsCarry;
    public static GameObject arrowBoardsDrop;
    public static GameObject arrowFishCarry;
    public static GameObject arrowFishDrop;

    private void Start()
    {
        arrowNPC1 = GameObject.Find("ArrowDialog_NPC_1");
        arrowNPC1.SetActive(true);
        arrowNPC2 = GameObject.Find("ArrowDialog_NPC_2");
        arrowNPC2.SetActive(false);
        arrowNPC3 = GameObject.Find("ArrowDialog_NPC_3");
        arrowNPC3.SetActive(false);
        arrowCans = GameObject.Find("ArrowCans");
        arrowCans.SetActive(false);
        arrowBoardsCarry = GameObject.Find("ArrowBoardsCarry");
        arrowBoardsCarry.SetActive(false);
        arrowBoardsDrop = GameObject.Find("ArrowBoardsDrop");
        arrowBoardsDrop.SetActive(false);
        arrowFishCarry = GameObject.Find("ArrowFishCarry");
        arrowFishCarry.SetActive(false);
        arrowFishDrop = GameObject.Find("ArrowFishDrop");
        arrowFishDrop.SetActive(false);
    }
}
