using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameRunning;

    [SerializeField] private Slider moneySlider;
    [SerializeField] private Image moneyImage;
    [SerializeField] private GameObject[] people;
    [SerializeField] private GameObject messagePanel;
    [SerializeField] private AudioSource letUsGoAudio;
    [SerializeField] private int score;
    [SerializeField] private int currentMoney;
    private float peopleSpawnRate = 1.5f;
    private float minX = -1.84f;
    private float minY = -4.26f;
    private float distanceBetweenX = 1.84f;
    private float distanceBetweenY = 1.36f;
    private int maxMoney = 100000;

    // Update is called once per frame
    void Update()
    {
        ChangeImageColor();

        if (currentMoney <= 0)
        {
            GameOver();
            moneySlider.gameObject.SetActive(false);
        }

        if (currentMoney >= maxMoney)
        {
            GameWin();
            moneySlider.gameObject.SetActive(false);
        }
    }

    public void LetUsGoButton()
    {
        letUsGoAudio.PlayOneShot(letUsGoAudio.clip, 1f);

        messagePanel.gameObject.SetActive(false);

        isGameRunning = true;

        currentMoney = maxMoney / 2;

        moneySlider.maxValue = maxMoney;
        moneySlider.value = currentMoney;
        moneySlider.gameObject.SetActive(true);
        moneySlider.fillRect.gameObject.SetActive(true);

        StartCoroutine(PeopleSpawner());
    }

    public void GameOver()
    {
        isGameRunning = false;
    }

    public void GameWin()
    {
        isGameRunning = false;
    }

    public void UpdateScore(int scoreToUpdate)
    {
        score += scoreToUpdate;
    }

    public void UpdateMoney(int moneyToUpdate)
    {
        currentMoney += moneyToUpdate;
        moneySlider.value = currentMoney;
    }

    IEnumerator PeopleSpawner()
    {
        while(isGameRunning)
        {
            yield return new WaitForSeconds(peopleSpawnRate);

            int poepleIndex = Random.Range(0, people.Length);

            Instantiate(people[poepleIndex], RandomSpawnLocation(), Quaternion.identity);
        }
    }

    private Vector2 RandomSpawnLocation()
    {
        float randomX = minX + (Random.Range(0, 3) * distanceBetweenX);
        float randomY = minY + (Random.Range(0, 3) * distanceBetweenY);

        return new Vector2(randomX, randomY);
    }

    private void ChangeImageColor()
    {
        if (currentMoney <= 20000)
        {
            moneyImage.color = Color.red;
        }
        else if (currentMoney <= 50000)
        {
            moneyImage.color = Color.yellow;
        }
        else if (currentMoney <= 100000)
        {
            moneyImage.color = Color.green;
        }
    }
}
