using UnityEngine;

public class AchievementSystem : Observer
{
    private void Start()
    {
        PlayerPrefs.DeleteAll();
        //this could also be done when the pois are created in some poi spawner/manager class
        foreach (var poi in FindObjectsOfType<PointOfInterest>())
        {
            poi.RegisterObserver(this);//this - is AchievementSystem
        }
    }
    //object value is string PoiName
    public override void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.AchievementUnlocked)
        {
            //value can be "Capsule" or "Cube" or "Sphere"
            string achievementKey = "achievement-" + value;
            //achievementKey is for example "achievement-Capsule" or "achievement-Cube"
            if (PlayerPrefs.GetInt(achievementKey) == 1)
            {
                return;
            }
            //this prevents to call the same PoiName again
            PlayerPrefs.SetInt(achievementKey, 1);
            Debug.Log("Unlocked " + value);
            //send some stuff off to steam
        }
    }
}
public enum NotificationType
{
    AchievementUnlocked
}
