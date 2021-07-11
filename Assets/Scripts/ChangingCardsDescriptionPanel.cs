using UnityEngine;
using UnityEngine.UI;

public class ChangingCardsDescriptionPanel : MonoBehaviour
{
    [System.Serializable]
    private struct InformationForChangePanel
    {
        public string Title;
        public string Name;
        public Sprite Description;
        public Sprite Sign;
    }

    [SerializeField] private InformationForChangePanel[] informationForChangePanel;

    [SerializeField] private Text titleCard;
    [SerializeField] private Text nameCard;

    [SerializeField] private RectTransform contentRect;
    [SerializeField] private Image descriptionImage;
    [SerializeField] private Image signImage;

    private void OnEnable(){
        Change();
    }

    private void Change()
    {
        signImage.sprite = informationForChangePanel[TemporaryVariables.IndexDescription].Sign;
        
        descriptionImage.sprite = informationForChangePanel[TemporaryVariables.IndexDescription].Description;
        descriptionImage.SetNativeSize();
        
        titleCard.text = informationForChangePanel[TemporaryVariables.IndexDescription].Title;
        nameCard.text = informationForChangePanel[TemporaryVariables.IndexDescription].Name;

        contentRect.anchoredPosition = new Vector2(contentRect.anchoredPosition.x, 0);

        contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, descriptionImage.rectTransform.sizeDelta.y + 50);
    }
}
