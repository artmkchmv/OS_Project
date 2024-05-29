using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerMenu : MonoBehaviour
{
    public Canvas overlayCanvas;
    public Animator animator;  

    private bool isOverlayActive = false;

    public void ToggleOverlay()
    {
        if (!isOverlayActive)
        {
            overlayCanvas.gameObject.SetActive(true);
            animator.SetTrigger("show");
        }
        else
        {
            animator.SetTrigger("hide");
            StartCoroutine(DeactivateAfterDelay(animator.GetCurrentAnimatorStateInfo(0).length));
        }

        isOverlayActive = !isOverlayActive;
    }

    private IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        overlayCanvas.gameObject.SetActive(false);
    }
}
