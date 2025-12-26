using UnityEngine;

public class EnemyColl : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    public int collClass;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "level" || collision.tag == "enemy") 
        {
            if(collClass == 0){enemy.dig *= -1;}
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag == "level"){if(collClass == 1){enemy.dig *= -1;}}
    }
}
