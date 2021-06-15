using UnityEngine;

public class GameArea : MonoBehaviour
{
    public GameObject background;
    public Vector2 backgroundSizePercent;
    public float backgroundTopOffsetPercent;

    void Start()
    {
        //Physics2D.autoSyncTransforms = true;
        float backgroundScaleX = GameManager.Instance.ScreenSizeToWorldPoint.x * 2f * backgroundSizePercent.x / 100f;
        float backgroundScaleY = GameManager.Instance.ScreenSizeToWorldPoint.y * 2f * backgroundSizePercent.y / 100f;
        background.transform.localScale = new Vector2(backgroundScaleX, backgroundScaleY);
        float topOffsetSubstracted = GameManager.Instance.ScreenSizeToWorldPoint.y - GameManager.Instance.ScreenSizeToWorldPoint.y * 2f * backgroundTopOffsetPercent / 100f;
        float topOffset = topOffsetSubstracted - backgroundScaleY / 2f;
        background.transform.position = new Vector2(background.transform.position.x, topOffset);

        Physics2D.SyncTransforms();
        //Game Area Min and Max points
        Vector2 minPoint = new Vector2(background.transform.position.x - backgroundScaleX / 2,
            background.transform.position.y - backgroundScaleY / 2);
        Vector2 maxPoint = new Vector2(background.transform.position.x + backgroundScaleX / 2,
        background.transform.position.y + backgroundScaleY / 2);
        GameManager.Instance.GameAreaToWorldPointMin = minPoint;
        GameManager.Instance.GameAreaToWorldPointMax = maxPoint;
    }
    void CalculateGameAreaScreenToWorldPoint()
    {

    }
}
