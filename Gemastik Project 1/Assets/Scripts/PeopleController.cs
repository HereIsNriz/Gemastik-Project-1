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
    private Vector3 containerPosotion = new Vector3(5, 0, 0);
    private Vector3 sensorPosition = new Vector3(0, -7, 0);
    private float timeOnScreen = 1.0f;
    private int moneySubstracted = -5000;
    private bool stop;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stop = true;

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        StartCoroutine(PeopleDisappearingRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop && transform.position != containerPosotion)
        {
            transform.position = sensorPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sensor"))
        {
            if (gameObject.CompareTag("Corruptor"))
            {
                if (gameManager.isGameRunning)
                {
                    gameManager.corruptorRanAway.PlayOneShot(gameManager.corruptorRanAway.clip, 1f);
                    gameManager.UpdateMoney(moneySubstracted);
                }
            }

            StartCoroutine(TriggerRoutine());
        }

        if (collision.gameObject.CompareTag("Container"))
        {
            StartCoroutine(TriggerRoutine());
        }
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameRunning)
        {
            peopleAudioSource.PlayOneShot(peopleAudioSource.clip, 1f);
            transform.position = containerPosotion;

            gameManager.UpdateScore(peopleScore);
            gameManager.UpdateMoney(peopleMoney);
        }
    }

    IEnumerator PeopleDisappearingRoutine()
    {
        yield return new WaitForSeconds(timeOnScreen);

        stop = false;
    }

    IEnumerator TriggerRoutine()
    {
        yield return new WaitForSeconds(0.6f);

        Destroy(gameObject);
    }
}