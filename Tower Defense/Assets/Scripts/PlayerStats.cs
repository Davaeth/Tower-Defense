using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public static int money;
    public int startMoney = 500;

    public static int lives;
    public int startLives = 20;

    public static int Rounds;

    public Text livesText;
    public Text moneyText;
    public Text roundsText;

    void Start()
    {
        money = startMoney;
        lives = startLives;

        Rounds = 0;
    }

     void Update()
    {
        livesText.text = lives + " LIVES";
        moneyText.text = "$" + money.ToString();
        roundsText.text = Rounds.ToString();
    }
}
