using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private AudioSource playAudio;
    [SerializeField] private AudioSource exitAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        playAudio.PlayOneShot(playAudio.clip, 1f);

        StartCoroutine(PlayButtonRoutine());
    }

    public void ExitButton()
    {
        exitAudio.PlayOneShot(exitAudio.clip, 1f);

        StartCoroutine(ExitButtonRoutine());
    }

    IEnumerator PlayButtonRoutine()
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Main Game");
    }

    IEnumerator ExitButtonRoutine()
    {
        yield return new WaitForSeconds(0.4f);

        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}

