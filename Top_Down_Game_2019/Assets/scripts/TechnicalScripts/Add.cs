using UnityEngine;
using GoogleMobileAds.Api;

public class Add : MonoBehaviour
{
    private void Awake()
    {
        MobileAds.Initialize(initStatus => { });
    }
}
