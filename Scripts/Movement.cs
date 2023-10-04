using UnityEngine;
public class Movement : MonoBehaviour
{
    public float MovementSpeed = 250;

    private void Update()
    {
        var leftRight = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(leftRight, 0, 0) * Time.deltaTime * MovementSpeed;

        var upDown = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(0, upDown, 0) * Time.deltaTime * MovementSpeed;
    }
}