﻿using Leopotam.Ecs.Menu.Components;
using Leopotam.Ecs.Menu.UI.Components;
using UnityEngine;

namespace Leopotam.Ecs.Menu.UI.Systems
{
    internal class ChangeBotSystem : IEcsRunSystem
    {
        EcsFilter<ChangeBotComponent> _change = null;
        EcsFilter<GameConfComponent> _conf = null;
        EcsFilter<BotStatisticsComponent> _botStatistics = null;

        public void Run()
        {
            if (_botStatistics.GetEntitiesCount() == 0)
                return;
            foreach(var i in _change)
            {
                var changeEnt = _change.GetEntity(i);
                var target = changeEnt.Get<ChangeBotComponent>().Target;
                foreach (var b in _conf)
                    _conf.Get1(b).Bot = target;
                foreach (var stat in _botStatistics)
                {
                    ref var curStatView = ref _botStatistics.Get1(stat);
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
