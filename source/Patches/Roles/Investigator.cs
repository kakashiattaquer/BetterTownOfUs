using System.Collections.Generic;
using BetterTownOfUs.CrewmateRoles.InvestigatorMod;
using UnityEngine;

namespace BetterTownOfUs.Roles
{
    public class Investigator : Role
    {
        public readonly List<Footprint> AllPrints = new List<Footprint>();


        public Investigator(PlayerControl player) : base(player)
        {
            Name = "Investigator";
            ImpostorText = () => "Find all impostors by examining footprints";
            TaskText = () => "You can see everyone's footprints.";
            Color = Patches.Colors.Investigator;
            RoleType = RoleEnum.Investigator;
            AddToRoleHistory(RoleType);
            Scale = 1.4f;
        }
    }
}