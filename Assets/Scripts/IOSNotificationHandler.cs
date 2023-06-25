using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_IOS
using Unity.Notifications.iOS;
#endif

public class IOSNotificationHandler : MonoBehaviour
{
#if UNITY_IOS
    public void ScheduleNotification(int minutes)
    {
        iOSNotification notification = new iOSNotification
        {
            Title = "Energy Recharged!",
            Subtitle = " Your energy has been recharged",
            Body = "Your energy is fully recharged! Come back and play again!",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Sound | PresentationOption.Alert),
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = new iOSNotificationTimeIntervalTrigger()
            {
                TimeInterval = new System.TimeSpan(0, minutes, 0),
                Repeats = false
            }
        };

        iOSNotificationCenter.ScheduleNotification(notification);

    }

#endif
}
