using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif

public class AndroidNotificationHandler : MonoBehaviour
{
#if UNITY_ANDROID
    private const string CHANNEL_ID = "notification_chanel";

    public void ScheduleNotification(DateTime dateTime)
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel
        {
            Id = CHANNEL_ID,
            Name = "Notification Channel",
            Description = "None",
            Importance = Importance.Default
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        AndroidNotification notification = new AndroidNotification 
        { 
            Title = "Energy Recharged!",
            Text = "Your energy is fully recharged! Come back and play again!",
            SmallIcon = "default",
            LargeIcon= "default",
            FireTime = dateTime
        };

        AndroidNotificationCenter.SendNotification(notification, CHANNEL_ID);

    }
#endif
}
