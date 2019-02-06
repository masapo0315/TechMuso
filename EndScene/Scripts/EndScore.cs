using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour {


    //リザルトスコア用の画像
    //public Text ResultScoreText;
    [SerializeField] List<NumberImage> resultScoreNumImage = new List<NumberImage>();


	// Use this for initialization
	void Start () {

        //GameMainのスコアを参照
        int resultScore = GameControler.getScore();

        //スコア表示
        //ResultScoreText.text = resultScore.ToString();
        resultScoreNumImage[0].OnImage(resultScore / 1000);
        resultScoreNumImage[1].OnImage((resultScore % 1000) / 100);
        resultScoreNumImage[2].OnImage((resultScore % 100) / 10);

    }
    
}
