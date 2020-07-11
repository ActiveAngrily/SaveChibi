using UnityEngine;

public class CarController : MonoBehaviour
{
    Rigidbody2D rb;
    private Vector2 _direction;
    
    [Range(1.0F, 5.0F)]
    public float speed = 5.0F;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (transform.position.x > 0) _direction = Vector2.left;
        else {
            _direction = Vector2.right;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Run animations when animations are done
    private void FixedUpdate() 
    {
        Move();
    }

    private void Move() 
    {
        rb.MovePosition(rb.position + _direction * (speed * Time.deltaTime));
        if (transform.position.x < -10 || transform.position.x > 10)
            Destroy(gameObject);
    }
}
