using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            anim.SetTrigger("isTriggered");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            anim.SetTrigger("isTriggered");
        }
    }
}
