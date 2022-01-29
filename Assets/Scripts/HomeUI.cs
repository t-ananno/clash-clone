
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeUI : MonoBehaviour
{
    [SerializeField]
    private Button btn;
    void Start()
    {
        btn.onClick.AddListener(LoadGame);
    }

    void LoadGame() => SceneManager.LoadScene(1);
}
