
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    [Header("血量與血條")]
    public int hp = 100;
    public Slider slider;

    [Header("壽司區域")]
    public Text textMaki;
    public int MakiCount;
    public int MakiTotal;
    [Header("時間區域")]
    public Text textTime;
    public float gameTime;

    [Header("結束畫布")]
    public GameObject final;
    public Text textBest;
    public Text textCurrent;

    public Text TextMaki
    {
        get
        {
            return textMaki;
        }

        set
        {
            textMaki = value;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);

        if (other.tag == "陷阱")
        {
            int d = other.GetComponent<trap>().damage;
            hp -= d;
            slider.value = hp;
            if (hp <= 0) Dead();


        }
        if (other.tag == "Maki")
        {
            MakiCount++;
            textMaki.text = "Maki:" + MakiCount + "/" + MakiTotal;
            Destroy(other.gameObject);
        }
        if (other.name =="總點" && MakiCount == MakiTotal)
        {
            GameOver();
        }
    }


    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "陷阱")
        {
            int d = other.GetComponent<trap>().damage;
            hp -= d;
            slider.value = hp;
            if (hp <= 0) Dead();

        }
       
       
    }


    private void Start()
    {
        if(PlayerPrefs.GetFloat("最佳紀錄") == 0)
        {
            PlayerPrefs.SetFloat("最佳紀錄", 999999);
        }

        MakiTotal = GameObject.FindGameObjectsWithTag("Maki").Length;
        textMaki.text = "Maki:0/" + MakiTotal;
    }

    public void Update()
    {
        UpdateTime();
    }

    private void UpdateTime()
    {
        gameTime += Time.deltaTime;
        textTime.text = gameTime.ToString("F2");
    }

    private void Dead()
    {
        final.SetActive(true);
        textCurrent.text = "TIME : " + gameTime.ToString("F2");
        textBest.text = "BEST" + PlayerPrefs.GetFloat("最佳紀錄").ToString("F2");
        Cursor.lockState = CursorLockMode.None;

        GetComponent<FPSControllerLPFP.FpsControllerLPFP>().enabled = false;
        enabled = false;
    }

    private void GameOver()
    {
        final.SetActive(true);
        textCurrent.text = "TIME : " + gameTime.ToString("F2");

        if (gameTime < PlayerPrefs.GetFloat("最佳紀錄"))
        {
            PlayerPrefs.SetFloat("最佳紀錄", gameTime);
        }
        textBest.text = "BEST" + PlayerPrefs.GetFloat("最佳紀錄").ToString("F2");

        Cursor.lockState = CursorLockMode.None;

    }

}
