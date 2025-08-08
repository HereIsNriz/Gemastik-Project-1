using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameRunning;

    [SerializeField] private GameObject[] people;
    [SerializeField] private int score;
    [SerializeField] private int money;
    private float peopleSpawnRate = 1.0f;
    private float minX = -1.5f;
    private float minY = -3.5f;
    private float distanceBetweenLoc = 1.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        money = 0;
        isGameRunning = true;

        StartCoroutine(PeopleSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        isGameRunning = false;
    }

    public void UpdateScore(int scoreToUpdate)
    {
        score += scoreToUpdate;
    }

    public void UpdateMoney(int moneyToUpdate)
    {
        money += moneyToUpdate;
    }

    IEnumerator PeopleSpawner()
    {
        while (isGameRunning)
        {
            yield return new WaitForSeconds(peopleSpawnRate);

            int poepleIndex = Random.Range(0, people.Length);

            Instantiate(people[poepleIndex], RandomSpawnLocation(), Quaternion.identity);
        }
    }

    private Vector2 RandomSpawnLocation()
    {
        float randomX = minX + (Random.Range(0, 3) * distanceBetweenLoc);
        float randomY = minY + (Random.Range(0, 3) * distanceBetweenLoc);

        return new Vector2(randomX, randomY);
    }
}
