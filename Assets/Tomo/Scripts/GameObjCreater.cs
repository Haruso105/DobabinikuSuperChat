using System.Collections.Generic;
using UnityEngine;

public class GameObjCreater : MonoBehaviour
{
    [SerializeField] GameObject enemyRed, enemyGreen, flag;
    private List<GameObject> objClass = new List<GameObject>();
    private List<Vector3> objPos = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        //GameObject enemyRed = (GameObject)Resources.Load("Enemy_red");
        //GameObject enemyGreen = (GameObject)Resources.Load("Enemy_green");
        //GameObject flag = (GameObject)Resources.Load("Flag");


        //オブジェクトの配置でーた♡
        //objectClass で敵、旗の種類を選択 objPos にその座標を入れる
        objClass.Add(enemyGreen); objPos.Add(new Vector3(10f, -2f, 0f));
        objClass.Add(enemyGreen); objPos.Add(new Vector3(27f, -2f, 0f));
        objClass.Add(enemyGreen); objPos.Add(new Vector3(75f, 6f, 0f));
        objClass.Add(enemyRed); objPos.Add(new Vector3(70f, -2f, 0f));
        objClass.Add(enemyGreen); objPos.Add(new Vector3(42f, -2f, 0f));
        objClass.Add(enemyGreen); objPos.Add(new Vector3(105f, -2f, 0f));
        objClass.Add(enemyGreen); objPos.Add(new Vector3(122f, 6f, 0f));
        objClass.Add(enemyGreen); objPos.Add(new Vector3(169f, -2f, 0f));
        objClass.Add(enemyGreen); objPos.Add(new Vector3(14f, 2f, 0f));
        objClass.Add(flag); objPos.Add(new Vector3(14f, 2f, 0f));
        objClass.Add(flag); objPos.Add(new Vector3(46f, -2f, 0f));
        objClass.Add(flag); objPos.Add(new Vector3(-10f, -2f, 0f));
        objClass.Add(flag); objPos.Add(new Vector3(67.5f, 2f, 0f));
        objClass.Add(flag); objPos.Add(new Vector3(81f, 6f, 0f));
        objClass.Add(flag); objPos.Add(new Vector3(100.5f, 6f, 0f));
        objClass.Add(flag); objPos.Add(new Vector3(123f, 2f, 0f));
        objClass.Add(flag); objPos.Add(new Vector3(156f, 0f, 0f));
        objClass.Add(flag); objPos.Add(new Vector3(181f, 6f, 0f));
        objClass.Add(flag); objPos.Add(new Vector3(195f, -2f, 0f));//flag10
        objClass.Add(flag); objPos.Add(new Vector3(145.5f, 3f, 0f));//flag11


        for(int i=0 ; i < objClass.Count; i++)
        {
            GameObject obj = (GameObject)Instantiate(objClass[i], objPos[i],Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
