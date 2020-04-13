using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int maxNumberTowers = 3;
    [SerializeField] Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(WayPoint baseWaypoint)
    {
        print(towerQueue.Count);
        int numTowersPlaced = towerQueue.Count;

        if (numTowersPlaced < maxNumberTowers)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(WayPoint baseWaypoint)
    {
        Tower newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;
        newTower.baseWaypoint = baseWaypoint;
        newTower.transform.parent = GameObject.Find("Environment").transform;
        baseWaypoint.isPlaceable = false;
        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(WayPoint newBaseWaypoint)
    {
        Tower oldTower = towerQueue.Dequeue();

        oldTower.baseWaypoint.isPlaceable = true; //block now free to place towers on
        newBaseWaypoint.isPlaceable = false;

        oldTower.baseWaypoint = newBaseWaypoint;
        oldTower.transform.position = newBaseWaypoint.transform.position;

        towerQueue.Enqueue(oldTower);
    }
}
