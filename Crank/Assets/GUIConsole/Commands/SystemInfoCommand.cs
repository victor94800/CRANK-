﻿// --------------------------------------
//  Unity Foundation
//  SystemInfoCommand.cs
//  copyright (c) 2014 Nicholas Ventimiglia, http://avariceonline.com
//  All rights reserved.
//  -------------------------------------
// 
using System.Text;
using UnityEngine;

namespace GUIConsole
{


    /// <summary>
    /// Extends the console with 'about me' command
    /// </summary>
    [AddComponentMenu("GUIConsole/SystemInfoCommand")]
    public class SystemInfoCommand : MonoBehaviour
    {
        private void Awake()
        {
            ConsoleContext.Instance.Commands.Add(
                new ConsoleCommand
                {
                    Label = "SystemInfo",
                    Method = () => DoSystemInfo()
                });
        }

        private void DoSystemInfo()
        {

            var info = new StringBuilder();

            info.AppendFormat("Unity Ver: {0}\n", Application.unityVersion);
            info.AppendFormat("Platform: {0} Language: {1}\n", Application.platform, Application.systemLanguage);
            info.AppendFormat("Screen:({0},{1}) DPI:{2} Target:{3}fps\n", 100, 100, 100, Application.targetFrameRate);
            info.AppendFormat("LevelContext: {0} ({1} of {2})\n", Application.loadedLevelName, Application.loadedLevel, Application.levelCount);
            info.AppendFormat("Quality: {0}\n", QualitySettings.names[QualitySettings.GetQualityLevel()]);
            info.AppendLine();
            info.AppendFormat("Data Path: {0}\n", Application.dataPath);
            info.AppendFormat("Cache Path: {0}\n", Application.temporaryCachePath);
            info.AppendFormat("Persistent Path: {0}\n", Application.persistentDataPath);
            info.AppendFormat("Streaming Path: {0}\n", Application.streamingAssetsPath);
#if UNITY_WEBPLAYER
    info.AppendLine();
    info.AppendFormat("URL: {0}\n", Application.absoluteURL);
    info.AppendFormat("srcValue: {0}\n", Application.srcValue);
    info.AppendFormat("security URL: {0}\n", Application.webSecurityHostUrl);
#endif
#if MOBILE
    info.AppendLine();
    info.AppendFormat("Net Reachability: {0}\n", Application.internetReachability);
    info.AppendFormat("Multitouch: {0}\n", Input.multiTouchEnabled);
#endif
#if UNITY_EDITOR
            info.AppendLine();
            info.AppendFormat("editorApp: {0}\n", UnityEditor.EditorApplication.applicationPath);
            info.AppendFormat("editorAppContents: {0}\n", UnityEditor.EditorApplication.applicationContentsPath);
            info.AppendFormat("scene: {0}\n", UnityEditor.EditorApplication.currentScene);
#endif
            info.AppendLine();
            var devices = WebCamTexture.devices;
            if (devices.Length > 0)
            {
                info.AppendLine("Cameras: ");

                foreach (var device in devices)
                {
                    info.AppendFormat("  {0} front:{1}\n", device.name, device.isFrontFacing);
                }
            }

            ConsoleContext.Instance.LogOutput(info.ToString());
        }
    }
}