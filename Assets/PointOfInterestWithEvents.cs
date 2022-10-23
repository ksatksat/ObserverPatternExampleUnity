using UnityEngine;
using System;

public class PointOfInterestWithEvents : MonoBehaviour
{
    //Action is a default delegate that returns void, in this case it takes <genericType>
    public static event Action<PointOfInterestWithEvents> OnPointOfInterestEntered;
    [SerializeField]
    private string poiName;
    public string PoiName { get { return poiName; } }
    private void OnTriggerEnter(Collider other)
    {
        if (OnPointOfInterestEntered != null)
        {
            OnPointOfInterestEntered(this);
        }
    }
}
