using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float _secondsToSpawn = 5f;

    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private bool _stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnRoutine());    
    }

    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        while(_stopSpawning == false)
        {
            Vector3 positionToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, positionToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_secondsToSpawn);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

}
