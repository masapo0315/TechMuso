using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    //追いかける対象
    Transform target;

    //NavMeshAgent
    private NavMeshAgent agent;　

    //アニメーションを入れる変数
    [SerializeField]
    Animator anim;

    //エフェクトを入れる変数
    public GameObject deadeffect;

    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("PlayerTechc").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {   //ターゲットの位置を目的地に設定してアニメーションを再生
        agent.destination = target.transform.position;
        anim.SetBool("Walk", true);
    }


    //武器に当たったらエフェクトを表示し消滅させる
    private void OnTriggerEnter(Collider col)
    {
       // Debug.Log("やられた～");
        Instantiate(deadeffect, this.transform.position, Quaternion.identity); 
        Destroy(this.gameObject);
    }
}
