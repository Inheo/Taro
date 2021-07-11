using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public static class ButtonExtension
{
    public static void ShowCardInformation(this Button button, int index, Action<int> Show)
    {
        button.onClick.AddListener(delegate () {
            Show(index);
        });
    }
}

public class CardsInterpretationSpawner : MonoBehaviour
{
    [System.Serializable]
    private struct Card 
    {
        public Sprite[] CardSprites;
    }
    
    [SerializeField] private Card[] cards;

    [SerializeField] private ElementInterpretation cardPrefab;

    [SerializeField] private Transform parentElements;

    [SerializeField] private Interpretation interpretation;

    [SerializeField] private RectTransform contentRect;

    private List<ElementInterpretation> spawnedCards = new List<ElementInterpretation>();

    private void OnEnable()
    {
        Spawn();
    }

    private void Spawn()
    {
        if(spawnedCards.Count < cards[TemporaryVariables.IndexInterpretation].CardSprites.Length){
            for(int i = spawnedCards.Count; i < cards[TemporaryVariables.IndexInterpretation].CardSprites.Length; i++)
            {
                ElementInterpretation item = Instantiate(cardPrefab, parentElements);
                item.Icon.sprite = cards[TemporaryVariables.IndexInterpretation].CardSprites[i];
                item.ChildButton.ShowCardInformation(i, interpretation.ShowCardInformation);
                spawnedCards.Add(item);
            }
        }
        
        contentRect.anchoredPosition = new Vector2(contentRect.anchoredPosition.x, 0);
        contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, cards[TemporaryVariables.IndexInterpretation].CardSprites.Length * (cardPrefab.Icon.rectTransform.sizeDelta.y + 60) + 30);

        ShowDesiredItem();
        CheckLenghtSpawnedCards();
    }

    private void CheckLenghtSpawnedCards()
    {
        if(spawnedCards.Count > cards[TemporaryVariables.IndexInterpretation].CardSprites.Length)
        {
            for(int i = cards[TemporaryVariables.IndexInterpretation].CardSprites.Length; i < spawnedCards.Count; i++)
            {
                spawnedCards[i].gameObject.SetActive(false);
            }
        }
    }

    private void ShowDesiredItem()
    {
        for(int i = 0; i < cards[TemporaryVariables.IndexInterpretation].CardSprites.Length; i++)
        {
            spawnedCards[i].Icon.sprite = cards[TemporaryVariables.IndexInterpretation].CardSprites[i];
            spawnedCards[i].gameObject.SetActive(true);
        }
    }
}
