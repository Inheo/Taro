using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [System.Serializable]
    public struct CardsInformation
    {
        public Sprite[] spriteCards;
    }

    public CardsInformation[] CardsInformations;

    [System.Serializable]
    private struct ResultCards
    {
        public Sprite[] iconCards;
    }

    [SerializeField] private ResultCards[] resultCards;

    [SerializeField] private Sprite[] iconSigns;
    [SerializeField] private string[] nameDecks;

    [SerializeField] private Image predictionCard;
    [SerializeField] private Image sign;

    [SerializeField] private GameObject choosePanel;
    [SerializeField] private GameObject adsPanel;

    [SerializeField] private Image imageCard;

    [SerializeField] private CanvasGroup resultPanel;

    [SerializeField] private Text nameDeckText;


    private int indexChoosingCard;

    public static Game Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        sign.sprite = iconSigns[TemporaryVariables.IndexDeckForDivination];
        nameDeckText.text = nameDecks[TemporaryVariables.IndexDeckForDivination];
    }

    public void ShowResult()
    {
        adsPanel.SetActive(false);

        imageCard.sprite = resultCards[TemporaryVariables.IndexDeckForDivination].iconCards[indexChoosingCard];
        imageCard.SetNativeSize();

        resultPanel.DOFade(1, 0.8f).OnStart(() => 
        {
            resultPanel.blocksRaycasts = true;
        });
    }

    public void HideResult()
    {
        resultPanel.DOFade(0, 0.8f).OnStart(() =>
        {
            resultPanel.blocksRaycasts = false;
        });
    }

    public void ChooseCard()
    {
        adsPanel.SetActive(true);
        choosePanel.SetActive(false);

        CardsInformation card = CardsInformations[TemporaryVariables.IndexDeckForDivination];
        indexChoosingCard = Random.Range(0, card.spriteCards.Length);
        predictionCard.sprite = card.spriteCards[indexChoosingCard];
        predictionCard.SetNativeSize();
        predictionCard.rectTransform.sizeDelta = new Vector2(predictionCard.rectTransform.sizeDelta.x / 1.8f, predictionCard.rectTransform.sizeDelta.y / 1.8f);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
