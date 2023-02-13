﻿using Infrastructure.DI;
using Infrastructure.DI.Services.AssetsManagment;
using Infrastructure.DI.Services.Factory;
using Infrastructure.DI.Services.Input;
using Infrastructure.States.Interfaces;
using UnityEngine;

namespace Infrastructure.States
{
    /**
     * Класс, описывающий состояние начальной загрузки/инициализации необходимых компонентов игры.
     */
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly DiContainer _container;

        public BootstrapState(GameStateMachine stateMachine, DiContainer container)
        {
            _stateMachine = stateMachine;
            _container = container;
            
            BindServices();
        }

        public void Enter()
        {
            Debug.Log("BootstrapState entered.");
            _stateMachine.Enter<LoadLevelState>();
        }

        public void Exit()
        {
            Debug.Log("BootstrapState exited.");
        }

        private void BindServices()
        {
            Debug.Log("Binding services.");
            
            _container.Bind<IInputService>(new InputService());
            
            IAssetProvider assetsProvider = new AssetsProvider();
            _container.Bind(assetsProvider);
            
            _container.Bind<IGameFactory>(new GameFactory(assetsProvider));
        }
    }
}