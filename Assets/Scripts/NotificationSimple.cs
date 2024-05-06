using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif

public class NotificationSimple : MonoBehaviour
{

    private static NotificationSimple _instance;
    public static NotificationSimple Instance { get { return _instance; } }
    private const string idCanal = "canalNotificacion";

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
#if UNITY_ANDROID
        RequestAuhtorization();
        RegisterNotificationChannel();
#endif
        
    }

#if UNITY_ANDROID
    //Request authorization to send notifications
    public void RequestAuhtorization()
    {
        if(!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }

    //Register a Notification Channel
    public void RegisterNotificationChannel()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel
        {
            Id = "default_channel",
            Name = "Default",
            Importance = Importance.Default,
            Description = "Notifications"
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    //Set Up Notification Template
    public void SendNotification(NotificationData notificacionScore)
    {
        AndroidNotification notification = new AndroidNotification();
        notification.Title = notificacionScore.title;
        notification.Text = notificacionScore.text;
        notification.FireTime = DateTime.Now.AddHours(notificacionScore.fireTime);
        notification.SmallIcon = notificacionScore.smallIcon;
        notification.LargeIcon = notificacionScore.largeIcon;

        AndroidNotificationCenter.SendNotification(notification, "default_channel");
    }
#endif
}
