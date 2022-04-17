using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Image blink;
    [SerializeField] private ScoreboardPanel scoreboardPanel;
    
    public void StartGame()
    {
        blink.DOFade(1, 0.1f).OnComplete(() => SceneManager.LoadScene(1));
    }

    public void ShowResults()
    {
        scoreboardPanel.OpenScore(true);
    }
}
