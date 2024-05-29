using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC_3 : MonoBehaviour
{
    public Animator button1;
    public Animator button2;
    public Animator text1;
    public Animator text2;
    public Animator text3;
    public GameObject player;
    public static GameObject questCollider1;
    public static GameObject questCollider2;
    public GameObject questItem;
    private Rigidbody2D rb;
    public static GameObject questCansWall;
    private static int questStatus;

    private void Start()
    {
        questStatus = 0;
        rb = player.GetComponent<Rigidbody2D>();
        questCollider1 = GameObject.Find("NPC_3_Dialog");
        questCollider2 = GameObject.Find("NPC_3_2_Dialog");
        questCollider1.SetActive(false);
        questCollider2.SetActive(false);
        questCansWall = GameObject.Find("QuestCansWall");
    }

    public void StartDialog()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        if (questStatus == 0)
        {
            questCollider1.SetActive(false);
            button1.SetTrigger("isTriggered");
            text1.SetBool("start3_1", true);
        }
        else
        {
            questCollider2.SetActive(false);
            button2.SetTrigger("isTriggered");
            text3.SetBool("start3_3", true);
        }
    }

    public void NextDialog()
    {
        text1.SetBool("start3_1", false);
        text2.SetBool("start3_2", true);
    }

    public void AcceptDialog()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (questStatus == 0)
        {
            text2.SetBool("start3_2", false);
            Destroy(questCansWall);
            questStatus = 1;
            ArrowsStart.arrowNPC3.SetActive(false);
            ArrowsStart.arrowCans.SetActive(true);
        }
        else
        {
            text3.SetBool("start3_3", false);
            Instantiate(questItem, new Vector3((float)69, (float)-24), Quaternion.identity);
            ArrowsStart.arrowNPC3.SetActive(false);
            ArrowsStart.arrowBoardsCarry.SetActive(true);
            BoardsCarryChecker.boardsFlag = true;
        }
    }
}
