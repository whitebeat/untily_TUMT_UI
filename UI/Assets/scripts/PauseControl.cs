using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour 
 {
		[Header("暫停介面")]
        public Image ImagePause;
        public Sprite spritePause, spritePlay;
        [Header("暫停")]
        public bool pause;

    /// <summary>
    /// 暫停方法
    /// </summary>
    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("暫停~");
            // !相反:將布林職改為相反
            pause = !pause;

            ImagePause.sprite = pause ? spritePlay : spritePause;

            Time.timeScale = pause ? 0 : 1;
        }
        
    }

    // 更新:一秒約60次
    private void Update()
    {
        Pause();
    }

}
