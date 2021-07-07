using CodeBase.Infrastructure.Services;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;

namespace CodeBase.StaticData
{
  public interface IStaticDataService : IService
  {

    void Load();
    WindowConfig ForWindow(WindowId windowId);
  }
}