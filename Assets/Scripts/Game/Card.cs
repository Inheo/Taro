using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Image iconCards;
    [SerializeField] private Button button;

    public Image IconCards => iconCards;
    public Button Button => button;
}
