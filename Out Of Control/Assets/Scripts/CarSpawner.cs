using UnityEngine;

public class CarSpawner : MonoBehaviour 
{
    public float spawnRate = 1f;
    public GameObject car;
    
    private float _nextTimeToSpawn = 0f;

    public Transform[] spawnPoints;

    void Update() {
        if (_nextTimeToSpawn <= Time.time) {
            SpawnCar();
            _nextTimeToSpawn = Time.time + spawnRate;
        }
    }

    private void SpawnCar() {
        var randomIndex = Random.Range(0, spawnPoints.Length);
        var spawnPoint = spawnPoints[randomIndex];
        
        Instantiate(car, spawnPoint.position, spawnPoint.rotation);
    }
}
