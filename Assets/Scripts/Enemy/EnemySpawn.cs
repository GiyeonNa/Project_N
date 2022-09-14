using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject spawnMonster;
    [SerializeField] private float delay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsterCo());
    }


    IEnumerator SpawnMonsterCo()
    {
        Instantiate(spawnMonster, transform.position, transform.rotation);
        yield return new WaitForSeconds(delay);
        StartCoroutine(SpawnMonsterCo());
    }
}
