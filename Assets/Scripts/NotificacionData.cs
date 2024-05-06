using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NotificationData", menuName = "Notifications/Notification Data", order = 1)]
public class NotificationData : ScriptableObject
{
    public string title;
    public string text;
    public int fireTime;
    public string smallIcon;
    public string largeIcon;
}

