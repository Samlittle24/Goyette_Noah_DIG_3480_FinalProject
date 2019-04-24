using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public AudioSource Victory;
    public AudioSource Loss;

    public GameObject pSystem1;
    ParticleSystem systemEdit1;
    public GameObject pSystem2;
    ParticleSystem systemEdit2;





    public void PlayVictory()
    {
        Victory.Play();
    }

    public void PlayLoss()
    {
        Loss.Play();
    }

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text hardModeText;

    static public bool gameOver;
    private bool restart;
    public static bool hardmode;

    private int score;

    void Start ()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        hardModeText.text = "Press 'H' to Toggle Hard Mode";
        score = 0;
        UpdateScore ();
        StartCoroutine (SpawnWaves ());

        systemEdit1 = pSystem1.GetComponent<ParticleSystem>();
        systemEdit1.Play();
        systemEdit2 = pSystem2.GetComponent<ParticleSystem>();
        systemEdit2.Play();

        hardmode = false;
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Space Shooter");
            }
        }
        if (Input.GetKey("escape"))
            Application.Quit();


        if (Input.GetKeyDown(KeyCode.H))
        {
            //var m = GetComponent<Mover>();
            //m.
            //Mover.speed = -20.0f;
            
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");


            if (!hardmode)
            {
                hardmode = true;
                Mover.speed = -7.5f;

                // set to hard

                //list = [hotdog,hamburger,orange]
                //for food in list
                //{
                //    eat(food)
                //}

                /*foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<Mover>().setfast();
                    
                }*/

            }
            else
            {
                // turning hard mode off

                hardmode = false;
                Mover.speed = -5.0f;

                /*foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<Mover>().setslow();

                }*/

            }
            
        }


    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0, hazards.Length)];
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'Space' to Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore ();
    }

    void UpdateScore ()
    {
        ScoreText.text = "Points: " + score;
        { 
        if (score >= 100)
            {
                winText.text = "You win! Game created by Noah Goyette";
                gameOver = true;
                restart = true;
                Victory.Play();
            }
        }
    }

    public void GameOver ()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
        Loss.Play();

        systemEdit1.Pause();
        systemEdit2.Pause();

    }
}