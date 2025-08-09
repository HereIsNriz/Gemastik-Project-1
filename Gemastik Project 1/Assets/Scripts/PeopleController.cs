using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PeopleController : MonoBehaviour
{
    //

    [SerializeField] private Rigidbody2D peopleRb;
    [SerializeField] private AudioSource peopleAudioSource;
    [SerializeField] private int peopleScore;
    [SerializeField] private int peopleMoney;
    private GameManager gameManager;
    private float timeOnScreen = 1.0f;
    private int moneySubstracted = -5000;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        StartCoroutine(PeopleDisappearingRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sensor"))
        {
            if (gameObject.CompareTag("Corruptor"))
            {
                if (gameManager.isGameRunning)
                {
                    gameManager.UpdateMoney(moneySubstracted);
                }
            }

            StartCoroutine(SensorRoutine());
        }
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameRunning)
        {
            peopleAudioSource.PlayOneShot(peopleAudioSource.clip, 1f);
            transform.position = new Vector2(0, -7);

            gameManager.UpdateScore(peopleScore);
            gameManager.UpdateMoney(peopleMoney);
        }
    }

    IEnumerator PeopleDisappearingRoutine()
    {
        yield return new WaitForSeconds(timeOnScreen);

        transform.position = new Vector2(0, -7);
    }

    IEnumerator SensorRoutine()
    {
        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }
}