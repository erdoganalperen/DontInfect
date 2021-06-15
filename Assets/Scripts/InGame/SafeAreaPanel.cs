using UnityEngine;
using UnityEngine.UI;

public class SafeAreaPanel : MonoBehaviour
{
    public Canvas canvas;
    RectTransform safeAreaPanelRectTransform;
    Rect currentSafeArea = new Rect();
    ScreenOrientation currentOrientation = ScreenOrientation.Portrait;
    void Start()
    {
        safeAreaPanelRectTransform = GetComponent<RectTransform>();
        currentSafeArea = Screen.safeArea;
        currentOrientation = Screen.orientation;

        ApplySafeArea();
    }

    private void ApplySafeArea()
    {
        if (safeAreaPanelRectTransform == null)
            return;

        //Apply Canvas Scaler
        canvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(Screen.width, Screen.height);
        //Apply Safe Area
        Rect safeArea = Screen.safeArea;
        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;

        anchorMin.x /= canvas.pixelRect.width;
        anchorMin.y /= canvas.pixelRect.height;

        anchorMax.x /= canvas.pixelRect.width;
        anchorMax.y /= canvas.pixelRect.height;

        safeAreaPanelRectTransform.anchorMin = anchorMin;
        safeAreaPanelRectTransform.anchorMax = anchorMax;
        safeAreaPanelRectTransform.offsetMax = Vector2.zero;
        safeAreaPanelRectTransform.offsetMin = Vector2.zero;

        currentOrientation = Screen.orientation;
        currentSafeArea = Screen.safeArea;
    }
    void Update()
    {
        if ((currentOrientation != Screen.orientation) || (currentSafeArea != Screen.safeArea))
        {
            ApplySafeArea();
        }
    }
}
