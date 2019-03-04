using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace Assets.SimpleAndroidNotifications
{
    public class MenuScript : MonoBehaviour
    {

        public string notifTitre = "Spell Adventure";
        public string notifTexte = "Une Nouvelle carte vous attends!";
        public NotificationIcon notifIcon;

        public void PlayGame()
        {
            SceneManager.LoadScene(1);
        }

        public void QuitGame()
        {
            NotificationManager.Send(TimeSpan.FromSeconds(5), notifTitre, notifTexte, Color.black, NotificationIcon.Star);
            Application.Quit();
        }
    }
}
