using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameRunning;
    public AudioSource corruptorRanAway;

    [SerializeField] private Slider moneySlider;
    [SerializeField] private Image moneyImage;
    [SerializeField] private GameObject[] people;
    [SerializeField] private GameObject messagePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameWinPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private AudioSource letUsGoAudio;
    [SerializeField] private AudioSource gameOverAudio;
    [SerializeField] private AudioSource gameWinAudio;
    [SerializeField] private int score;
    [SerializeField] private int currentMoney;
    private float peopleSpawnRate = 1.5f;
    private float minX = -1.84f;
    private float minY = -4.26f;
    private float distanceBetweenX = 1.84f;
    private float distanceBetweenY = 1.36f;
    private int maxMoney = 100000;
    private bool gamePaused;

    private void Start()
    {
        gamePaused = false;

        currentMoney = maxMoney / 2;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeImageColor();

        if (currentMoney <= 0 && isGameRunning)
        {
            GameOver();
            moneySlider.gameObject.SetActive(false);
        }

        if (currentMoney >= maxMoney && isGameRunning)
        {
            GameWin();
            moneySlider.gameObject.SetActive(false);
        }

        PauseGame();
    }

    public void LetUsGoButton()
    {
        letUsGoAudio.PlayOneShot(letUsGoAudio.clip, 1f);

        messagePanel.gameObject.SetActive(false);

        isGameRunning = true;

        moneySlider.maxValue = maxMoney;
        moneySlider.value = currentMoney;
        moneySlider.gameObject.SetActive(true);
        moneySlider.fillRect.gameObject.SetActive(true);

        StartCoroutine(PeopleSpawner());
    }

    public void GameOver()
    {
        gameOverAudio.PlayOneShot(gameOverAudio.clip, 1f);
        isGameRunning = false;
        gameOverPanel.gameObject.SetActive(true);
    }

    public void GameWin()
    {
        gameWinAudio.PlayOneShot(gameWinAudio.clip, 1f);
        isGameRunning = false;
        gameWinPanel.gameObject.SetActive(true);
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

    public void BackToMenuButton()
    {
        letUsGoAudio.PlayOneShot(letUsGoAudio.clip, 1f);

        StartCoroutine(AudioSourceRoutine());
    }

    IEnumerator AudioSourceRoutine()
    {
        yield return new WaitForSeconds(0.1f);

        SceneManager.LoadScene("Main Menu");
    }

    private void PauseGame()
    {
        if (isGameRunning)
        {
            if (Input.GetKeyDown(KeyCode.P) && !gamePaused)
            {
                gamePaused = true;

                letUsGoAudio.PlayOneShot(letUsGoAudio.clip, 1f);
                pausePanel.gameObject.SetActive(true);

                Time.timeScale = 0;
            }
        }
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;

        pausePanel.gameObject.SetActive(false);
        letUsGoAudio.PlayOneShot(letUsGoAudio.clip, 1f);

        gamePaused = false;
    }
}
