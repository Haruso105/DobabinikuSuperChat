using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainCameraController : MonoBehaviour
{
    //[SerializeField] Transform playerTransform;                 //プレイヤーのtransform情報

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //プレイヤーの向きを考慮する場合は必要(どちらを向いても関係ない場合は無視して良い)
        /*
        float posX = 0;                                     //x軸(プレイヤーの向いている向きで変わる)
        if (playerScript.IsLookRight)
        {
            posX = 0.5f;
        }
        else
        {
            posX = -0.5f;
        }
        */
        //追従部分(第2引数の数値を調整すること。)
        /*
        transform.position = Vector3.Lerp(transform.position, playerTransform.position + new Vector3(posX, 1.0f, -10), 5.0f * Time.deltaTime);
        */
    }


    //画面揺れ(揺れの長さ、強さ、振動の回数、ランダム性、徐々に弱めるか)
    public void ShakeCamera(float duration, Vector2 strength, int vibrato, float randomness, bool snapping, bool fadeoOut)
    {
        transform.DOShakePosition(duration, new Vector3(strength.x, strength.y, 1.0f), vibrato, randomness, snapping, fadeoOut);
    }
}
