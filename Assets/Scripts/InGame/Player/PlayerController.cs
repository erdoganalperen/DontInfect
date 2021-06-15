using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    //Mobile Input
    private Vector3 touchPosition;
    private Vector3 direction;
    //Editor Input
    private Vector3 mousePosition;
    [Header("Paramaters")]
    private float moveSpeed = 1f;
    [Range(.1f, 1)]
    public float size;
    private void Start()
    {
        transform.localScale *= size;
        moveSpeed = PlayerManager.Instance.Speed;

    }
    void Update()
    {
        if (Application.isMobilePlatform)
            OnPhoneMovement();
        else
            DesktopMovement();
        if (moveSpeed != PlayerManager.Instance.Speed)
            moveSpeed = PlayerManager.Instance.Speed;
    }
    void OnPhoneMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            if (touchPosition.x <= GameManager.Instance.GameAreaToWorldPointMin.x + size / 2)
            {
                touchPosition.x = GameManager.Instance.GameAreaToWorldPointMin.x + size / 2;
            }
            if (touchPosition.x >= GameManager.Instance.GameAreaToWorldPointMax.x - size / 2)
            {
                touchPosition.x = GameManager.Instance.GameAreaToWorldPointMax.x - size / 2;
            }
            if (touchPosition.y <= GameManager.Instance.GameAreaToWorldPointMin.y + size / 2)
            {
                touchPosition.y = GameManager.Instance.GameAreaToWorldPointMin.y + size / 2;
            }
            if (touchPosition.y >= GameManager.Instance.GameAreaToWorldPointMax.y - size / 2)
            {
                touchPosition.y = GameManager.Instance.GameAreaToWorldPointMax.y - size / 2;
            }
            direction = (touchPosition - transform.position);
            transform.position = Vector2.MoveTowards(transform.position, touchPosition, Time.deltaTime * moveSpeed);
        }
    }
    void DesktopMovement()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (mousePosition.x <= GameManager.Instance.GameAreaToWorldPointMin.x + size / 2)
            {
                mousePosition.x = GameManager.Instance.GameAreaToWorldPointMin.x + size / 2;
            }
            if (mousePosition.x >= GameManager.Instance.GameAreaToWorldPointMax.x - size / 2)
            {
                mousePosition.x = GameManager.Instance.GameAreaToWorldPointMax.x - size / 2;
            }
            if (mousePosition.y <= GameManager.Instance.GameAreaToWorldPointMin.y + size / 2)
            {
                mousePosition.y = GameManager.Instance.GameAreaToWorldPointMin.y + size / 2;
            }
            if (mousePosition.y >= GameManager.Instance.GameAreaToWorldPointMax.y - size / 2)
            {
                mousePosition.y = GameManager.Instance.GameAreaToWorldPointMax.y - size / 2;
            }
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, Time.deltaTime * moveSpeed);
        }
    }
}
