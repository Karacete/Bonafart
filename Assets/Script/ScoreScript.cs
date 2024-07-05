using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private CharacterScript player;
    private double score;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<CharacterScript>();
        score = 0;
    }
    private void FixedUpdate()
    {
        score = player.score;
        scoreText.text = score.ToString() + " mt.";
    }
}
