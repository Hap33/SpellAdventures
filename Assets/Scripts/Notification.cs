using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.SimpleAndroidNotifications
{
    public class Notification : MonoBehaviour
    {

        public string notifTitre = "Titre de notif";
        public string notifTexte = "Texte de la notification";

        public void SendNotif()
        {
            NotificationManager.Send(TimeSpan.FromSeconds(5), notifTitre, notifTexte, Color.white);
        }
    }
}
