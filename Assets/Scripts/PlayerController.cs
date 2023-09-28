using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;

    public GameObject gameWonPanel;
    public GameObject gameLostPanel;
    public GameObject gamePausedPanel;

    public float speed;
    
    private bool isGameOver = false;
    private bool isPaused = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (isGameOver || isPaused)
        {
            return;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            rigidbody2d.velocity = new Vector2(speed, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rigidbody2d.velocity = new Vector2(-speed, 0f);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            rigidbody2d.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rigidbody2d.velocity = new Vector2(0f, -speed);
        }
        else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            rigidbody2d.velocity = new Vector2(0f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
            gamePausedPanel.SetActive(true);
            isGameOver = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {   
            Debug.Log("Level Completed!");
            gameWonPanel.SetActive(true);
            isGameOver = true;
        }

        else if (other.tag == "Enemy")
        {
            Debug.Log("Level Lost!");
            gameLostPanel.SetActive(true);
            isGameOver = true;
        }
    }

    public void NextLevel()
    {
        Debug.Log("Button Pressed!");
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex)+1);
    }

    public void RestartGame()
    {
        Debug.Log("Button Pressed!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void ExitGame()
    {
        Debug.Log("Button Pressed!");
        Application.Quit();
    }

    public void ContinueGame()
    {
        Debug.Log("Button Pressed!");
        isPaused = false;
        gamePausedPanel.SetActive(false);
    }
}
