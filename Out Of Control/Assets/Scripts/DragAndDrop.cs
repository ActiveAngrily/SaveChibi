using UnityEngine;

public class DragAndDrop : MonoBehaviour 
{
    public bool activated;
    public bool isDragging;
    
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
        Dragging();
    }

    private void Dragging() 
    {
        if (isDragging) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }
}
