using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCount : MonoBehaviour
{

    [SerializeField] private GameObject[] enemies;
    [SerializeField] TextMeshProUGUI enemyCountText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCountText.SetText("Left Enemy : " + enemies.Length);
    }
}
