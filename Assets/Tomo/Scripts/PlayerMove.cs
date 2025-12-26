using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public int LIFE, FLAG, MaxFlag;
    public float SPEED, JumpPow;
    private PlayerStand playerStand;
    private int dig;
    private SpriteRenderer spriteRenderer;
    private int invincibleTime;
    [SerializeField] Timer timer;
    private ScoreTransfer scoreTransfer;
    [SerializeField] Sprite image01, image02;
    [SerializeField] SEController sEController;
    [SerializeField] RemarkController remarkController;
    [SerializeField] float[] buffs = {0,0,0,0,0,0,0,0,0,0};
    private float[] speedBuffAmount = {5,13,2};
    private float[] jumpBuffAmount = {6, 17, 3};
    // Start is called before the first frame update
    void Start()
    {
        dig = 1;
        invincibleTime = 0;
        MaxFlag = 11;
        FLAG = 0;
        LIFE = 3;
        playerStand = transform.GetChild(0).gameObject.GetComponent<PlayerStand>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = image01;

        scoreTransfer = GameObject.Find("ScoreTransfer").GetComponent<ScoreTransfer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {        
        if(LIFE > 0)
        {
            invincibleTime --;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 vel = rb.velocity;
            rb.velocity = new Vector2(0f, vel.y);
        
            float xVel = 0;
            
            float cspeed = SPEED + buffs[1];//buffIDの2は速度
            float cjump = JumpPow + buffs[2];//buffIDの3はジャンプ力

            if(Input.GetKey("d")){xVel = cspeed; dig=1;}
            if(Input.GetKey("a")){xVel = -cspeed; dig=-1;}
            if(Input.GetKey("space") && playerStand.standing && vel.y <= 0){rb.velocity += new Vector2(0f,cjump); sEController.Sound12();}
            if(!Input.GetKey("space") && vel.y > 0){rb.velocity += new Vector2(0f, (0f-vel.y)*0.1f);}

            rb.velocity = new Vector2(xVel, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0, 90- 90*dig, 0);

            if(transform.position.y < -10f){LIFE = 0; StartCoroutine("Miss");}        //奈落落下判定
            if(invincibleTime > 0){spriteRenderer.color = new(1,1,1,0.6f+ 0.2f*Mathf.Cos(Time.time*15));}else{spriteRenderer.color = new(1,1,1,1);}
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "flag")
        {
            sEController.Sound16();
            FLAG ++;
            Destroy(collider.gameObject);
            if(FLAG >= MaxFlag)
            {
                scoreTransfer.ResultTime(timer.timer);
                scoreTransfer.ResultType(0);
                SceneManager.LoadScene("ResultScene");
            }
        }

        if(collider.tag == "enemyColl" && invincibleTime < 0 && buffs[3] <= 0)
        {
            invincibleTime = 120;
            LIFE -= 1;
            sEController.Sound14();
            StartCoroutine("Miss");
        }
    }





    public void GiveBuff(int buffNum, int subNum)   //TOAH-X さんから受け取る
    {
        Debug.Log("buff" + buffNum + " level: " + subNum);
        if(buffNum == 1)    //残機回復・消滅
        {
            Debug.Log("残機を :" + subNum);
            if(subNum > 0)
            {
                Debug.Log("残機回復");
                LIFE += subNum;
                sEController.Sound6();
                if(LIFE >= 5){LIFE = 5;}
            }
            else
            {
                LIFE += subNum;
                sEController.Sound8();
                StartCoroutine("Miss");
                Debug.Log("残機消滅");
            }
        }
        if(buffNum == 2){StartCoroutine(BuffManager(2, speedBuffAmount[subNum-1]));}//移動速度上昇

        if(buffNum == 3){StartCoroutine(BuffManager(3, jumpBuffAmount[subNum-1] ));}//ジャンプ力上昇
        if(buffNum == 4){StartCoroutine(BuffManager(4,1));}//無敵
        if(buffNum == 5){KillEnemy();}//敵kill
        if(buffNum == 6){StartCoroutine(BuffManager(6,1));}//復活
    }

    /*public void GiveBuff(int buffNum)
    {
        if(buffNum == 5){KillEnemy();}//敵kill
        else{GiveBuff(buffNum,1);}//引数が足りない場合はsubNum=1の効果を付与する
    }*/


    IEnumerator BuffManager(int buffNum , float amount)     //5秒バフを付与するプログラム
    {
        sEController.Sound2();
        Debug.Log("5secBuff" + buffNum + ", amount:" + amount);
        
        buffs[buffNum-1] += amount;

        yield return new WaitForSeconds(5);

        buffs[buffNum-1] -= amount;
    }



    void KillEnemy()
    {
        Debug.Log("周囲の敵を消滅");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject targets in enemies){targets.gameObject.GetComponent<Enemy>().Killed(transform.position);}
    }

    IEnumerator Miss()  //change image when hit, and prosseses of death
    {
        spriteRenderer.sprite = image02;
        
        Debug.Log("Get Miss");
        if(LIFE > 0)
        {
            remarkController.BabinikuReceive();
            spriteRenderer.color = new Color(1,0,0);

            yield return new WaitForSeconds(0.1f);
            
            spriteRenderer.color = new Color(1,1,1);

            yield return new WaitForSeconds(0.5f);
            spriteRenderer.sprite = image01;
            
            yield break;
        }
        else
        {
            transform.DOJump(transform.position - new Vector3(dig*10, 10f, 0f), jumpPower: 10f, numJumps: 1, duration: 3f);
        
            remarkController.BabinikuDeath();

            sEController.Sound11();
            yield return new WaitForSeconds(4);

            if(buffs[5] == 1)//リスタート（復活）するコード
            {
                sEController.Sound11();
                LIFE = 1;
                transform.position = new Vector3(transform.position.x, 0f, 0f);
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                spriteRenderer.sprite = image01;
                yield break;
            }
            scoreTransfer.ResultType(1);
            SceneManager.LoadScene("ResultScene");
        }
    }


}
