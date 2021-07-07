using System;
using UnityEngine.UI;

namespace CodeBase.UI.Windows.Login
{
  public class LoginWindow : BaseWindow
  {
    public Button LoginButton;
    
    private Action _onLoaded;
    

    public void Construct(Action onLoaded = null)
    {
      _onLoaded = onLoaded;
    }

    protected override void Initialize()
    {
      LoginButton.onClick.AddListener(OnLoginClicked);
    }


    private void OnLoginClicked()
    {
      _onLoaded?.Invoke();
    }
  }
}