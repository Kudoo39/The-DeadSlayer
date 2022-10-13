using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monster;

    [SerializeField]
    private Transform left, right;

    private GameObject spawnEnemy;
    private int random;
    private int side;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemies());
    }
    IEnumerator spawnEnemies()
    {
        while (1<2)
        {
            yield return new WaitForSeconds(Random.RandomRange(1, 5));
            random = Random.Range(0, monster.Length);
            side = Random.Range(0, 2);
            spawnEnemy = Instantiate(monster[random]);

            if (side == 0)
            {
                //on the left
                spawnEnemy.transform.position = left.position;
                spawnEnemy.GetComponent<Enemy>().speed = Random.Range(3, 7);
            }
            else
            {
                //on the right
                spawnEnemy.transform.position = right.position;
                spawnEnemy.GetComponent<Enemy>().speed = -Random.Range(3, 7);
                spawnEnemy.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
        // Update is called once per frame
    }
}
