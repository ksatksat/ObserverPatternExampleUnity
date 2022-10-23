using UnityEngine;

public class AchievementSystemWithEvents : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.DeleteAll();
        PointOfInterestWithEvents.OnPointOfInterestEntered +=
            PointOfInterestWithEvents_OnPointOfInterestEntered;
    }
    private void OnDestroy()
    {
        PointOfInterestWithEvents.OnPointOfInterestEntered -=
                    PointOfInterestWithEvents_OnPointOfInterestEntered;
    }
    private void PointOfInterestWithEvents_OnPointOfInterestEntered(
        PointOfInterestWithEvents poi)
    {
        string achievementKey = "achievementWithEvents-" + poi.PoiName;
        if (PlayerPrefs.GetInt(achievementKey) == 1)
        {
            return;
        }
        PlayerPrefs.SetInt(achievementKey, 1);
        Debug.Log("Unlocked " + poi.PoiName);
    }
}
