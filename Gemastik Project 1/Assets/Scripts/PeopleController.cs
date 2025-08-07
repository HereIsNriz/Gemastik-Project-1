using System.Collections;
using UnityEngine;

public class PeopleController : MonoBehaviour
{
    //

    [SerializeField] private Rigidbody2D peopleRb;
    [SerializeField] private int peopleScore;
    [SerializeField] private int peopleMoney;
    private GameManager gameManager;
    private float timeOnScreen = 1.0f;
    private float peopleSpeed = 5.0f;

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
        Destroy(gameObject);

        if (collision.gameObject.CompareTag("Sensor") && gameObject.CompareTag("Villager"))
        {
            // UpdateMoney or Update Score
        }

        if (collision.gameObject.CompareTag("Sensor") && gameObject.CompareTag("Corruptor"))
        {
            // UpdateMoney or Update Score
        }
    }

    IEnumerator PeopleDisappearingRoutine()
    {
        yield return new WaitForSeconds(timeOnScreen);

        transform.Translate(Vector3.forward * peopleSpeed, Space.World);
    }
}