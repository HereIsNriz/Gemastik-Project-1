using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PeopleController : MonoBehaviour
{
    //

    [SerializeField] private Rigidbody2D peopleRb;
    [SerializeField] private int peopleScore;
    [SerializeField] private int peopleMoney;
    private GameManager gameManager;
    private float timeOnScreen = 1.0f;
    private int moneySubstracted = -10000;

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

        if (collision.gameObject.CompareTag("Sensor") && gameObject.CompareTag("Corruptor"))
        {
            gameManager.UpdateMoney(moneySubstracted);
        }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameManager.UpdateScore(peopleScore);
        gameManager.UpdateMoney(peopleMoney);
    }

    IEnumerator PeopleDisappearingRoutine()
    {
        yield return new WaitForSeconds(timeOnScreen);

        transform.position = new Vector2(0, -7);
    }
}