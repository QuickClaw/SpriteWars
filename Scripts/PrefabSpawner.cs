using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabToInstantiate;

    public Vector3 spawnAreaCenter; // Instantiate edilecek alanýn merkezi
    public Vector3 spawnAreaSize;   // Instantiate edilecek alanýn boyutlarý

    public float instantiateInterval;

    private float timer;

    public GameObject spawnMark;

    private Vector3 spawnPos;

    public bool markCreated;

    private void Update()
    {
        timer += Time.deltaTime;

        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        if (timer >= instantiateInterval - 1)
        {
            if (!markCreated)
            {
                spawnPos = new Vector3(
                 Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                 Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2), 0f
             ) + spawnAreaCenter;

                Instantiate(spawnMark, spawnPos, Quaternion.identity);

                markCreated = true;
            }
        }

        if (timer >= instantiateInterval)
        {
            Instantiate(prefabToInstantiate, spawnPos, Quaternion.identity);

            markCreated = false;

            timer = 0.0f;
        }
    }
}