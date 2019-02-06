using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoDescription : MonoBehaviour {

    private void Update()
    {
        //クリックしたら操作説明へ移動
        if (Input.GetButtonDown("Enter"))
        {
            SceneManager.LoadScene("Description");
        }
    }

}
