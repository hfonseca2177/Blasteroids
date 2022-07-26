using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> asteroidPrefabs = new List<GameObject>();
    [SerializeField] private float spawnMinTime;
    [SerializeField] private float spawnMaxTime;
    [SerializeField] private float spawnRadius;
    [SerializeField] private float targetRadius;
    [SerializeField] private Transform target;
    private Vector3 randomSpawnLocation;
    private Vector3 randomTargetLocation;
    

    void Start()
    {
        StartCoroutine(Spawn());     
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(GetRandomSpawnDelay());
            SpawnAsteroid();
        }
    }

    void SpawnAsteroid()
    {
        Vector3 startPosition = GetPointOnSpawnerSphere();
        Vector3 endPosition = GetPointOnTargetSphere();
        Vector3 rotationDirection = GetRotationDirection();

        int randomIndex = Random.Range(0, asteroidPrefabs.Count);
        GameObject asteroid = Instantiate(asteroidPrefabs[randomIndex], startPosition, transform.rotation);
        asteroid.transform.LookAt(endPosition);
        asteroid.GetComponent<Rigidbody>().angularVelocity = rotationDirection;
    }

    private Vector3 GetRotationDirection()
    {
        float maxAngle = Mathf.PI * 2;
        return new Vector3(Random.Range(0,maxAngle) , Random.Range(0,maxAngle), Random.Range(0,maxAngle));
    }

    private float GetRandomSpawnDelay()
    {
        return Random.Range(spawnMinTime, spawnMaxTime);
    }

    private Vector3 GetPointOnSpawnerSphere()
    {
        randomSpawnLocation = Random.insideUnitSphere * spawnRadius;
        return transform.position + randomSpawnLocation;
    }

    private Vector3 GetPointOnTargetSphere()
    {
        randomTargetLocation = Random.insideUnitSphere * targetRadius;
        return target.position + randomTargetLocation;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
        Gizmos.DrawWireSphere(transform.position + randomSpawnLocation, 1);

        Gizmos.color = Color.red;
        if (target != null)
        {
            Gizmos.DrawWireSphere(target.position, targetRadius);
            Gizmos.DrawWireSphere(target.position + randomTargetLocation, 1);
        }
    }
}
