using System.Collections;
using UnityEngine;

public class PeopleController : MonoBehaviour
{
    //

    [SerializeField] private GameManager gameManager;
    [SerializeField] private int peopleScore;
    [SerializeField] private int peopleMoney;
    private float timeOnScreen = 1.0f;

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
        if (collision.gameObject.CompareTag("Sensor") && collision.gameObject.CompareTag("Villager"))
        {
            Destroy(gameObject);
            // UpdateMoney()
        }

        if (collision.gameObject.CompareTag("Sensor") && collision.gameObject.CompareTag("Corruptor"))
        {
            Destroy(gameObject);
            // UpdateMoney()
        }
    }

    IEnumerator PeopleDisappearingRoutine()
    {
        yield return new WaitForSeconds(timeOnScreen);

        transform.Translate(Vector3.forward);
    }
}
