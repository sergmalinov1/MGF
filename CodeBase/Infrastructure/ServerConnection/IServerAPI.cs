using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.ServerConnection
{
  public interface IServerAPI : IService
  {
    void Connect();
    void Send();
    void Receive();

  }
}