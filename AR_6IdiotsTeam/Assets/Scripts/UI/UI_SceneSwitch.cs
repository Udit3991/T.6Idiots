using IF.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace IF.UI
{
    public class UI_SceneSwitch : SingletonMonoBase<UI_SceneSwitch>
    {
        private Button _exit;
        private Button _sceneSwitch;

        protected override void Awake()
        {
            base.Awake();

            _exit = transform.Find("Button - Exit").GetComponent<Button>();
            _sceneSwitch = transform.Find("Button - Switch").GetComponent<Button>();
        }

        private void Start()
        {
            _exit.onClick.AddListener(OnClickExit);
            _sceneSwitch.onClick.AddListener(OnClickSwitch);
        }

        private void OnClickSwitch()
        {
            Debug.Log($"[{GetType()}({name})]: Scene Swich Clicked");

            if (SceneManager.GetActiveScene().name == "BlankAR")
            {
                SceneManager.LoadScene("ARMap");
            }
            else if (SceneManager.GetActiveScene().name == "ARMap")
            {
                SceneManager.LoadScene("BlankAR");
            }
            else
            {
                Debug.LogError($"[{GetType()}({name})]: Check Scnen Name!");
            }
        }

        private void OnClickExit()
        {
            Debug.Log($"[{GetType()}({name})]: Exit Clicked");
            // todo: 진짜로 끌지 확인창 띄우기
            Application.Quit();
        }
    }
}
