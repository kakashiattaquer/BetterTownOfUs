﻿using HarmonyLib;
using Reactor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterTownOfUs.Roles;

namespace BetterTownOfUs.Patches
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.SetTasks))]
    class SetTasks
    {
        public static void Postfix(PlayerControl __instance)
        {
            var role = Role.GetRole(__instance);
            if (role != null && role.Faction != Faction.Crewmates && role.RoleType != RoleEnum.Phantom) return;

            var taskinfos = __instance.Data.Tasks.ToArray();
            var tasksLeft = taskinfos.Count(x => !x.Complete);
            var totalTasks = taskinfos.Count();
        }
    }
}
