using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MapClieit : MonoBehaviour
{
    //オブジェクトを宣言
    public GameObject floorPrefab; //床
    public GameObject wallPrefab; //マップ内の壁
    public GameObject playerPrefab;//プレイヤー
                                   //public GameObject Enemy;
                                   //public GameObject Enemy1;
                                   //public GameObejct Enemy2;

    public GameObject GameManager;
    public GameState MapState;

    public int[,] player;


    // Start is called before the first frame update
    void Start()
    {
        
        int[,] map =
        {
            { 0,0,0,0,0,0,0,0},
            { 0,1,1,1,1,1,1,0},
            { 0,1,1,1,1,1,1,0},
            { 0,1,1,1,1,1,1,0},
            { 0,1,1,1,1,1,1,0},
            { 0,1,1,1,1,1,1,0},
            { 0,1,1,1,1,2,1,0},
            { 0,0,0,0,0,0,0,0},
        };



        //各インデックスに代入された値を基に、壁の生成、不生成を判別
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                //インデックスの値が1の時、wallPrefabを生成
                if (map[i, j] == 1 || map[i, j] == 2 || map[i, j] == 4 || map[i, j] == 5)
                {
                    GameObject go = Instantiate(floorPrefab);
                    go.transform.position = new Vector2(i, j);

                }
                //インデックスの値が1の時、wallPrefabを生成
                if (map[i, j] == 0)
                {
                    GameObject wall = Instantiate(wallPrefab);
                    wall.transform.position = new Vector2(i, j);

                }
                if (map[i, j] == 2)
                {
                    GameObject go = Instantiate(playerPrefab);
                    go.transform.position = new Vector2(i, j);
                }
                //if(map[i,j] == 3)
                //{
                //    GameObject go = Instantiate(Enemy);
                //    go.transform.position = new Vector2(i, j);
                //}
                //if(map[i,j] == 4)
                //{
                //    GameObject go = Instantiate(Enemy1);
                //    go.transform.position = new Vector2(i, j);
                //}
                //if (map[i, j] == 5)
                //{
                //    GameObject go = Instantiate(Enemy2);
                //    go.transform.position = new Vector2(i, j);
                //}
            }
        }

    }

}
