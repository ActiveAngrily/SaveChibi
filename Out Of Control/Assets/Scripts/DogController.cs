using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DogController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator an;

    private Vector2[] direction = { Vector2.up, Vector2.down, Vector2.left, Vector2.right }; //GameMaster Object will randomize the direction after every wave
    // order of direction - [UP,DOWN,LEFT,RIGHT]
    private int[] directionIndex = { 0, 1, 2, 3 };
    public float speed;

    [Range(2f, 1f)]
    public float smoothStartMotion = 1.5f; //Making it lower will make it smoother

    //private UIText _uiText;
    //[SerializeField] private Transform startTransform;

    public bool randomizeDirection = false;
    public bool controlsOn = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        // _uiText = FindObjectOfType<UIText>();
    }

    private void Update()
    {

        if (controlsOn)
        {
            Movement();
        }
        if (randomizeDirection)
        {
            ShuffleDirection(directionIndex);
            randomizeDirection = false;

        }
    }
    public void CancelAllMotion()
    {
        rb.velocity = Vector2.zero;
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
            RemoveAnims();
        }
    }
    private void Move(Vector2 direction, float speed)
    {
        rb.velocity = direction * speed; ;
        if (direction == Vector2.up) Animate("WalkUp");
        if (direction == Vector2.down) Animate("WalkDown");
        if (direction == Vector2.right) Animate("WalkRight");
        if (direction == Vector2.left) Animate("WalkLeft");
        if (rb.velocity == Vector2.zero)
        {
            RemoveAnims();
            an.Play("dog_idle");
            direction = Vector2.zero;
        }
    }

    public void Animate(string animParam)
    {
        RemoveAnims();
        an.SetBool(animParam, true);
    }

    public void RemoveAnims()
    {
        an.SetBool("WalkUp", false);
        an.SetBool("WalkDown", false);
        an.SetBool("WalkLeft", false);
        an.SetBool("WalkRight", false);
        an.SetBool("Drag", false);
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
        if (col.gameObject.tag == "Car")
        {
            Destroy(gameObject);
            Debug.Log("You Lose");
        }
    }
}