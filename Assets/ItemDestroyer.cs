using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    // Unityちゃんのオブジェクト
    private GameObject unityChan;

    // フレームアウトとみなすUnityちゃんとの距離
    private float frameOutDifference = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Unityちゃんのオブジェクトを取得
        this.unityChan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        // ユニティちゃんが通り過ぎて画面外に出たら破棄する
        if (unityChan.transform.position.z - this.transform.position.z > frameOutDifference)
        {
            Destroy(gameObject);
        }
    }
}
