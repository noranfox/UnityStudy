using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class BennerAdmop : MonoBehaviour
{
    private BannerView bannerView;
    void Start()
    {
        MobileAds.Initialize(initstatus => { });
        this.RequestBanner();
    }

    private void RequestBanner()
    {
        #if UNITY_ANDROID
                string adUnitID = "ca-app-pub-7691806039606845/9839032582";
        #elif UNITY_IPHONE
        #else
                string adUnitId = "unexpected_playform";
        #endif
                if(this.bannerView != null)
                {
                    bannerView.Destroy();
                }

                AdSize adaptiveSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
                this.bannerView = new BannerView(adUnitID, adaptiveSize, AdPosition.Bottom);
                AdRequest request = new AdRequest.Builder().Build();

                this.bannerView.LoadAd(request);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
