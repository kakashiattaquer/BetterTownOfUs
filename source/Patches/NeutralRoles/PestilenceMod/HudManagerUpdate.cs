using System.Linq;
using HarmonyLib;
using BetterTownOfUs.Roles;
using UnityEngine;
using Hazel;

namespace BetterTownOfUs.NeutralRoles.PestilenceMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public static class HudManagerUpdate
    {
        public static void Postfix(HudManager __instance)
        {
            if (PlayerControl.AllPlayerControls.Count <= 1) return;
            if (PlayerControl.LocalPlayer == null) return;
            if (PlayerControl.LocalPlayer.Data == null) return;
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Pestilence)) return;
            var role = Role.GetRole<Pestilence>(PlayerControl.LocalPlayer);

            __instance.KillButton.gameObject.SetActive(!PlayerControl.LocalPlayer.Data.IsDead && !MeetingHud.Instance);

            __instance.KillButton.SetCoolDown(role.KillTimer(), CustomGameOptions.PestKillCd);

            Utils.SetTarget(ref role.ClosestPlayer, __instance.KillButton);
        }
    }
}