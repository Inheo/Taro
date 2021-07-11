using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private Card cardPrefab;
    [SerializeField] private Transform parent;

    [SerializeField] private Sprite[] deckBG;

    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < Game.Instance.CardsInformations[TemporaryVariables.IndexDeckForDivination].spriteCards.Length; i++)
        {
            Card card = Instantiate(cardPrefab, parent);
            card.IconCards.sprite = deckBG[TemporaryVariables.IndexDeckForDivination];
            card.Button.onClick.AddListener(Game.Instance.ChooseCard);
        }
    }
}
