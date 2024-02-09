using System.Linq;
using UnityEngine;

public class OrderChildByActive : MonoBehaviour
{
    void Start()
    {
        // Parent GameObject'i se�
        GameObject parentObject = GameObject.Find("Weapon Display Holder");

        if (parentObject != null)
        {
            // Parent GameObject'in alt�ndaki child GameObject'leri al
            Transform[] childTransforms = parentObject.GetComponentsInChildren<Transform>(true);

            // Aktif olma durumuna g�re child GameObject'leri s�rala
            childTransforms = childTransforms.OrderBy(child => child.gameObject.activeSelf).ToArray();

            // Yeni s�ralamay� parent GameObject'e uygula
            for (int i = 0; i < childTransforms.Length; i++)
            {
                childTransforms[i].SetSiblingIndex(i);
            }
        }
        else
        {
            Debug.LogError("Parent GameObject bulunamad�.");
        }
    }
}