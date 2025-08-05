using System.Collections;
using UnityEngine;

public class PeopleController : MonoBehaviour
{
    //

    [SerializeField] private GameManager gameManager;
    [SerializeField] private int peopleScore;
    private float timeOnScreen = 1.0f;
    private float movingSpeed = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sensor") && !collision.gameObject.CompareTag("Villager"))
        {
            Destroy(gameObject);
            // SubstractMoney()
        }
    }

    IEnumerator PeopleDisappearingRoutine()
    {
        yield return new WaitForSeconds(timeOnScreen);

        Vector3 peopleMoving = new Vector3(0, 0, movingSpeed);
        transform.Translate(peopleMoving * Time.deltaTime);
    }
}
