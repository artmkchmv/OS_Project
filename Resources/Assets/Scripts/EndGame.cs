using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject fadeObj;
    public GameObject player;
    private GameObject mainCanvas;
    private Animator fadeAnimator;
    private int delay = 5;

    private void Start()
    {
        fadeObj = GameObject.Find("EndFade");
        player = GameObject.Find("Player");
        fadeAnimator = fadeObj.GetComponent<Animator>();
        mainCanvas = GameObject.Find("UI_Inventory");
    }

    private void Update()
    {
        if (PlayerController.dieStatus)
        {
            GameEnding();
            this.enabled = false;
        }
    }

    public void GameEnding()
    {
        fadeAnimator.SetTrigger("endFade");
        StartCoroutine(ChangeSceneAfterDelay(delay));
    }

    private IEnumerator ChangeSceneAfterDelay(int delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
    }
}
