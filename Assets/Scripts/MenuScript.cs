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
        public string notifTexte = "Ne nous oubliez pas !";
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
