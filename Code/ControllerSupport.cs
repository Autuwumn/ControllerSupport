using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnboundLib;
using UnboundLib.GameModes;
using UnboundLib.Utils;
using UnboundLib.Utils.UI;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using Photon.Pun.Demo.Procedural;
using ControllerSupport;
using ControllerSupport.Utils;

namespace ControllerSupport
{
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin(ModId, ModName, Version)]
    [BepInProcess("Rounds.exe")]

    public class ControllerSupport : BaseUnityPlugin
    {
        public const string ModInitials = "CS";
        private const string ModId = "koala.controller.support";
        private const string ModName = "Controller Support";
        public const string Version = "1.0.3";
        
        public static ControllerSupport instance { get; private set; }
        private GameObject move;
        public void Awake()
        {
            instance = this;
            Unbound.RegisterClientSideMod(ModId);
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        private void SetupSupport()
        {
            if(!move)
            {
                move = new GameObject();
                move.name = "MoveBitch";
                move.AddComponent<MoveBitchGetOutTheWay>();
            }
        }
        public void Start()
        {
            SetupSupport();
        }

        public IEnumerator GameStart(IGameModeHandler gameModeHandler)
        {
            SetupSupport();
            yield break;
        }
    }
}