using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineManager : Singleton<MedicineManager>
{
    [SerializeField] private List<AbstractTrigger> medicinePrefabs;
    AbstractTrigger selectedMedicinePrefab;
    Vector2 GameAreaLeftBottom, GameAreaRightTop;
    [SerializeField] float spawnRate;
    [SerializeField] float currentSpawnRate;
    bool CoroutineUpdated = true;
    Coroutine currentCoroutine;
    private void Start()
    {
        GameAreaLeftBottom = GameManager.Instance.GameAreaToWorldPointMin;
        GameAreaRightTop = GameManager.Instance.GameAreaToWorldPointMax;

        currentSpawnRate = spawnRate;
        currentCoroutine = StartCoroutine(InstantitateMedicine(currentSpawnRate));
    }
    private void Update()
    {
        if (currentSpawnRate != spawnRate)
        {
            currentSpawnRate = spawnRate;
            CoroutineUpdated = true;
        }
        if (CoroutineUpdated)
        {
            StopCoroutine(currentCoroutine);
            CoroutineUpdated = false;
            currentCoroutine = StartCoroutine(InstantitateMedicine(spawnRate));
        }
    }
    IEnumerator InstantitateMedicine(float spawnRate)
    {
        while (true)
        {
            selectedMedicinePrefab = selectRandomPrefab();
            Vector2 pos = CreateRandomMedSpawnPoint(selectedMedicinePrefab);
            var instantiated = Instantiate(selectedMedicinePrefab, pos, Quaternion.identity);
            Destroy(instantiated.gameObject, 2f);
            yield return new WaitForSeconds(spawnRate);
        }
    }
    Vector2 CreateRandomMedSpawnPoint(AbstractTrigger medicinePrefab)
    {
        Vector2 spawnPoint;
        spawnPoint = new Vector2(Random.Range(GameAreaLeftBottom.x + medicinePrefab.prefabSize / 2, GameAreaRightTop.x - medicinePrefab.prefabSize / 2),
            Random.Range(GameAreaLeftBottom.y + medicinePrefab.prefabSize / 2, GameAreaRightTop.y - medicinePrefab.prefabSize / 2));
        return spawnPoint;
    }
    AbstractTrigger selectRandomPrefab()
    {
        return medicinePrefabs[0];
    }
}
