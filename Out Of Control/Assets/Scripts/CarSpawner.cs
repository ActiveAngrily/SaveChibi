using UnityEngine;

public class CarSpawner : MonoBehaviour 
{
    public float spawnRate = 1f;
    public GameObject car;
    
    private float _nextTimeToSpawn = 0f;

    public Transform[] spawnPoints;

    public bool canDragCarSpawn;

    void Update() {
        if (_nextTimeToSpawn <= Time.time) {
            SpawnCar();
            _nextTimeToSpawn = Time.time + spawnRate;
        }
    }

    private void SpawnCar() {
        var randomIndex = Random.Range(0, spawnPoints.Length);
        var spawnPoint = spawnPoints[randomIndex];
        
        var carSpawn = Instantiate(car, spawnPoint.position, spawnPoint.rotation);
        carSpawn.GetComponent<DragAndDrop>().activated = canDragCarSpawn;
    }

    public void CarDragOn() {
        canDragCarSpawn = true;
        foreach (var carObject in GameObject.FindGameObjectsWithTag("Car")) {
            car.GetComponent<DragAndDrop>().activated = true;
        }
    }
    
    public void CarDragOff() {
        canDragCarSpawn = false;
        foreach (var carObject in GameObject.FindGameObjectsWithTag("Car")) {
            car.GetComponent<DragAndDrop>().activated = false;
        }
    }
}
