﻿using HarmonyLib;
using BetterTownOfUs.Roles;
using UnityEngine;

namespace BetterTownOfUs.ImpostorRoles.UnderdogMod
{
    [HarmonyPatch(typeof(ExileController), nameof(ExileController.WrapUp))]
    public static class HUDClose
    {
        public static void Postfix()
        {
            var role = Role.GetRole(PlayerControl.LocalPlayer);
            if (role?.RoleType == RoleEnum.Underdog)
                ((Underdog)role).SetKillTimer();
        }
    }
}
