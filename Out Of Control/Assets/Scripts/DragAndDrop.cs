using UnityEngine;

public class DragAndDrop : MonoBehaviour 
{
    public bool activated;
    private bool isDragging;
    
    private void OnMouseDown() 
    {
        if (activated) 
            isDragging = true;
    }

    private void OnMouseUp() 
    {
        if (activated) 
            isDragging = false;
    }

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(activated)
            {
                isDragging = true;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if(activated)
            {
                isDragging = false;
            }
        }

        Dragging();
    }

    private void Dragging() 
    {
        if (isDragging) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);

            if (transform.position.x >= 4.7F) {
                isDragging = false;
                transform.position = new Vector2(4.69F, transform.position.y);
            }
            if (transform.position.x <= -4.7F) {
                isDragging = false;
                transform.position = new Vector2(-4.69F, transform.position.y);
            }
            if (transform.position.y >= 4.7F) {
                isDragging = false;
                transform.position = new Vector2(transform.position.x, 4.69F);
            }
            if (transform.position.y <= -4.7F) {
                isDragging = false;
                transform.position = new Vector2(transform.position.x, -4.69F);
            }
            
        }
    }
}
