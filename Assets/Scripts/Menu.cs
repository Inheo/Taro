using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject changingCardsDescriptionPanelGameObject;
    [SerializeField] private CanvasGroup descriptionPanel;
    void Start()
    {
        HideDescriptionPanel();
    }

    public void ShowDescriptionPanel(int index)
    {
        TemporaryVariables.IndexDescription = index;
        changingCardsDescriptionPanelGameObject.SetActive(true);
        descriptionPanel.DOFade(1, 0.8f).OnStart(() => 
        {
            descriptionPanel.blocksRaycasts = true;
        });
    }

    public void HideDescriptionPanel()
    {
        changingCardsDescriptionPanelGameObject.SetActive(false);
        descriptionPanel.DOFade(0, 0.8f).OnStart(() =>
        {
            descriptionPanel.blocksRaycasts = false;
        });
    }

    public void ToGuess(int index)
    {
        TemporaryVariables.IndexDeckForDivination = index;
        SceneManager.LoadScene("Guess");
    }
}
