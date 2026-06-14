using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate;

public class PlayerManager : IPlayerManager, IEnumerable<Player>, IEnumerable
{
	private class Enumerator : IEnumerator<Player>, IDisposable, IEnumerator
	{
		protected PlayerManager _pm;

		protected Queue<string> _names;

		protected Player _curPlayer;

		protected static Regex _namePattern = new Regex(".+\\.dat$");

		object IEnumerator.Current => Current;

		Player IEnumerator<Player>.Current => Current;

		public Player Current
		{
			get
			{
				if (_curPlayer == null)
				{
					throw new InvalidOperationException();
				}
				return _curPlayer;
			}
		}

		public Enumerator(PlayerManager cfm)
		{
			_pm = cfm;
			_names = new Queue<string>();
			if (!Directory.Exists(_pm._playerPath))
			{
				throw new DirectoryNotFoundException();
			}
			Reset();
		}

		public bool MoveNext()
		{
			if (_names.Count == 0)
			{
				return false;
			}
			string name = _names.Dequeue();
			_curPlayer = _pm.GetPlayer(name);
			_curPlayer.Name = name;
			return true;
		}

		public void Reset()
		{
			_names.Clear();
			_curPlayer = null;
			string[] files = Directory.GetFiles(_pm._playerPath);
			string[] array = files;
			foreach (string path in array)
			{
				string fileName = Path.GetFileName(path);
				if (ParseFileName(fileName))
				{
					_names.Enqueue(PlayerFile.NameFromFilename(fileName));
				}
			}
		}

		void IDisposable.Dispose()
		{
		}

		private bool ParseFileName(string filename)
		{
			Match match = _namePattern.Match(filename);
			if (!match.Success)
			{
				return false;
			}
			return true;
		}
	}

	private string _playerPath;

	public PlayerManager(string playerDir)
	{
		_playerPath = playerDir;
	}

	protected PlayerFile GetPlayerFile(string name)
	{
		return new PlayerFile(_playerPath, name);
	}

	public NbtTree GetPlayerTree(string name)
	{
		PlayerFile playerFile = GetPlayerFile(name);
		Stream dataInputStream = playerFile.GetDataInputStream();
		if (dataInputStream == null)
		{
			throw new NbtIOException("Failed to initialize NBT data stream for input.");
		}
		return new NbtTree(dataInputStream);
	}

	public void SetPlayerTree(string name, NbtTree tree)
	{
		PlayerFile playerFile = GetPlayerFile(name);
		Stream dataOutputStream = playerFile.GetDataOutputStream();
		if (dataOutputStream == null)
		{
			throw new NbtIOException("Failed to initialize NBT data stream for output.");
		}
		tree.WriteTo(dataOutputStream);
		dataOutputStream.Close();
	}

	public Player GetPlayer(string name)
	{
		if (!PlayerExists(name))
		{
			return null;
		}
		try
		{
			Player player = new Player().LoadTreeSafe(GetPlayerTree(name).Root);
			player.Name = name;
			return player;
		}
		catch (Exception innerException)
		{
			PlayerIOException ex = new PlayerIOException("Could not load player", innerException);
			ex.Data["PlayerName"] = name;
			throw ex;
		}
	}

	public void SetPlayer(string name, Player player)
	{
		try
		{
			SetPlayerTree(name, new NbtTree(player.BuildTree() as TagNodeCompound));
		}
		catch (Exception innerException)
		{
			PlayerIOException ex = new PlayerIOException("Could not save player", innerException);
			ex.Data["PlayerName"] = name;
			throw ex;
		}
	}

	public void SetPlayer(Player player)
	{
		SetPlayer(player.Name, player);
	}

	public bool PlayerExists(string name)
	{
		return new PlayerFile(_playerPath, name).Exists();
	}

	public void DeletePlayer(string name)
	{
		try
		{
			new PlayerFile(_playerPath, name).Delete();
		}
		catch (Exception innerException)
		{
			PlayerIOException ex = new PlayerIOException("Could not remove player", innerException);
			ex.Data["PlayerName"] = name;
			throw ex;
		}
	}

	public IEnumerator<Player> GetEnumerator()
	{
		return new Enumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Enumerator(this);
	}
}
