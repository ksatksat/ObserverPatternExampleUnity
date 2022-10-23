using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is observer dedsign pattern.
/// It saves to player prefs int variable with key and value.
/// Key is a name of object that player touched, and value is a
/// number between 0 and 1. Where 1 is a signal that this object
/// was unlocked and player can't unlock it again, player done
/// with this object.
/// </summary>

public abstract class Observer : MonoBehaviour
{
    public abstract void OnNotify(object value, NotificationType notificationType);
}
/// <summary>
/// This is observer dedsign pattern.
/// It saves to player prefs int variable with key and value.
/// Key is a name of object that player touched, and value is a
/// number between 0 and 1. Where 1 is a signal that this object
/// was unlocked and player can't unlock it again, player done
/// with this object.
/// </summary>
public abstract class Subject : MonoBehaviour
{
    //?????? ?????????????? ??????? Observer
    private List<Observer> _observers = new List<Observer>();
    public void RegisterObserver(Observer observer)//observer is AchievementSystem 
    {
        _observers.Add(observer);//AchievementSystem is inside _observers
    }
    public void Notify(object value, NotificationType notificationType)
    {
        foreach (var observer in _observers)
        {
            observer.OnNotify(value, notificationType);
        }
    }
}
