using UnityEngine;

public class MouseController : MonoBehaviour {
    public GameObject dog;
    public GameObject carSpawner;

    public void DogMouseOn() {
        dog.GetComponent<DragAndDrop>().activated = true;
    }
    
    public void DogMouseOff() {
        dog.GetComponent<DragAndDrop>().activated = false;
    }

    public void CarMouseOn() {
        carSpawner.GetComponent<CarSpawner>().CarDragOn();
    }

    public void CarMouseOff() {
        carSpawner.GetComponent<CarSpawner>().CarDragOff();
    }
}
