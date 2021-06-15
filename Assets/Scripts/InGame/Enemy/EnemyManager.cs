using System.Collections;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [Header("Default Parameters")]
    [SerializeField] private float spawnStartDelay = 0f;
    [SerializeField] private float enemySpawnRate = 1f;
    [SerializeField] private GameObject defaultEnemyPrefab;
    [SerializeField] private float _defaultSpeed = 1;
    public float Speed
    {
        get
        {
            if (slowRate > 0)
                return _defaultSpeed * (1f - slowRate);
            return _defaultSpeed;
        }
    }
    [SerializeField] private Vector3 spawnSize;
    public Vector3 CurrentSize
    {
        get
        {
            if (resizeFactor != 1)
            {
                return spawnSize * resizeFactor;
            }
            return spawnSize;
        }
    }
    [Header("Parameters")]
    [Range(0, 1)]
    public float slowRate = 0;
    public float resizeFactor = 1;
    public float startMoveDelay = 1;
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnStartDelay, enemySpawnRate);
    }
    void SpawnEnemy()
    {
        Vector2 randomSpawnPoint = CreateRandomEnemySpawnPoint();
        Vector2 direction = CreateRandomDirection(randomSpawnPoint);
        GameObject instantiatedEnemy = Instantiate(defaultEnemyPrefab, randomSpawnPoint, Quaternion.identity);
        instantiatedEnemy.transform.localScale = CurrentSize;
        instantiatedEnemy.GetComponent<EnemyController>().direction = direction;
    }
    Vector2 CreateRandomEnemySpawnPoint()
    {
        int randomIndex = Random.Range(0, 4);
        switch (randomIndex)
        {
            case 0:
                Vector2 TopSideEnemySpawnPoint = new Vector2(
                    Random.Range(GameManager.Instance.GameAreaToWorldPointMin.x + CurrentSize.x / 2, GameManager.Instance.GameAreaToWorldPointMax.x - CurrentSize.x / 2),
                    GameManager.Instance.GameAreaToWorldPointMax.y - CurrentSize.y / 2);
                return TopSideEnemySpawnPoint;
            case 1:
                Vector2 RightSideEnemySpawnPoint = new Vector2(
                    GameManager.Instance.GameAreaToWorldPointMax.x - CurrentSize.x / 2,
                    Random.Range(GameManager.Instance.GameAreaToWorldPointMin.y + CurrentSize.y / 2, GameManager.Instance.GameAreaToWorldPointMax.y - CurrentSize.y / 2));
                return RightSideEnemySpawnPoint;
            case 2:
                Vector2 BottomSideEnemySpawnPoint = new Vector2(
                      Random.Range(GameManager.Instance.GameAreaToWorldPointMin.x + CurrentSize.x / 2, GameManager.Instance.GameAreaToWorldPointMax.x - CurrentSize.x / 2),
                      GameManager.Instance.GameAreaToWorldPointMin.y + CurrentSize.y / 2);
                return BottomSideEnemySpawnPoint;
            case 3:
                Vector2 LeftSideEnemySpawnPoint = new Vector2(GameManager.Instance.GameAreaToWorldPointMin.x + CurrentSize.x / 2,
                      Random.Range(GameManager.Instance.GameAreaToWorldPointMin.y + CurrentSize.y / 2, GameManager.Instance.GameAreaToWorldPointMax.y - CurrentSize.y / 2));
                return LeftSideEnemySpawnPoint;
            default:
                return Vector2.zero;
        }
    }
    Vector2 CreateRandomDirection(Vector2 spawnPoint)
    {
        Vector2 direction = new Vector2();
        if (spawnPoint.x < 0)
            direction.x = 1;
        else
            direction.x = -1;

        if (spawnPoint.y < 0)
            direction.y = 1;
        else
            direction.y = -1;

        return direction;
    }
    public void Freeze(float duration = 1)
    {
        StartCoroutine(FreezeCoroutine(duration));
    }
    public void Slow(float duration, float time)
    {
        StartCoroutine(SlowCoroutine(duration, time));
    }
    IEnumerator FreezeCoroutine(float duration = 1)
    {
        slowRate = 1;
        yield return new WaitForSeconds(duration);
        slowRate = 0;
    }
    IEnumerator SlowCoroutine(float duration, float time)
    {
        slowRate = duration;
        yield return new WaitForSeconds(time);
        slowRate = 0;
    }
}
