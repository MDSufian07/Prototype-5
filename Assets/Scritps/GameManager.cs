using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public GameObject[] tergats2;
    public TextMeshProUGUI scroeText;
    private int score;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    public bool isGameActive;
    public GameObject TitleScreen;
   

    private float spawnRate = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
         
        }
    }
    public void scoreUpdate(int scoreToAdd) 
    {
        score += scoreToAdd;
        scroeText.text = "Score: " + score;
    }
    public void gameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        scoreUpdate(0);
       TitleScreen.gameObject.SetActive(false);
    }
}
