using UnityEngine;
using UnityEngine.Audio;  //引用 音頻 api
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public AudioMixer mixer;
   public Text textloading;
   public Slider loading;


   public void Setvbgm(float value)
    {
        mixer.SetFloat("vbgm", value);
    }
   public void Setvsfx(float value)
    {
        mixer.SetFloat("vsfx", value);
    }
   public void play()
    {
        SceneManager.LoadScene("場經");
    }
}
