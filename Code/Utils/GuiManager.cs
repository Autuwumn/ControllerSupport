using ControllerSupport.Utils;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnboundLib;
using UnboundLib.Utils.UI;
using System.Collections;
using UnboundLib.GameModes;
using System.ComponentModel.Design;
using System.Collections.Generic;
using Jotunn.Utils;
using Jotunn;

namespace ControllerSupport.Utils
{
    public class GuiManager : MonoBehaviour
    {
        private static List<ControllerGui> menus = new List<ControllerGui>();
        public static void OpenGuis()
        {
            foreach(ControllerGui gui in menus)
            {

            }
        }
        public static void CloseGuis()
        {

        }
        public static void AddGui(string title, string[] options, MonoBehaviour[] actions)
        {
            ControllerGui gui = new ControllerGui()
            {
                title = title,
                options = options,
                actions = actions
            };
            menus.Add(gui);
        }
    }

    public class ControllerGui : MonoBehaviour
    {
        public string title;
        public string[] options;
        public MonoBehaviour[] actions;
    }
}