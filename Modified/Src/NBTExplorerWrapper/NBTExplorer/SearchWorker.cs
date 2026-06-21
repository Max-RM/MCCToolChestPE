using System.Collections.Generic;
using System.Diagnostics;
using NBTExplorer.Model;

namespace NBTExplorer;

internal class SearchWorker
{
	private ISearchState _state;

	private bool _cancel;

	private object _lock;

	private Stopwatch _progressWatch;

	private float _progressTime;

	private float _lastSampleTime;

	public SearchWorker(ISearchState state)
	{
		_state = state;
		_lock = new object();
	}

	public void Cancel()
	{
		lock (_lock)
		{
			_cancel = true;
		}
	}

	public void Run()
	{
		_progressWatch = new Stopwatch();
		_progressWatch.Start();
		if (_state.State == null)
		{
			_state.State = FindNode(_state.RootNode).GetEnumerator();
		}
		if (!_state.State.MoveNext())
		{
			InvokeEndCallback();
		}
		_progressWatch.Stop();
	}

	private IEnumerable<DataNode> FindNode(DataNode node)
	{
		lock (_lock)
		{
			if (_cancel)
			{
				yield break;
			}
		}
		if (node == null)
		{
			yield break;
		}
		bool searchExpanded = false;
		if (!node.IsExpanded)
		{
			node.Expand();
			searchExpanded = true;
		}
		if (node is TagDataNode tagNode)
		{
			float currentSampleTime = (float)_progressWatch.Elapsed.TotalSeconds;
			_progressTime += currentSampleTime - _lastSampleTime;
			_lastSampleTime = currentSampleTime;
			if (_progressTime > _state.ProgressRate)
			{
				InvokeProgressCallback(node);
				_progressTime -= _state.ProgressRate;
			}
			if (_state.TestNode(tagNode))
			{
				InvokeDiscoverCallback(node);
				if (_state.TerminateOnDiscover)
				{
					yield return node;
				}
			}
		}
		using (node.Nodes.Snapshot())
		{
			foreach (DataNode sub in node.Nodes)
			{
				foreach (DataNode item in FindNode(sub))
				{
					yield return item;
				}
			}
		}
		if (searchExpanded && !node.IsModified)
		{
			node.Collapse();
			InvokeCollapseCallback(node);
		}
	}

	private void InvokeProgressCallback(DataNode node)
	{
		_state.InvokeProgressCallback(node);
	}

	private void InvokeDiscoverCallback(DataNode node)
	{
		_state.InvokeDiscoverCallback(node);
	}

	private void InvokeCollapseCallback(DataNode node)
	{
		_state.InvokeCollapseCallback(node);
	}

	private void InvokeEndCallback()
	{
		_state.IsTerminated = true;
		_state.InvokeEndCallback(null);
	}
}
