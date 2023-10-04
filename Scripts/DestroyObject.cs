using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public int destroyTime;

    void Start()
    {
        Invoke(nameof(DestroyGameObject), destroyTime);
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}