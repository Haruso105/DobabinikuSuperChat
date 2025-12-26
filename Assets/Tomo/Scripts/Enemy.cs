using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int dig;
    public float SPEED;
    private Transform ptra;
    [SerializeField] bool active, living;
    // Start is called before the first frame update
    void Start()
    {
        ptra = GameObject.Find("Player").gameObject.transform;
        SPEED = 5f;
        active = false;
        living = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(living)
        {
                if(active)
            {
                transform.position += new Vector3(SPEED*dig*Time.deltaTime, 0f, 0f);
                transform.rotation = Quaternion.Euler(0, 90- 90*dig, 0);
            }
            else{if(Mathf.Abs(transform.position.x - ptra.position.x) < 10){active = true;}
        }
        }
        
    }

    public void Killed(Vector2 playerPos)
    {
        if(Vector2.Distance(playerPos, transform.position) < 33)
        {
            StartCoroutine("DieOut");
        }
    }

    IEnumerator DieOut()
    {
        living = false;
        transform.rotation = Quaternion.Euler(180, -90+ 90*dig, 0);
        transform.DOJump(transform.position - new Vector3(dig*10, 10f, 0f), jumpPower: 10f, numJumps: 1, duration: 3f);
        
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }
}
