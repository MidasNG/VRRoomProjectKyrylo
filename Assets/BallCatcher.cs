using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallCatcher : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int score = 0;

    void Start()
    {
        scoreText.text = "Score: 0";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            score++;
            scoreText.text = "Score: " + score;
            other.GetComponent<BallBehaviour>().ResetBall();
        }
    }
}
