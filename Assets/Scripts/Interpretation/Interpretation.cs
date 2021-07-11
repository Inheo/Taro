using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Interpretation : MonoBehaviour
{

    [System.Serializable]
    private struct InformationForInterpretation
    {
        public Sprite[] informationIcon;
    }
    [SerializeField] private CanvasGroup cardInformationPanel;

    [SerializeField] private InformationForInterpretation[] informationForInterpretations;

    [SerializeField] private Image informationImage;

    
    [SerializeField] private Image sign;

    [SerializeField] private Sprite[] iconSigns;

    [SerializeField] private GameObject cardsInterpretationSpawnerGameObject;

    [SerializeField] private CanvasGroup interpretationPanel;
    void Start()
    {
        HideInterpretationPanel();
        HideCardInformation();
    }

    public void ShowInterpretationPanel(int index)
    {
        TemporaryVariables.IndexInterpretation = index;
        
        sign.sprite = iconSigns[TemporaryVariables.IndexInterpretation];
        
        cardsInterpretationSpawnerGameObject.SetActive(true);
        interpretationPanel.DOFade(1, 0.8f).OnStart(() => 
        {
            interpretationPanel.blocksRaycasts = true;
        });
    }

    public void HideInterpretationPanel()
    {
        cardsInterpretationSpawnerGameObject.SetActive(false);
        interpretationPanel.DOFade(0, 0.8f).OnStart(() =>
        {
            interpretationPanel.blocksRaycasts = false;
        });
    }

    public void ShowCardInformation(int index)
    {
        
        informationImage.sprite = informationForInterpretations[TemporaryVariables.IndexInterpretation].informationIcon[index];
        informationImage.SetNativeSize();

        cardInformationPanel.DOFade(1, 0.8f).OnStart(() =>
        {
            cardInformationPanel.blocksRaycasts = true;
        });
    }
    public void HideCardInformation()
    {
        cardInformationPanel.DOFade(0, 0.8f).OnComplete(() =>
        {
            cardInformationPanel.blocksRaycasts = false;
        });
    }
}
