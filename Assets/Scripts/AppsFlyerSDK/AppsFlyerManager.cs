using UnityEngine;
using System.Collections;
using AppsFlyerSDK;

public class AppsFlyerManager : MonoBehaviour
{
    [SerializeField] private string devKey;
    [SerializeField] private string appId;
    void Start()
    {
        DontDestroyOnLoad(this);
        Init();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Пример отправки события
            AppsFlyer.sendEvent("sample_event", null);
        }
    }
    
    private void Init()
    {
        AppsFlyer.initSDK(devKey,appId);
    }
}
