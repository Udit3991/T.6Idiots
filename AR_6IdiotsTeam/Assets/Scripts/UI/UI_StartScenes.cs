using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StartScenes : MonoBehaviour
{
    private Button _petSnackButton;
    private Button _petSnackNormal;     // 누렁이 사료.
    private Button _petSnackRare;       // 일반 사료.
    private Button _petSnackSuperRare;  // 고급 사료.

    private Button _petPlayingButton;
    private Button _petPlayingPatPat;   // 쓰담쓰담.
    private Button _petPlayingPop;      // 빵야.
    private Button _petPlayingTurn;     // 돌아.

    private Button _petWalking;

    private Button _exit;

    private void Awake()
    {
        _petSnackButton = transform.Find("").GetComponent<Button>();
        _petSnackNormal = transform.Find("").GetComponent<Button>();
        _petSnackRare = transform.Find("").GetComponent<Button>();
        _petSnackSuperRare = transform.Find("").GetComponent<Button>();

        _petPlayingButton = transform.Find("").GetComponent<Button>();
        _petPlayingPatPat = transform.Find("").GetComponent<Button>();
        _petPlayingPop = transform.Find("").GetComponent<Button>();
        _petPlayingTurn = transform.Find("").GetComponent<Button>();

        _petWalking = transform.Find("").GetComponent<Button>();

        _exit = transform.Find("").GetComponent<Button>();
    }

    private void Start()
    {
        _petSnackButton.onClick.AddListener(OnClickSnackButton);
        _petSnackNormal.onClick.AddListener(OnClickSnackNormal);
        _petSnackRare.onClick.AddListener(OnClickSnackRare);
        _petSnackSuperRare.onClick.AddListener(OnClickSnackSuperRare);

        _petPlayingButton.onClick.AddListener(OnClickPlayingButton);
        _petPlayingPatPat.onClick.AddListener(OnClickPlayingPatPat);
        _petPlayingPop.onClick.AddListener(OnClickPlayingPop);
        _petPlayingTurn.onClick.AddListener(OnClickPlayingTurn);

        _petWalking.onClick.AddListener(OnClickWalking);

        _exit.onClick.AddListener(OnClickExit);
    }

    private void OnClickSnackButton()
    {
        
    }
    private void OnClickSnackNormal()
    {

    }
    private void OnClickSnackRare()
    {

    }
    private void OnClickSnackSuperRare()
    {

    }



    private void OnClickPlayingButton()
    {

    }
    private void OnClickPlayingPatPat()
    {

    }
    private void OnClickPlayingPop()
    {

    }
    private void OnClickPlayingTurn()
    {

    }



    private void OnClickWalking()
    {

    }



    private void OnClickExit()
    {

    }
}
