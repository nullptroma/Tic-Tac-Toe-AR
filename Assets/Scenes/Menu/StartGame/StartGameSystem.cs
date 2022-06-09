﻿using Leopotam.Ecs;
using Leopotam.Ecs.Common.SceneNavigate;
using Leopotam.Ecs.Game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Leopotam.Ecs.Game.Systems
{
    internal class StartGameSystem : IEcsRunSystem
    {
        EcsWorld _world = null;
        EcsFilter<StartGameComponent> _start = null;
        EcsFilter<GameConf> _conf = null;

        public void Run()
        {
            if (_start.GetEntitiesCount() == 0)
                return;
            var startInfo = _start.Get1(0);
            foreach (var i in _start)//Удаление всех событий для старта
                _start.GetEntity(i).Del<StartGameComponent>();
            var confEnt = _conf.GetEntity(0);
            Bridge.PlayMode = confEnt.Get<PlayModeComponent>().Mode;
            Bridge.BotDifficulty = confEnt.Get<CurrentBotComponent>().BotDif;
            Bridge.Marker = startInfo.Marker;
            _world.SendMessage(new NavigateToSceneComponent("Game"));
        }
    }
}
