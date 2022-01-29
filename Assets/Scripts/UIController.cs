using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverPanel, LevelCompletePanel;

    public Button restartGO, homeGO, play, home ;

    private void Start()
    {
        restartGO.onClick.AddListener(OnClickRestart);
        homeGO.onClick.AddListener(OnClickHome);

        play.onClick.AddListener(OnClickRestart);
        home.onClick.AddListener(OnClickHome);
    }

    void OnClickRestart()
    {
        SceneManager.LoadScene(1);
    }

    void OnClickHome()
    {
        SceneManager.LoadScene(0);
    }


    private void Update()
    {
        if (Manager.instance.playerCount==0)
        {
            Manager.instance.playerCount = 1;
            gameOverPanel.SetActive(true);
        }
        else if (Manager.instance.isDestination==true)
        {
            Manager.instance.isDestination = false;
            LevelCompletePanel.SetActive(true);
        }
    }
}
