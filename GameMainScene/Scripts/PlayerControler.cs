using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour {

    //移動スピード
    [SerializeField]
    float speed;

    //ジャンプ力
    [SerializeField]
    float jumpPower;

    //RigitBodyを変数に入れる
    public Rigidbody rb;

    //Playerの位置
    Vector3 playerPos;

    //アニメーション
    [SerializeField]
    Animator anim;

    //AttackWeaponを入れておく変数
    AttackWeapon weaponscript;
    [SerializeField]
    GameObject WeaponObj;

    //武器のエフェクト
    public GameObject weaponEffect;

    //設置判定
    bool jump;

    //RigitBody,Animator,武器のオブジェクトを取得
    void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        weaponscript = WeaponObj.GetComponent<AttackWeapon>();
    }

    /*
    private void OnEnable()
    {
        weaponscript = WeaponObj.GetComponent<AttackWeapon>();
    }
    */

    void Update () {

        PlayerMove();
        PlayerJump();
        PlayerAttack();
	}

    void PlayerMove()
    {
        //ゲームパッドの←→で左右移動、↑↓で前後移動
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        //現在の位置から入力した位置の場所に移動
        rb.MovePosition(transform.position + new Vector3(x, 0, z));

        Vector3 direction = transform.position - playerPos;

        //移動距離が少しでもあった場合に方向転換
        if (direction.magnitude > 0.01f)
        {
            //directionのX軸とZ軸の方向に向かせる
            transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

            //移動のアニメーションを再生
            anim.SetBool("isWalk",true);

        }
        else
        {
            //移動して無い時はアニメーションを再生しない
            anim.SetBool("isWalk", false);
        }

        //Playerの位置の更新
        playerPos = transform.position;
    }

    void PlayerJump()
    {


        //地面にいるときにスペースキー・ゲームパッドのAボタンでジャンプ
        if (Input.GetButtonDown("Jump") && jump)
        {
            //Debug.Log("Jump!");

            //JumpPowerの分だけ上方に力をかけ、アニメーションを再生
            rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
            anim.SetBool("isJump", true);
            jump = false;

        } else {

            //ジャンプしてないときはアニメーションを再生しない
            anim.SetBool("isJump", false);

        }

    }

    
    void PlayerAttack()
    {
        if (weaponscript == null)
            return;

        //アニメーションが再生されている間当たり判定をオンにする
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("StrongAttack"))
        {
            //Debug.Log("bbb");

            weaponscript.WeaponCollider.isTrigger = true;

        } 　else　{

            //再生されてないときは当たり判定はオフ
            weaponscript.WeaponCollider.isTrigger = false;

        }
        if (Input.GetButtonDown("StrongAtack"))
        {
            //Debug.Log("aaa");

            //武器の当たり判定をtrueにしてアニメーションを再生
            anim.SetBool("isSAttack", true);

        }
        else
        {
            //ボタンが押されてない時はアニメーションを再生しない
            anim.SetBool("isSAttack", false);
        }
  
    }

    void OnWeaponEffect()
    {
       
    }


    private void OnCollisionEnter(Collision collision)
    {
        //地面に触れている間は設置判定はオン
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = true;
        }
    }

}
