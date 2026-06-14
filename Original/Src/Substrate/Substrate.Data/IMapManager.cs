namespace Substrate.Data;

public interface IMapManager
{
	Map GetMap(int id);

	void SetMap(int id, Map map);

	bool MapExists(int id);

	void DeleteMap(int id);
}
