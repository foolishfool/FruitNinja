using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIScore : MonoBehaviour {

    /// <summary>
    /// Singleton
    /// </summary>
    public static UIScore Instance = null;

    void Awake()
    {
        Instance = this;
    }

    [SerializeField]
    Text txtScore;
    //current score
    private int score = 0;

    public void Add(int addScore)
    {
        score += addScore;
        txtScore.text = this.score.ToString();
    }

    public void Reduce(int reduceScore)
    {
        score -= reduceScore;
        txtScore.text = this.score.ToString();

        if (score < 0)
        {
            SceneManager.LoadScene(2);
            return;
        }
    }
}


