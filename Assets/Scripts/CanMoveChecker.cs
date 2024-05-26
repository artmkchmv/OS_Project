using UnityEngine;

public class CanMoveChecker : MonoBehaviour
{
    public GameObject[] cans;
    public static bool status;

    private void Start()
    {
        status = false;
    }

    private void Update()
    {
        if (AllCansMoved())
        {
            status = true;
            DialogNPC_3.questCollider2.SetActive(true);
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