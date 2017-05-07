using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    public Text scoreText;

    private float startTime;

    public static string Format(float score)
    {
        // Show only 1 decimal place
        return score.ToString("F1");
    }

    public float Score { get; private set; }

    public string ScoreFormatted
    {
        get
        {
            return Format(Score);
        }
    }

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        Score = Time.time - startTime;
        scoreText.text = Format(Score);
    }
}
