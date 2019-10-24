using UnityEngine;
using UnityEngine.Audio;  //引用 音頻 api

public class GameManager : MonoBehaviour
{
   public AudioMixer mixer;

   public void Setvbgm(float value)
    {
        mixer.SetFloat("vbgm", value);
    }
}
