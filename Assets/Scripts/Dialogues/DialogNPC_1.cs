using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC_1 : MonoBehaviour
{
    public Animator button1;
    public Animator button2;
    public Animator text1;
    public Animator text2;
    public Animator text3;
    public Animator text4;
    public GameObject player;
    public static GameObject questCollider1;
    public static GameObject questCollider2;
    private static int questStatus;
    private Rigidbody2D rb;

    private void Start()
    {
        questStatus = 0;
        rb = player.GetComponent<Rigidbody2D>();
        questCollider1 = GameObject.Find("NPC_1_Dialog");
        questCollider2 = GameObject.Find("NPC_1_2_Dialog");
        questCollider2.SetActive(false);
    }

    public void StartDialog()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        if (questStatus == 0)
        {
            text1.SetBool("start", true);
        }
        else
        {
            text3.SetBool("start1_3", true);
        }
    }

    public void NextDialog()
    {
        if (questStatus == 0)
        {
            text1.SetBool("start", false);
            text2.SetBool("start1_2", true);
        }
        else
        {
            text3.SetBool("start1_3", false);
            text4.SetBool("start1_4", true);
        }
    }

    public void AcceptDialog()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (questStatus == 0)
        {
            text2.SetBool("start1_2", false);
            questCollider1.SetActive(false);
            button1.SetTrigger("isTriggered");
            questStatus = 1;
            DialogNPC_3.questCollider1.SetActive(true);
            ArrowsStart.arrowNPC1.SetActive(false);
            ArrowsStart.arrowNPC3.SetActive(true);
        }
        else
        {
            ArrowsStart.arrowNPC1.SetActive(false);
            ArrowsStart.arrowNPC2.SetActive(true);
            text4.SetBool("start1_4", false);
            questCollider2.SetActive(false);
            DialogNPC_2.questCollider.SetActive(true);
        }
    }
}
