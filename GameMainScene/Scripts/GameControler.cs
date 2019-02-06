using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour {

    //制限時間の変数
    //public Text timerText;
    public float totalTime;
    int seconds;

    //スコアの変数
    //public Text scoreText;
    public static int score = 0;

    //スコア用の画像
    [SerializeField] List<NumberImage> scoreNumImage = new List<NumberImage>();

    //タイマー用の画像
    [SerializeField] List<NumberImage> timeNumImage = new List<NumberImage>();

	
	// Update is called once per frame
	private void Update () {

        Timer();

        //scoreText.text = score.ToString();
        //timerText.text = seconds.ToString();
    }

    void Timer()
    {
        //timerの配列に数字を入れる
        timeNumImage[0].OnImage((int)totalTime / 10); 
        timeNumImage[1].OnImage((int)totalTime % 10);
        // 1秒ずつマイナス
        totalTime -= Time.deltaTime;
        seconds = (int)totalTime;
        if (totalTime < 0)
        {
            SceneManager.LoadScene("End");
        }
    }

    //スコアの加算
    public void ScorePlus()
    {
        score += 10;

        //scoreの各配列に数字を入れる
        scoreNumImage[0].OnImage(score / 1000);
        scoreNumImage[1].OnImage((score % 1000) / 100);
        scoreNumImage[2].OnImage((score % 100) /　10);

        //scoreText.text = score.ToString();
    }

    public static int getScore()
    {
        return score;
    }

}
