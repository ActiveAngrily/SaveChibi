using UnityEngine;

public class Dog : MonoBehaviour {
    private Rigidbody2D _rb;
    [SerializeField] private float moveSpeed = 0.01f;
    [SerializeField] private GameObject startPosition;
    private UIText _uiText;
    public Vector2[] directionVectors = {Vector2.up, Vector2.right, Vector2.down, Vector2.left};

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _uiText = FindObjectOfType<UIText>();
    }

    void RotateControls() {
        var temp = directionVectors[0];
        for (var i = 0; i < directionVectors.Length - 1; i++) {
            directionVectors[i] = directionVectors[i + 1];
        }
        directionVectors[directionVectors.Length - 1] = temp;
    }

    void NextLevel() {
        RotateControls();
        transform.position = startPosition.transform.position;
        _uiText.IncrementLevel();
        _uiText.RefreshControlPanel(directionVectors);
    }
    
    void Update() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            _rb.MovePosition(_rb.position + (directionVectors[0] * moveSpeed));
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            _rb.MovePosition(_rb.position + (directionVectors[1] * moveSpeed));
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            _rb.MovePosition(_rb.position + (directionVectors[2] * moveSpeed));
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            _rb.MovePosition(_rb.position + (directionVectors[3] * moveSpeed));
        }
        
        // if reached other side of road
        if (transform.position.y >= 5) NextLevel();
    }
}
