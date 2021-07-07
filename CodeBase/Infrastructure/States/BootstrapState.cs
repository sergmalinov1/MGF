using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.ServerConnection;
using CodeBase.Infrastructure.Services;
using CodeBase.StaticData;
using CodeBase.UI.Services.Factory;
using CodeBase.UI.Services.Windows;

namespace CodeBase.Infrastructure.States
{
  public class BootstrapState : IState
  {
    private const string Initial = "Initial";
    private const string LoginScene = "Login";
    
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly AllServices _services;

    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _services = services;

      RegisterServices();
    }

    public void Enter()
    {
      _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
    }

    public void Exit()
    {
      
    }
    
    private void EnterLoadLevel() => 
      _stateMachine.Enter<AuthorizationState, string>(LoginScene);

    private void RegisterServices()
    {
      
      RegisterStaticData();
      
      _services.RegisterSingle<IServerAPI>(new FirebaseAPI());
      _services.RegisterSingle<IAssetProvider>(new AssetProvider());
      
      _services.RegisterSingle<IUIFactory>(new UIFactory(
        _services.Single<IStaticDataService>(), 
        _services.Single<IAssetProvider>()));
      
      _services.RegisterSingle<IWindowService>(new WindowService(_services.Single<IUIFactory>()));

    }
    
    private void RegisterStaticData()
    {
      IStaticDataService staticData = new StaticDataService();
      staticData.Load();
      _services.RegisterSingle<IStaticDataService>(staticData);
    }
  }
}