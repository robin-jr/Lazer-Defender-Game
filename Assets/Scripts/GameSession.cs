using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int score = 0;
    [SerializeField] int pointsPerShoot = 83;
    [SerializeField] Text scoreText;

    private void Awake()
    {
        if (GameObject.FindObjectsOfType<GameSession>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        if (scoreText)
        {
            scoreText.text = score.ToString();

        }
    }

    // // Update is called once per frame
    // void Update()
    // {

    // }

    public int GetScore()
    {
        return score;
    }
    public void AddToScore()
    {
        score += pointsPerShoot;
        if (scoreText)
        {
            scoreText.text = score.ToString();
        }

    }
    public void ResetGameSession()
    {
        Destroy(gameObject);
    }

}
