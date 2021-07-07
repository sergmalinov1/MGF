using CodeBase.UI.Services.Factory;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
  public class AuthorizationState : IPayloadedState<string>
  {
    private const string GameMenuScene = "Game Menu";
    
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private IWindowService _windowService;
    private readonly IUIFactory _uiFactory;

    public AuthorizationState(GameStateMachine stateMachine,SceneLoader sceneLoader, IUIFactory uiFactory)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _uiFactory = uiFactory;
    }

    public void Enter(string sceneName)
    {
      _sceneLoader.Load(sceneName, OnLoaded);
    }

    private void OnLoaded()
    {
      _uiFactory.CreateUIRoot();
      _uiFactory.CreateLogin(onLoaded: EnterLoadLevel);

    }

    public void Exit()
    {
      
    }

    private void EnterLoadLevel()
    {
      _stateMachine.Enter<LoadProgressState, string>(GameMenuScene);
    }
  }
}