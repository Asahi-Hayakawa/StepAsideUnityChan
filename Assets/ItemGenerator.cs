﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemGenerator : MonoBehaviour
{
    // Unityちゃんのオブジェクト
    private GameObject unityChan;

    // carPrefabを入れる
    public GameObject carPrefab;

    // coinPrefabを入れる
    public GameObject coinPrefab;

    // cornPrefabを入れる
    public GameObject conePrefab;

    // アイテム生成済み地点
    private int itemGeneratedPos = 20;
    
    // 一度アイテムを生成するアイテムの範囲
    private int itemGenerateRange = 45;

    // ゴール地点
    private int goalPos = 360;

    // アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    // Start is called before the first frame update
    void Start()
    {
        // Unityちゃんのオブジェクトを取得
        this.unityChan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.itemGeneratedPos - this.unityChan.transform.position.z < this.itemGenerateRange)
        {
            // 一定の距離ごとにアイテムを生成
            for (int i = this.itemGeneratedPos; i < Math.Min(this.itemGeneratedPos + this.itemGenerateRange, this.goalPos); i += 15)
            {
                // どのアイテムを出すのかをランダムに設定
                int num = Random.Range(1, 11);
                if (num <= 2)
                {
                    // コーンをx軸方向に一直線に生成
                    for (float j = -1; j <= 0.8; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab);
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                    }
                }
                else
                {
                    // レーンごとにアイテムを生成
                    for (int j = -1; j <= 1; j++)
                    {
                        // アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        // アイテムを置くZ座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-5, 6);
                        // 60%コイン配置、30%車配置、10&何もなし
                        if (1 <= item && item <= 6)
                        {
                            // コインを生成
                            GameObject coin = Instantiate(coinPrefab);
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            // 車を生成
                            GameObject car = Instantiate(carPrefab);
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                        }
                    }
                }
            }

            this.itemGeneratedPos += itemGenerateRange;
        }
    }
}
