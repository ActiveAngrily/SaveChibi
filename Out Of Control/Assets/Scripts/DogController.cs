using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DogController : MonoBehaviour
{
    Rigidbody2D rb;

    private Vector2[] direction = { Vector2.up, Vector2.down, Vector2.left, Vector2.right }; //GameMaster Object will randomize the direction after every wave
    // order of direction - [UP,DOWN,LEFT,RIGHT]
    private int[] directionIndex = { 0, 1, 2, 3 };
    public float speed;
    
    [Range(2f,1f)]
    public float smoothStartMotion = 1.5f; //Making it lower will make it smoother

    //private UIText _uiText;
    //[SerializeField] private Transform startTransform;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // _uiText = FindObjectOfType<UIText>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            float inputMotion = Mathf.Clamp(Input.GetAxis("Vertical") * smoothStartMotion, 0f, 1f);
            //direction[0]
            Move(direction[directionIndex[0]], inputMotion * speed);

        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            float inputMotion = Mathf.Clamp(Input.GetAxis("Vertical") * -smoothStartMotion, 0f, 1f);
            //direction[1]
            Move(direction[directionIndex[1]], inputMotion * speed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            float inputMotion = Mathf.Clamp(Input.GetAxis("Horizontal") * -smoothStartMotion, 0f, 1f);
            //direction[2]
            Move(direction[directionIndex[2]], inputMotion * speed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            float inputMotion = Mathf.Clamp(Input.GetAxis("Horizontal") * smoothStartMotion, 0f, 1f);

            //direction[3]
            Move(direction[directionIndex[3]], inputMotion * speed);
        }
        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            rb.velocity = Vector2.zero;
        }
    }
    private void Move(Vector2 direction, float speed)
    {
        rb.velocity = direction * speed;
    }

    public void ShuffleDirection<Obj>(Obj[] dir)
    {
        int n = dir.Length;
        //Fisher-Yates Shuffling Algorithm
        for (int i = 0; i < n - 1; i++)
        {
            int j = Random.Range(i, n);
            Obj temp = dir[i];
            dir[i] = dir[j];
            dir[j] = temp;
        }
    }
    private void OnColliderEnter2D(Collider col)
    {
        if(col.gameObject.tag == "Car")
        {
            Destroy(gameObject);
            Debug.Log("You Lose");
        }
    }
}