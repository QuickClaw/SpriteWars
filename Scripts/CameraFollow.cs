using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float followSpeed;

    private void Update()
    {
        if (player != null)
        {
            Vector3 yeniPozisyon = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, yeniPozisyon, followSpeed * Time.deltaTime);
        }
    }
}