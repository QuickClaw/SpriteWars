using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    public Vector3 spawnAreaCenter; // Instantiate edilecek alanýn merkezi
    public Vector3 spawnAreaSize;   // Instantiate edilecek alanýn boyutlarý
    public float instantiateInterval = 5.0f;

    private float timer = 0.0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= instantiateInterval)
        {
            // Belirtilen alan içinde rastgele bir pozisyon üretme
            Vector3 randomSpawnPosition = new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
            ) + spawnAreaCenter;

            // Prefab'ý belirtilen pozisyonda instantiate etme
            Instantiate(prefabToInstantiate, randomSpawnPosition, Quaternion.identity);

            timer = 0.0f;
        }
    }
}