using UnityEngine;
using UnityEngine.UI;

public class ElementInterpretation : MonoBehaviour
{
    [SerializeField] private Button childButton;
    [SerializeField] private Image icon;


    public Button ChildButton => childButton;
    public Image Icon => icon;
}
