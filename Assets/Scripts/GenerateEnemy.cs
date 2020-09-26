using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    public GameObject theEnemy;
    public int spawnXMaxPos = 20;
    public int spawnZMaxPos = 20;
    public int enemyMaxCount = 50;
    private int xPos;
    private int zPos;
    private int enemyCount;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < enemyMaxCount)
        {
            xPos = (Random.Range(-spawnXMaxPos, spawnXMaxPos));
            zPos = (Random.Range(-spawnZMaxPos, spawnZMaxPos));
            Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);    // 1 second to put 10 enemies
            enemyCount += 1;
        }


    }
    
}
