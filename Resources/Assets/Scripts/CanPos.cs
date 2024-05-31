using UnityEngine;

public class CanPos : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    public bool HasMoved()
    {
        return transform.position != initialPosition;
    }
}