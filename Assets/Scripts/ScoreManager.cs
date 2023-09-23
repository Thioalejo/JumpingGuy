using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public Text textPoints, maxPointText;


    [SerializeField] private int points = 0;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateMaxPoint();
    }

    public void IncreasePoints()
    {
        points++;
        textPoints.text = points.ToString();
        UpdateMaxPoint();
    }

    public void UpdateMaxPoint()
    {
        int maxPoint = PlayerPrefs.GetInt("Max",0);
        if (points>= maxPoint)
        {
            maxPoint = points;
            PlayerPrefs.SetInt("Max", maxPoint);
        }

        maxPointText.text = "BETS: " + maxPoint.ToString();
    }
}
