using System.Linq;
using UnityEngine;

public class OrderChildByActive : MonoBehaviour
{
    void Start()
    {
        // Parent GameObject'i seç
        GameObject parentObject = GameObject.Find("Weapon Display Holder");

        if (parentObject != null)
        {
            // Parent GameObject'in altýndaki child GameObject'leri al
            Transform[] childTransforms = parentObject.GetComponentsInChildren<Transform>(true);

            // Aktif olma durumuna göre child GameObject'leri sýrala
            childTransforms = childTransforms.OrderBy(child => child.gameObject.activeSelf).ToArray();

            // Yeni sýralamayý parent GameObject'e uygula
            for (int i = 0; i < childTransforms.Length; i++)
            {
                childTransforms[i].SetSiblingIndex(i);
            }
        }
        else
        {
            Debug.LogError("Parent GameObject bulunamadý.");
        }
    }
}