using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // list of enemies
    private GameObject[] enemies;

    //  prefabs from enemies
    private GameObject enemyGreen;
    private GameObject enemyRed; 

    // Score and score text
    private int score = 0;
    public Text scoreText;

    // distance between enemies and cockpit
    public float distance = 8f;

    // Start is called before the first frame update
    void Start()
    {
        // load prefabs from enemies from resources folder
        enemyGreen = Resources.Load("InimigoGreen", typeof(GameObject)) as GameObject;
        enemyRed = Resources.Load("InimigoRed", typeof(GameObject)) as GameObject;

        // create a list of enemies with 10 of each type, on random positions (10f to -10f in x, y and z) and rotations 
        enemies = new GameObject[20];

        // enemies[0] = Instantiate(enemyGreen) as GameObject;
        // enemies[0].transform.position = new Vector3(-0.25f, 0f, 1f);
        // enemies[0].transform.eulerAngles = new Vector3(0f, 0f, 0f);

        // enemies[1] = Instantiate(enemyRed) as GameObject;
        // enemies[1].transform.position = new Vector3(0.25f, 0f, 1f);
        // enemies[1].transform.eulerAngles = new Vector3(0f, 0f, 0f);
        
        for(int i = 0; i < 10; i++)
        {
            enemies[i] = Instantiate(enemyGreen) as GameObject;
            enemies[i].transform.position = RandomPosition();
            // random rotation
            enemies[i].transform.eulerAngles = RandomRotation();
        }

        for(int i = 10; i < 20; i++)
        {
            enemies[i] = Instantiate(enemyRed) as GameObject;
            enemies[i].transform.position = RandomPosition();
            // random rotation
            enemies[i].transform.eulerAngles = RandomRotation();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // verifica se todos os inimigos foram destruidos (active = false)
    public bool CheckEnemies()
    {
        foreach(GameObject enemy in enemies)
        {
            if(enemy.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    // incrementa o score
    public void IncrementScore()
    {
        score++;
        // scoreText.text = "Score: " + score;
        scoreText.text = score.ToString();
        if(CheckEnemies())
        {
            ResetEnemies();
        }
    }

    // reativar os inimigos
    public void ResetEnemies()
    {
        foreach(GameObject enemy in enemies)
        {
            // reposiciona os inimigos
            enemy.transform.position = RandomPosition();
            // random rotation
            enemy.transform.eulerAngles = RandomRotation();
            enemy.SetActive(true);
            enemy.SendMessage("StartChangeDirection");
        }
    }

    // gerar posições aleatorias para os inimigos
    public Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-distance, distance), Random.Range(-distance, distance), Random.Range(-distance, distance));
    }

    // gerar rotações aleatorias para os inimigos
    public Vector3 RandomRotation()
    {
        return new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
    }

}
