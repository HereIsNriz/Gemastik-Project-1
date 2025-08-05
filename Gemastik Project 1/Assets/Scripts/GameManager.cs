using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameRunning;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isGameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        isGameRunning = false;
    }
}
