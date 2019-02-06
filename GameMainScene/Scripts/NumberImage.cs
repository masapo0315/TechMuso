using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberImage : MonoBehaviour {

    //画像のリスト
    [SerializeField]
    private List<Sprite> numList = new List<Sprite>();

    //引数で読んだ数値をnumに入れる
    public void OnImage(int num)
    {
        GetComponent<Image>().sprite = numList[num];
    }
}
