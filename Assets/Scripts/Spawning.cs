using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [SerializeField] GameObject allyPrefab;
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] Transform allySummon;
    [SerializeField] Transform enemySummon;

    GameController gc;
    public int price = 100;

    void Start()
    {
        gc = GetComponent<GameController>();
        StartCoroutine(SummonEnemy());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B) && gc.gold > price)
        {
            gc.gold -= price;
            gc.GoldTextUpdate();
            Instantiate(allyPrefab, allySummon.position, Quaternion.identity, allySummon);
        }
    }

    IEnumerator SummonEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(3, 8));
            Instantiate(enemyPrefab, enemySummon.position, Quaternion.identity, enemySummon);
        }
    }
}
