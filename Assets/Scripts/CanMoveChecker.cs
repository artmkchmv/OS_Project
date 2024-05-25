using UnityEngine;

public class CanMoveChecker : MonoBehaviour
{
    public GameObject[] cans;
    public static bool status;
    public static GameObject questCollider;

    private void Start()
    {
        status = false;
        questCollider = GameObject.Find("NPC_3_2_Dialog");
    }

    private void Update()
    {
        if (AllCansMoved())
        {
            status = true;
            questCollider.SetActive(true);
            ArrowsStart.arrowCans.SetActive(false);
            ArrowsStart.arrowNPC3.SetActive(true);
            this.enabled = false;
        }
    }

    private bool AllCansMoved()
    {
        foreach (GameObject can in cans)
        {
            CanPos canScript = can.GetComponent<CanPos>();
            if (canScript != null && !canScript.HasMoved())
            {
                return false;
            }
        }
        return true;
    }
}