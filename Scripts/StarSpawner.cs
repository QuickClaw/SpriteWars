using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabToInstantiate;

    public Vector3 spawnAreaCenter; // Instantiate edilecek alanýn merkezi
    public Vector3 spawnAreaSize;   // Instantiate edilecek alanýn boyutlarý

    private Vector3 spawnPos;

    public int minStarCount = 2;
    public int maxStarCount = 8;
    public int prefabToInstantiateCount;

    private void Awake()
    {
        prefabToInstantiateCount = Random.Range(minStarCount, maxStarCount);
    }

    void Start()
    {
        for (int i = 0; i < prefabToInstantiateCount; i++)
            SpawnStar();
    }

    public void SpawnStar()
    {
        spawnPos = new Vector3(
         Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
         Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2), 0f
     ) + spawnAreaCenter;

        Instantiate(prefabToInstantiate, spawnPos, Quaternion.identity);
    }
}