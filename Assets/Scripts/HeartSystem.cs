using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public static int health;
    public GameObject Heart0, Heart1, Heart2, Heart3;
    private void Start()
    {
        Heart0.SetActive(false);
        Heart1.SetActive(false);
        Heart2.SetActive(false);
        Heart3.SetActive(true);
        health = 3;
    }

    private void Update()
    {
        switch (health)
        {
            case 0:
                Heart0.SetActive(true);
                Heart1.SetActive(false);
                break;
            case 1:
                Heart1.SetActive(true);
                Heart2.SetActive(false);
                break;
            case 2:
                Heart2.SetActive(true);
                Heart3.SetActive(false);
                break;
        }
    }
}
