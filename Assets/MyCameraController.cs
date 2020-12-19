using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    // Unityちゃんのオブジェクト
    private GameObject unityChan;

    // Unityちゃんとカメラの距離
    private float difference;

    // Start is called before the first frame update
    void Start()
    {
        // Unityちゃんのオブジェクトを取得
        this.unityChan = GameObject.Find("unitychan");

        // Unityちゃんとカメラの位置（z座標）の差を求める
        this.difference = unityChan.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // Unityちゃんの位置にあわせてカメラの位置を移動
        this.transform.position = new Vector3(0, this.transform.position.y, this.unityChan.transform.position.z - difference);
    }
}
