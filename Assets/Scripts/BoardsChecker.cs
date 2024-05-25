using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardsChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.name == "BoardsDropChecker")
        {
            ArrowsStart.arrowBoardsDrop.SetActive(false);
            ArrowsStart.arrowNPC1.SetActive(true);
            DialogNPC_1.questCollider2.SetActive(true);
            Destroy(gameObject);
        }
    }
}
