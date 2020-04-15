using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // header for all the menus
    [Header("Menus")]
    // all the menus
    public GameObject mainMenu;
    public GameObject playMenu;
    public GameObject exitMenu;

    // animations
    private Animator cameraObject;

    // Start is called before the first frame update
    void Start()
    {
        cameraObject = transform.GetComponent<Animator>();
    }

    public void PlayGame()
    {
        exitMenu.gameObject.SetActive(false);
        playMenu.gameObject.SetActive(true);
    }

    public void NewGame()
    {
        Debug.Log("New Game Start");
        SceneManager.LoadScene("Overworld", LoadSceneMode.Single);
    }

    public void Position2()
    {
        cameraObject.SetFloat("Animate", 1);
    }

    public void Position1()
    {
        cameraObject.SetFloat("Animate", 0);
        playMenu.gameObject.SetActive(false);
        exitMenu.gameObject.SetActive(false);
    }

    public void ExitMenu()
    {
        exitMenu.gameObject.SetActive(true);
        playMenu.gameObject.SetActive(false);
    }

    public void Yes_Exit()
    {
        Debug.Log("Quit Game");
    }

    public void No_Exit()
    {
        Debug.Log("Don't Quit Game");
        exitMenu.gameObject.SetActive(false);
        playMenu.gameObject.SetActive(false);
    }
}
