using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu_fin : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject menuPauseUi;



    //public GameObject canva;

    // Update is called once per frame
    void Start()
    {
        Play();
    }

    private void OnTriggerEnter(Collider player)
    {
        Debug.Log("collision");
        if (player.tag == "Player")
        {
            Pause();
            Debug.Log("collision player");
        }
    }

    public void Play()
    {
        menuPauseUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    void Pause()
    {
        menuPauseUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Enora_scene");
        Play();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Pause_racourcis()
    {
        if (GameIsPause)
        {
            Time.timeScale = 1f;
            GameIsPause = false;
        }

        else
        {
            Time.timeScale = 0f;
            GameIsPause = true;
        }

    }

}
