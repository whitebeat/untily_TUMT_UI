using UnityEngine;
using UnityEngine.Audio;  //引用 音頻 api
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

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
        //SceneManager.LoadScene("場經");
        StartCoroutine(Loading());
    }

    private IEnumerator Loading()
    {
        //print("TEST 1");
        //yield return new WaitForSeconds(1);
        //print("TEST 2");

        AsyncOperation ao = SceneManager.LoadSceneAsync("遊戲場景");
        ao.allowSceneActivation = false;

        while (ao.isDone == false)
        {
            textloading.text = ((ao.progress / 0.9f) * 100).ToString();
            loading.value = ao.progress / 0.9f;
            yield return new WaitForSeconds(0.0001f);

            if (ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;
            }
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("介面");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
