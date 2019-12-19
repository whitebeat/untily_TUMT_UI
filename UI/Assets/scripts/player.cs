
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

        }
        if (other.tag == "Maki")
        {
            MakiCount++;
            textMaki.text = "Maki:" + MakiCount + "/" + MakiTotal;
            Destroy(other.gameObject);
        }
        if (other.name =="總點" && MakiCount == MakiTotal)
        {
            print("過關");
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "陷阱")
        {
            int d = other.GetComponent<trap>().damage;
            hp -= d;
            slider.value = hp;

        }
       
       
    }

    private void Start()
    {
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
}
