﻿using Leopotam.Ecs.Ui.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Leopotam.Ecs.Ui.Systems
{
    internal class ChangeBotSystem : IEcsRunSystem
    {
        EcsFilter<ChangeBotComponent> _change = null;
        EcsFilter<CurrentBotComponent> _bot = null;
        EcsFilter<BotStatisticsComponent> _botStatistics = null;

        public void Run()
        {
            foreach(var i in _change)
            {
                var changeEnt = _change.GetEntity(i);
                var target = changeEnt.Get<ChangeBotComponent>().Target;
                foreach (var b in _bot)
                    _bot.Get1(b).BotDif = target;
                string all = "";
                foreach (var stat in _botStatistics)
                {
                    ref var curStatView = ref _botStatistics.Get1(stat);
                    all += curStatView.StatisticsName + " ";
                    if (curStatView.StatisticsName == target.ToString())
                        curStatView.StatView.Select();
                    else
                        curStatView.StatView.Unselect();
                }

                changeEnt.Del<ChangeBotComponent>();
            }
        }
    }
}