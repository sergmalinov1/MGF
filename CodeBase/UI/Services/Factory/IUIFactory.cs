using System;
using CodeBase.Infrastructure.Services;

namespace CodeBase.UI.Services.Factory
{
  public interface IUIFactory : IService
  {
    void CreateUIRoot();
    void CreateLogin(Action onLoaded = null);
  }
}