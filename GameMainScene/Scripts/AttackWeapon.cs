using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWeapon : MonoBehaviour {

    //ゲームコントローラーの変数を受け取る用のオブジェクト
    public GameObject ObjectRecipients;

    //武器の当たり判定
    public Collider WeaponCollider;

    //効果音を入れる
    public AudioSource AttackSE;

    private void Start()
    {
        //当たり判定の取得
        WeaponCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider col)
    {
        //敵に攻撃が当たったら死亡処理を呼び出しスコアを加算する
        if(col.tag == "Enemy")
        {
            //Debug.Log("HIT!!");

            //GameControleのScorePlus関数を呼び出す
            ObjectRecipients.GetComponent<GameControler>().ScorePlus();
            //効果音を再生
            AttackSE.PlayOneShot(AttackSE.clip);
        }

    }



}
