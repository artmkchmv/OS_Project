using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int sceneNum;
    public Vector3 position;
    public VectorValue playerStorage;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("fade");
    }

    public void OnFadeComplete()
    {
        playerStorage.intitialValue = position;
        SceneManager.LoadScene(sceneNum);
    }
}
