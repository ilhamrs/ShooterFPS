using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerAttack playerAttack;
    public GameObject PauseMenu;
    public GameObject youWin;
    public GameObject youLose;
    public TextMeshProUGUI zombieText;
    public Health healthPlayer;

    int totalZombie;
    int totalZombieDefault;
    public bool onPause;
    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        totalZombieDefault = FindObjectsOfType<Zombie>().Length;
        Debug.Log(totalZombie);
        Time.timeScale = 1;
        onPause = false;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        totalZombie = FindObjectsOfType<Zombie>().Length;

        zombieText.text = "- Kill all zombies (" + totalZombie + " left)";

        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            PauseGame();
        }

        checkZombie();

        checkHealth();
    }

    public void moveToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PauseGame()
    {
        if (onPause)
        {
            onPause = false;
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
            playerController.enabled = true;
            playerAttack.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            onPause = true;
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            playerController.enabled = false;
            playerAttack.enabled = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    void checkZombie()
    {
        if (totalZombie <= 0)
        {
            isGameOver = true;
            youWin.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            playerController.enabled = false;
            playerAttack.enabled = false;
        }
    }

    void checkHealth()
    {
        if (healthPlayer.currentHealth <= 0)
        {
            isGameOver = true;
            youLose.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            playerController.enabled = false;
            playerAttack.enabled = false;
        }
    }

    public void restart()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
