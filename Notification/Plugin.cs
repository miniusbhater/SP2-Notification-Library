using Assets.Scripts.Flight.Demo;
using Assets.Scripts.UI;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Rewired;
using Steamworks;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using System.Collections;



namespace Notification
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        private NotificationUI ui;
        void Awake()
        {
            Notification.Plugin = this;
            ui = NotificationUI.Create();
            NotificationQueue.Flush(this);
        }

        void Start()
        {
            NotificationSendStartOrSomethingLikeThat.SendNotif();
            CheckForUpdates.CheckForUpdate();
        }
      

        void Update()
        {
         
        }

        void OnGUI()
        {
            
        }

        public void ShowNoti(string message, string sender, float duration)
        {
            NotificationElement elem = NotificationElement.Create(ui.Container, message, sender);
            StartCoroutine(Destroy(elem.Root, duration));
        }

        private IEnumerator Destroy(GameObject obj, float wait)
        {
            yield return new WaitForSeconds(wait);
            Destroy(obj);
        }


    }
}



    

