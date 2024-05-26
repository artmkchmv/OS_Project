using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private Animator animator;
    public int sceneNum;
    public Vector3 position;
    public VectorValue playerStorage;

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
