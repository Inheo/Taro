using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour
{
    private string gameId = "4168312";

    void Awake()
    {
        Advertisement.Initialize(gameId, false);
    }
}

