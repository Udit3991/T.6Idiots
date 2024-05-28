using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace IF.UI
{ 
    public class UI_StartScenes : MonoBehaviour
    {
        private Button _petSnackButton;
        private Image _petSnackPanel;
        private Button _petSnackNormal;     // 누렁이 사료.
        private Button _petSnackRare;       // 일반 사료.
        private Button _petSnackSuperRare;  // 고급 사료.
    
        private Button _petPlayingButton;
        private Image _petPlayingPanel;
        private Button _petPlayingPatPat;   // 쓰담쓰담.
        private Button _petPlayingPop;      // 빵야.
        private Button _petPlayingTurn;     // 돌아.


        private void Awake()
        {
            _petSnackButton = transform.Find("Snack/Button - Snack").GetComponent<Button>();
            _petSnackPanel = transform.Find("Snack/Panel").GetComponent<Image>();
            _petSnackNormal = _petSnackPanel.transform.Find("Button - Normal").GetComponent<Button>();
            _petSnackRare = _petSnackPanel.transform.Find("Button - Rare").GetComponent<Button>();
            _petSnackSuperRare = _petSnackPanel.transform.Find("Button - SuperRare").GetComponent<Button>();

            _petPlayingButton = transform.Find("Playing/Button - Playing").GetComponent<Button>();
            _petPlayingPanel = transform.Find("Playing/Panel").GetComponent<Image>();
            _petPlayingPatPat = _petPlayingPanel.transform.Find("Button - PatPat").GetComponent<Button>();
            _petPlayingPop = _petPlayingPanel.transform.Find("Button - Pop").GetComponent<Button>();
            _petPlayingTurn = _petPlayingPanel.transform.Find("Button - Turn").GetComponent<Button>();
        }

        private void Start()
        {
            _petSnackButton.onClick.AddListener(OnClickSnackButton);
            _petSnackPanel.gameObject.SetActive(false);
            _petSnackNormal.onClick.AddListener(OnClickSnackNormal);
            _petSnackRare.onClick.AddListener(OnClickSnackRare);
            _petSnackSuperRare.onClick.AddListener(OnClickSnackSuperRare);

            _petPlayingButton.onClick.AddListener(OnClickPlayingButton);
            _petPlayingPanel.gameObject.SetActive(false);
            _petPlayingPatPat.onClick.AddListener(OnClickPlayingPatPat);
            _petPlayingPop.onClick.AddListener(OnClickPlayingPop);
            _petPlayingTurn.onClick.AddListener(OnClickPlayingTurn);
        }

        #region Snack
        private void OnClickSnackButton()
        {
            _petSnackPanel.gameObject.SetActive(true);
            _petPlayingPanel.gameObject.SetActive(false);
        }

        private void OnClickSnackNormal()
        {
            Debug.Log($"[{GetType()}({name})]: Snack Normal Clicked");
        }

        private void OnClickSnackRare()
        {
            Debug.Log($"[{GetType()}({name})]: Snack Rare Clicked");
        }

        private void OnClickSnackSuperRare()
        {
            Debug.Log($"[{GetType()}({name})]: Snack Super Rare Clicked");
        }
        #endregion

        #region Playing
        private void OnClickPlayingButton()
        {
            _petPlayingPanel.gameObject.SetActive(true);
            _petSnackPanel.gameObject.SetActive(false);
        }

        private void OnClickPlayingPatPat()
        {
            Debug.Log($"[{GetType()}({name})]: Playing PatPat Clicked");
        }

        private void OnClickPlayingPop()
        {
            Debug.Log($"[{GetType()}({name})]: Playing Pop Clicked");
        }

        private void OnClickPlayingTurn()
        {
            Debug.Log($"[{GetType()}({name})]: Playing Turn Clicked");
        }
        #endregion
    }
}
