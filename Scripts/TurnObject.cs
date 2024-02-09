using UnityEngine;

public class TurnObject : MonoBehaviour
{
    public float turnZAxis;

    void Update()
    {
        transform.Rotate(0f, 0f, turnZAxis * Time.deltaTime);
    }
}