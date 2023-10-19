using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private float timer;
    [SerializeField] private float spawnDelays;
    [SerializeField] private Text distanceUI;
    [SerializeField] private float distance;

    public bool isGamePaused = false;
    public float speedMultiplier;

    // Update is called once per frame
    void Update()
    {
        if (!isGamePaused)
        {
            distanceUI.text = "Distance: " + distance.ToString("F2");
            distance += Time.deltaTime;
            speedMultiplier += Time.deltaTime * 0.1f;
            timer += Time.deltaTime * 0.5f;

            if (timer > spawnDelays)
            {
                timer = 0;
                int randNum = Random.Range(0, 3);
                Instantiate(spawnObject, spawnPoints[randNum].transform.position, Quaternion.identity);
            }
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        PauseGameWithDelay();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isGamePaused = false;
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PauseGameWithDelay()
    {
        StartCoroutine(PauseGameAfterDelay(0.3f));
    }

    private IEnumerator PauseGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        isGamePaused = true;
        Time.timeScale = 0;
    }
}