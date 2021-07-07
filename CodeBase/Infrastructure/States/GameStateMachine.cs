using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using CodeBase.Logic;
using CodeBase.UI.Services.Factory;
using CodeBase.UI.Services.Windows;

namespace CodeBase.Infrastructure.States
{
  public class GameStateMachine
  {
    private readonly Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;

    public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain curtain, AllServices services)
    {
      _states = new Dictionary<Type, IExitableState>
      {
        [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
        [typeof(AuthorizationState)] = new AuthorizationState(this, sceneLoader,
          services.Single<IUIFactory>()),
        [typeof(LoadProgressState)] = new LoadProgressState(this, sceneLoader)
      };
    }
    
    public void Enter<TState>() where TState : class, IState
    {
      IState state = ChangeState<TState>();
      state.Enter();
    }

    public void Enter<TState, TPayLoad>(TPayLoad payload) where TState : class, IPayloadedState<TPayLoad>
    {
      IPayloadedState<TPayLoad> state = ChangeState<TState>();
      state.Enter(payload);
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
      _activeState?.Exit();

      TState state = GetState<TState>();
      _activeState = state;

      return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState => 
      _states[typeof(TState)] as TState;
  }
}