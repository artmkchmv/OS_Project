using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC_2 : MonoBehaviour
{
    public Animator button;
    public Animator text1;
    public Animator text2;
    public GameObject player;
    public static GameObject questCollider;
    public GameObject questItem;
    public static GameObject questBearWall;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        questCollider = GameObject.Find("NPC_2_Dialog");
        questCollider.SetActive(false);
        questBearWall = GameObject.Find("QuestBearWall");
        questBearWall.SetActive(true);
    }

    public void StartDialog()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        text1.SetBool("start2_1", true);
    }

    public void NextDialog()
    {
        text1.SetBool("start2_1", false);
        text2.SetBool("start2_2", true);
    }

    public void AcceptDialog()
    {
        ArrowsStart.arrowNPC2.SetActive(false);
        ArrowsStart.arrowFishCarry.SetActive(true);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        text2.SetBool("start2_2", false);
        Instantiate(questItem, new Vector3((float)31.49, (float)-26.24), Quaternion.identity);
        questCollider.SetActive(false);
        Destroy(questBearWall);
        FishCarryChecker.fishFlag = true;
    }
}
