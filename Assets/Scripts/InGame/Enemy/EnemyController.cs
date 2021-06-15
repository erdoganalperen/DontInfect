using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rbody2D;
    float speed;
    Vector3 size;
    float lifetime = 5;
    public Vector2 direction;
    Vector2 velocity;
    bool canMove = false;
    void Start()
    {
        Destroy(this.gameObject, lifetime);
        StartCoroutine(CanMoveCoroutine());
        rbody2D = GetComponent<Rigidbody2D>();
        //
        speed = EnemyManager.Instance.Speed;
        size = EnemyManager.Instance.CurrentSize;
    }
    private void FixedUpdate()
    {
        if (!canMove)
            return;

        if (speed != EnemyManager.Instance.Speed)
            speed = EnemyManager.Instance.Speed;
        if (size != EnemyManager.Instance.CurrentSize)
        {
            size = EnemyManager.Instance.CurrentSize;
        }
        if (transform.localScale != size)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, size, Time.fixedDeltaTime * 5);
        }
        velocity = direction * speed * Time.fixedDeltaTime;
        rbody2D.MovePosition(rbody2D.position + velocity);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canMove)
            ApplyBounce(other.name);
    }
    private void ApplyBounce(string side)
    {
        switch (side)
        {
            case "Top":
                direction.y *= -1;
                break;
            case "Right":
                direction.x *= -1;
                break;
            case "Bottom":
                direction.y *= -1;
                break;
            case "Left":
                direction.x *= -1;
                break;
            default:
                break;
        }
    }
    IEnumerator CanMoveCoroutine()
    {
        yield return new WaitForSeconds(EnemyManager.Instance.startMoveDelay);
        canMove = true;
    }
}
