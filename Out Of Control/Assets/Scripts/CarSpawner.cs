using UnityEngine;
using System.Collections.Generic;


public class CarSpawner : MonoBehaviour
{
    public float spawnRate = 1f;

    private float _nextTimeToSpawn = 0f;

    public Transform[] spawnPoints;

    public bool canDragCarSpawn;

    public int numberOfCarstoSpawnRate = 2;

    public GameObject[] cars;
    private GameObject car;

    void Update()
    {
        if (_nextTimeToSpawn <= Time.time)
        {
            SpawnCars();
            _nextTimeToSpawn = Time.time + spawnRate;
        }
    }

    private void SpawnCars()
    {
        /*
        var randomIndex = Random.Range(0, spawnPoints.Length);
        var spawnPoint = spawnPoints[randomIndex];
        car = cars[1];
        var carSpawn = Instantiate(car, spawnPoint.position, spawnPoint.rotation);
        carSpawn.GetComponent<DragAndDrop>().activated = canDragCarSpawn;
       */
        List<int> numbersUsed = new List<int>();
        for (int i = 0; i < numberOfCarstoSpawnRate; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            int oppositeRandom = 0;
            switch (randomIndex)
            {
                case 0:
                    oppositeRandom = 3;
                    break;
                case 1:
                    oppositeRandom = 2;
                    break;
                case 2:
                    oppositeRandom = 1;
                    break;
                case 3:
                    oppositeRandom = 0;
                    break;
            }

            if (numbersUsed.Contains(randomIndex) || numbersUsed.Contains(oppositeRandom))
            {
                continue;
            }



            Transform spawnPoint = spawnPoints[randomIndex];

            numbersUsed.Add(randomIndex);
            int randomCar = Random.Range(0,cars.Length); 

            car = cars[randomCar];
            
            var carSpawn = Instantiate(car, spawnPoint.position, spawnPoint.rotation);
            carSpawn.GetComponent<DragAndDrop>().activated = canDragCarSpawn;
        }
    }

    public void CarDragOn()
    {
        canDragCarSpawn = true;
        foreach (var carObject in GameObject.FindGameObjectsWithTag("Car"))
        {
            car.GetComponent<DragAndDrop>().activated = true;
        }
    }

    public void CarDragOff()
    {
        canDragCarSpawn = false;
        foreach (var carObject in GameObject.FindGameObjectsWithTag("Car"))
        {
            car.GetComponent<DragAndDrop>().activated = false;
        }
    }
}
