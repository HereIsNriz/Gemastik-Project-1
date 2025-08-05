using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameRunning;

    [SerializeField] private GameObject[] people;
    private float peopleSpawnRate = 1.0f;
    private float minX = -1.5f;
    private float minY = -3.5f;
    private float distanceBetweenLoc = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

    }

    public void UpdateMoney(int moneyToUpdate)
    {

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
        int locationIndex = Random.Range(0, 3);

        float randomX = minX + (locationIndex * distanceBetweenLoc);
        float randomY = minY + (locationIndex * distanceBetweenLoc);

        return new Vector2(randomX, randomY);
    }
}
