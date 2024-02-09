using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private float destroyTime;

    public int penetrationCount;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}