using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject shieldPowerupPrefab;

    void Start()
    {
        InvokeRepeating("CreateEnemyOne", 1, 2);
        InvokeRepeating("CreateEnemyTwo", 2.5f, 3.5f);
        InvokeRepeating("CreateShieldPowerup", 5f, 10f);
    }

    void Update() { }

    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }

    void CreateEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }

    void CreateShieldPowerup()
    {
        Instantiate(shieldPowerupPrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }
}