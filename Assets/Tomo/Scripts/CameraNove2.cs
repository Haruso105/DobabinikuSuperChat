using UnityEngine;

public class CameraMove2 : MonoBehaviour
{
    [SerializeField] GameObject player;
    private PlayerMove pmove;
    // Start is called before the first frame update
    void Start()
    {
        pmove = player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(pmove.LIFE > 0)
        {
            Transform playerTransform = player.transform;
            float posX = 0;                                     //x��(�v���C���[�̌����Ă�������ŕς��)
            /*if (playerScript.IsLookRight)
            {
                posX = 0.5f;
            }
            else
            {
                posX = -0.5f;
            }*/
            if(transform.position.y < -2f)
            {
                transform.position = new Vector3(transform.position.x, -2f, -10f);
            }
            else if(transform.position.y > 1f)
            {
                transform.position = new Vector3(transform.position.x, 1f, -10f);
            }
            {
                transform.position = Vector3.Lerp(transform.position, playerTransform.position + new Vector3(posX+3, -2f, -10f), 5.0f * Time.deltaTime);
            }
        }
    }
}
