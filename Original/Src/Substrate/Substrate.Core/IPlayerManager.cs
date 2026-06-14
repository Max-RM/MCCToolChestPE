namespace Substrate.Core;

public interface IPlayerManager
{
	Player GetPlayer(string name);

	void SetPlayer(string name, Player player);

	bool PlayerExists(string name);

	void DeletePlayer(string name);
}
