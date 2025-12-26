using UnityEngine;

public class ScoreTransfer : MonoBehaviour
{

    public static ScoreTransfer Instance;

    [SerializeField]SupachaController scScript;

    [SerializeField]int totalAmount = 0;
    [SerializeField]float remainTime = 0f;
    [SerializeField]int holdAmount = 0;
    [SerializeField]int gameResultType = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void FindSupachaController()
    {
        scScript = GameObject.Find("SupachaController").GetComponent<SupachaController>();
    }

    public void ResultType(int n)
    {
        gameResultType = n;
        totalAmount = scScript.TotalSupachaAmount();
        holdAmount = scScript.CurrentMoney();
    }
    public void ResultTime(float t)
    {
        remainTime = t;
    }
    public int ReturnGameResult()
    {
        return gameResultType;
    }
    public float ReturnResultTime()
    {
        return remainTime;
    }

    public float ReturnHoldAmount()
    {
        return holdAmount;
    }
    public float ReturnTotalAmount()
    {
        return totalAmount;
    }
}
