using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishChecker : MonoBehaviour
{
    public GameObject bear;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.name == "FishCarryChecker")
        {
            ArrowsStart.arrowFishDrop.SetActive(false);
            Instantiate(bear, new Vector3((float)-85.8, (float)1.29), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
