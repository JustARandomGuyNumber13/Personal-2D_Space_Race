using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class O_Spawn : MonoBehaviour
{
    [SerializeField] private bool isSpawnAfterDelay;
    [SerializeField] private float spawnDelay;
    [SerializeField] private GameObject[] objects;

    [Header("Insert Player for chase effect")]
    [SerializeField] private Transform player;

    private float spawnerSizeX;
    private void Start()
    {
        spawnerSizeX = Helper_GetWidth(this.gameObject);
        if (isSpawnAfterDelay)
        {
            print("Delay");
            Invoke("StartSpawnCoroutine", spawnDelay);
        }
        else
        {
            StartSpawnCoroutine();
        }
    }
    private void StartSpawnCoroutine()
    {
        StartCoroutine(SpawnCoroutine());
    }
    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnObject()
    { 
        int randomObjectIndex = Random.Range(0, objects.Length);
        GameObject spawnObject = Instantiate(objects[randomObjectIndex], transform.position, transform.rotation);
        Helper_SetPosition(spawnObject);
        Helper_SetTransform(spawnObject);
    }

    private void Helper_SetPosition(GameObject target)
    { 
        float targetSizeX = Helper_GetWidth(target.gameObject);
        float minRangeX = transform.position.x - spawnerSizeX / 2 + targetSizeX / 2;
        float maxRangeX = transform.position.x + spawnerSizeX / 2 - targetSizeX / 2;
        float randomPositionX = Random.Range(minRangeX, maxRangeX);

        target.transform.position = new Vector2(randomPositionX, target.transform.position.y);
    }
    private void Helper_SetTransform(GameObject target)         // ONLY FOR MISSLE
    {
        if (player != null)
        { 
            target.GetComponent<O_Chase>().Public_AssignTransform(player);
        }
    }
    private float Helper_GetWidth(GameObject target)
    { 
        return target.GetComponent<SpriteRenderer>().bounds.size.x;
    }
}
