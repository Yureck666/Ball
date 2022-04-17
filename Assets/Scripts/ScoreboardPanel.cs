using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreboardPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup loseCanvasGroup;
    [SerializeField] private CanvasGroup scoreCanvasGroup;
    [SerializeField] private Text bestScoreText;
    [SerializeField] private Text currentScoreText;
    [SerializeField] private Image blink;
    private CanvasGroup _canvasGroup;
    private Image _image;
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _image = GetComponent<Image>();
        _image.raycastTarget = false;
        _canvasGroup.alpha = 0;
        blink.color = new Color(255, 255, 255, 255);
    }

    private void Start()
    {
        blink.DOFade(0, 2);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            blink.DOFade(1, 0.1f).OnComplete(() => SceneManager.LoadScene(0));
        }
    }

    public void OpenScore(bool win)
    {
        _image.raycastTarget = true;
        if (win)
        {
            bestScoreText.text = PlayerPrefs.GetFloat("BestTime") + " сек";
            currentScoreText.text = PlayerPrefs.GetFloat("LastTime") + " сек";
            scoreCanvasGroup.alpha = 1;
        }
        else
        {
            loseCanvasGroup.alpha = 1;
        }
        
        _canvasGroup.DOFade(1, 0.2f);
    }
}
