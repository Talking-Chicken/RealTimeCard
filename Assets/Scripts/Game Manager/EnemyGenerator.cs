using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    private ScoreManager scoreManager;
    private Collider2D worldBound;
    [SerializeField] private GameObject sineEnemy, flyEnemy;
    [SerializeField] private float sineSpawnY, flySpawnY;
    private int[] difficultyScore = new int[20]; //array of score to increase difficulty
    private float spawnRate = 1;
    private bool isSpawned = false;
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        worldBound = FindObjectOfType<WorldBound>().GetComponent<Collider2D>();

        for (int i = 0; i < difficultyScore.Length; i++) {
            difficultyScore[i] = (i+1)*5; 
        }
    }

    
    void Update()
    {
        for (int i = 0; i < difficultyScore.Length; i++) {
            if ((int)scoreManager.Score == difficultyScore[i]) {
                spawnRate += 0.4f;
                difficultyScore[i] = 0;
            }
        }

        if (((int)scoreManager.Score)%10 == 0 && !isSpawned) {

            for (int i = 0; i < (int)spawnRate; i++) {
                int randomChoose = (int)Random.Range(0, 1.99f);
                //spawn from left
                if (randomChoose == 0) {
                    Instantiate(sineEnemy, new Vector2(worldBound.bounds.min.x - 1, sineSpawnY), Quaternion.identity);
                    Instantiate(flyEnemy, new Vector2(worldBound.bounds.min.x - 1, flySpawnY), Quaternion.identity);
                } else { //spawn from right
                    Instantiate(sineEnemy, new Vector2(worldBound.bounds.max.x + 1, sineSpawnY), Quaternion.identity);
                    Instantiate(flyEnemy, new Vector2(worldBound.bounds.max.x + 1, flySpawnY), Quaternion.identity);
                }
            }
            StartCoroutine(waitToSpawn());
        }
    }

    //let enemy only spawn one frame
    IEnumerator waitToSpawn() {
        isSpawned = true;
        yield return new WaitForSeconds(1.5f);
        isSpawned = false;
    }
}