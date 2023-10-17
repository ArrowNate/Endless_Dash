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

    public float speedMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}