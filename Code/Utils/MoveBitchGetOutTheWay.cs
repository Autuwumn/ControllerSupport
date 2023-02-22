using ControllerSupport.Utils;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnboundLib;
using UnboundLib.Utils.UI;
using System.Collections;
using UnboundLib.GameModes;

namespace ControllerSupport.Utils
{
    internal class MoveBitchGetOutTheWay : MonoBehaviour
    {
        private Player player;
        private bool moveCursor = true;
        private bool guiOpen = false;
        private bool dpadBlocked = false;

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePosition lpMousePosition);

        public int xdmp;
        public int ydmp;
        [StructLayout(LayoutKind.Sequential)]
        public struct MousePosition
        {
            public int x;
            public int y;
        }
        private Player getLocalPlayer()
        {
            Player player = null;
            PlayerManager.instance.players.ForEach(p => { if (p.data.view.IsMine && !ModdingUtils.AIMinion.Extensions.CharacterDataExtension.GetAdditionalData(p.data).isAIMinion) player = p; });
            return player;
        }
        public void Update()
        {
            player = getLocalPlayer();
            if (player)
            {
                if (player.data.input.inputType == GeneralInput.InputType.Controller)
                {
                    xdmp = 0;
                    ydmp = 0;
                    xdmp = (int)(10 * player.data.input.aimDirection.x);
                    ydmp = (int)(-10 * player.data.input.aimDirection.y);
                    MousePosition mp;
                    GetCursorPos(out mp);
                    if (Input.GetKeyDown(KeyCode.JoystickButton3)) if (moveCursor) moveCursor = false; else moveCursor = true;
                    if (moveCursor) SetCursorPos(mp.x + xdmp, mp.y + ydmp);
                    if (Input.GetKeyDown(KeyCode.JoystickButton2))
                    {
                        MouseManager.MouseEvent(MouseManager.MouseEventFlags.LeftDown);
                        ControllerSupport.instance.ExecuteAfterFrames(5, () =>
                        {
                            MouseManager.MouseEvent(MouseManager.MouseEventFlags.LeftUp);
                        });
                    }
                    /**
                    if (player.isActiveAndEnabled)
                    {
                        if (Input.GetAxis("DPadVertical") == 1 && !dpadBlocked)
                        {
                            dpadBlocked = true;
                            if (!guiOpen)
                            {
                                GuiManager.OpenGuis();
                                guiOpen = true;
                            }
                            else
                            {
                                GuiManager.CloseGuis();
                                guiOpen = false;
                            }
                        }
                        else if (Input.GetAxis("DPadVertical") == 0 && dpadBlocked)
                        {
                            dpadBlocked = false;
                        }
                    }
                    if (player.data.health <= 0)
                    {
                        GuiManager.CloseGuis();
                        guiOpen = false;
                    }
                    **/
                }
            }
        }
    }
}