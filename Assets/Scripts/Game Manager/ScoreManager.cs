using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//this class keep track of score in float and present it in a integer form
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private float score = 1.0f;

    //getter
    public float Score {get {return score;}}
    void Update()
    {
        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString();
    }
}
