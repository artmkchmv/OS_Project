using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalQuest : MonoBehaviour
{
    public GameObject bear;
    public GameObject fish;

    public void OnTriggerEnter2D(Collider2D fishCollider)
    {
        if (fishCollider.name == "fish")
        {
            Instantiate(bear, new Vector3((float)-85.6, (float)1.09), Quaternion.identity);
            Destroy(fish);
        }
    }
}
