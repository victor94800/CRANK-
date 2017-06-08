﻿// --------------------------------------
//  Unity Foundation
//  ConsoleGUI.cs
//  copyright (c) 2014 Nicholas Ventimiglia, http://avariceonline.com
//  All rights reserved.
//  -------------------------------------
// 
using System;
using System.Linq;
using UnityEngine;

namespace GUIConsole
{
    /// <summary>
    /// renders the ConsoleContext using OnGUI
    /// </summary>
    [AddComponentMenu("Avarice/Console/ConsoleGUI")]
    public class ConsoleGUI : MonoBehaviour
    {
        /// <summary>
        /// skin to use
        /// </summary>
        public GUISkin MySkin;

        /// <summary>
        /// Items
        /// </summary>
        public bool ReverseSort = true;

        public float MarginTop = 32;
        public float MarginBottom = 32;
        public float MarginLeft = 32;
        public float MarginRight = 32;

        public float Padding = 4;

        public float CommandWidth = 180;
        
        // submit
        string _inputValue = string.Empty;
        // items
        Vector2 _scrollItems = Vector2.zero;
        // command menu
        Vector2 _scrollCmdMenu = Vector2.zero;
        //items
        ConsoleItem[] _items;

        public bool IsVisible = true;
        public KeyCode VisiblityKey = KeyCode.BackQuote;

        void Awake()
        {
            Update();
            Application.RegisterLogCallback(Handler);

        }

        private void Handler(string condition, string stackTrace, LogType type)
        {
            switch (type)
            {
                    case LogType.Error:
                    case LogType.Exception:
                    ConsoleContext.Instance.LogError(condition);
                    break;
                    case LogType.Warning:
                    ConsoleContext.Instance.LogWarning(condition);
                    break;
                    case LogType.Log:
                    case LogType.Assert:
                    ConsoleContext.Instance.LogOutput(condition);
                    break;
            }
        }

        void Update()
        {
            _items = ReverseSort
                            ? ConsoleContext.Instance.Items.AsEnumerable().Reverse().ToArray()
                            : ConsoleContext.Instance.Items.ToArray();

            if (Input.GetKeyUp(VisiblityKey))
            {
                IsVisible = !IsVisible;
            }

        }

        void OnGUI()
        {
            if (!IsVisible)
                return;

            GUI.skin = MySkin;

            GUILayout.BeginHorizontal();
            GUILayout.Space(MarginLeft);

            // left side
            GUILayout.BeginVertical(
                GUILayout.MaxWidth(100 - (MarginRight + CommandWidth + Padding)),
                GUILayout.MaxHeight(100 - (MarginTop +  Padding))
                );
            GUILayout.Space(MarginTop);

            // top menu
            GUILayout.BeginHorizontal();


            if (Event.current.keyCode == KeyCode.Return)
            {
                DoSend();
            }
            else
            {
                _inputValue = GUILayout.TextField(_inputValue, GUILayout.Width(256));
            }

            if (GUILayout.Button("Send"))
            {
                DoSend();
            }

            if (GUILayout.Button("Clear"))
            {
                DoClear();
            }


            GUILayout.EndHorizontal();
            GUILayout.Space(Padding);

            // end menu

            _scrollItems = GUILayout.BeginScrollView(_scrollItems,
                false,
                true,
                GUILayout.ExpandHeight(true),
                GUILayout.ExpandWidth(true));


            foreach (var item in _items)
            {
                GUI.color = item.Color;
                GUILayout.Label(item.Formatted, GUILayout.ExpandHeight(false));
            }

            GUI.color = GUI.contentColor;

            GUILayout.EndScrollView();

            GUILayout.EndVertical();
            GUILayout.Space(Padding);
            //end left side

            // menu
            GUILayout.BeginVertical(
                GUILayout.Width(CommandWidth + MarginRight));
            GUILayout.Space(MarginTop);

            GUILayout.BeginHorizontal(
                GUILayout.MaxHeight(100 - (MarginTop + MarginBottom)),
                GUILayout.Width(CommandWidth+ MarginRight));
          
            _scrollCmdMenu = GUILayout.BeginScrollView(_scrollCmdMenu,
                false,
                true,
                GUILayout.MaxWidth(CommandWidth),
                GUILayout.ExpandHeight(true));

            foreach (var item in ConsoleContext.Instance.Commands)
            {
                if (GUILayout.Button(item.Label))
                {
                    item.Method.Invoke();
                }
            }

            GUILayout.EndScrollView();
            GUILayout.Space(MarginRight);
            GUILayout.EndHorizontal();
            GUILayout.Space(MarginBottom);
            GUILayout.EndVertical();

            //end menu

            GUILayout.EndHorizontal();
        }

        public void DoSend()
        {
            _inputValue = _inputValue.Replace(Environment.NewLine, "");

            if (string.IsNullOrEmpty(_inputValue))
                return;

            ConsoleContext.Instance.Submit(_inputValue);

            _inputValue = string.Empty;
        }

        public void DoClear()
        {
            ConsoleContext.Instance.Clear();
        }
    }
}