using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ClearScript.Util;

namespace Microsoft.ClearScript.V8;

public class V8CpuProfile
{
	public sealed class Node
	{
		public struct HitLine
		{
			public long LineNumber;

			public ulong HitCount;

			internal void WriteJson(TextWriter writer)
			{
				writer.Write("{{\"line\":{0},\"ticks\":{1}}}", LineNumber, HitCount);
			}
		}

		public ulong NodeId { get; set; }

		public long ScriptId { get; set; }

		public string ScriptName { get; internal set; }

		public string FunctionName { get; internal set; }

		public long LineNumber { get; internal set; }

		public long ColumnNumber { get; internal set; }

		public ulong HitCount { get; internal set; }

		public string BailoutReason { get; internal set; }

		public IReadOnlyList<HitLine> HitLines { get; internal set; }

		public IReadOnlyList<Node> ChildNodes { get; internal set; }

		internal Node()
		{
		}

		internal Node FindNode(ulong nodeId)
		{
			if (NodeId == nodeId)
			{
				return this;
			}
			if (ChildNodes != null)
			{
				foreach (Node childNode in ChildNodes)
				{
					Node node = childNode.FindNode(nodeId);
					if (node != null)
					{
						return node;
					}
				}
			}
			return null;
		}

		internal void WriteJson(TextWriter writer, Queue<Node> queue)
		{
			writer.Write('{');
			writer.Write("\"id\":" + NodeId);
			WriteCallFrameJson(writer);
			writer.Write(",\"hitCount\":" + HitCount);
			WriteChildrenJson(writer, queue);
			if (!string.IsNullOrEmpty(BailoutReason))
			{
				writer.Write(",\"deoptReason\":" + BailoutReason.ToQuotedJson());
			}
			WritePositionTicksJson(writer);
			writer.Write('}');
		}

		private void WriteCallFrameJson(TextWriter writer)
		{
			writer.Write(",\"callFrame\":{");
			writer.Write("\"functionName\":" + (FunctionName ?? string.Empty).ToQuotedJson());
			writer.Write(",\"scriptId\":" + ScriptId);
			writer.Write(",\"url\":" + (ScriptName ?? string.Empty).ToQuotedJson());
			writer.Write(",\"lineNumber\":" + (LineNumber - 1));
			writer.Write(",\"columnNumber\":" + (ColumnNumber - 1));
			writer.Write('}');
		}

		private void WriteChildrenJson(TextWriter writer, Queue<Node> queue)
		{
			if (ChildNodes != null && ChildNodes.Count > 0)
			{
				writer.Write(",\"children\":[{0}]", string.Join(",", ChildNodes.Select((Node node) => node.NodeId)));
				ChildNodes.ForEach(queue.Enqueue);
			}
		}

		private void WritePositionTicksJson(TextWriter writer)
		{
			if (HitLines != null && HitLines.Count > 0)
			{
				writer.Write(",\"positionTicks\":[");
				HitLines[0].WriteJson(writer);
				for (int i = 1; i < HitLines.Count; i++)
				{
					writer.Write(',');
					HitLines[i].WriteJson(writer);
				}
				writer.Write(']');
			}
		}
	}

	public sealed class Sample
	{
		public Node Node { get; internal set; }

		public ulong Timestamp { get; internal set; }

		internal Sample()
		{
		}
	}

	public string Name { get; internal set; }

	public ulong StartTimestamp { get; internal set; }

	public ulong EndTimestamp { get; internal set; }

	public Node RootNode { get; internal set; }

	public IReadOnlyList<Sample> Samples { get; internal set; }

	internal V8CpuProfile()
	{
	}

	public string ToJson()
	{
		using StringWriter stringWriter = new StringWriter();
		WriteJson(stringWriter);
		return stringWriter.ToString();
	}

	public void WriteJson(TextWriter writer)
	{
		writer.Write('{');
		WriteNodesJson(writer);
		writer.Write(",\"startTime\":" + StartTimestamp);
		writer.Write(",\"endTime\":" + EndTimestamp);
		WriteSamplesJson(writer);
		WriteTimeDeltasJson(writer);
		writer.Write('}');
	}

	internal Node FindNode(ulong nodeId)
	{
		if (RootNode == null)
		{
			return null;
		}
		return RootNode.FindNode(nodeId);
	}

	private void WriteNodesJson(TextWriter writer)
	{
		writer.Write("\"nodes\":[");
		if (RootNode != null)
		{
			Queue<Node> queue = new Queue<Node>();
			RootNode.WriteJson(writer, queue);
			while (queue.Count > 0)
			{
				writer.Write(',');
				queue.Dequeue().WriteJson(writer, queue);
			}
		}
		writer.Write(']');
	}

	private void WriteSamplesJson(TextWriter writer)
	{
		if (Samples != null && Samples.Count > 0)
		{
			writer.Write(",\"samples\":[{0}]", string.Join(",", Samples.Select((Sample sample) => sample.Node.NodeId)));
		}
	}

	private void WriteTimeDeltasJson(TextWriter writer)
	{
		if (Samples != null && Samples.Count > 0)
		{
			writer.Write(",\"timeDeltas\":[");
			writer.Write(Samples[0].Timestamp - StartTimestamp);
			for (int i = 1; i < Samples.Count; i++)
			{
				writer.Write(',');
				writer.Write(Samples[i].Timestamp - Samples[i - 1].Timestamp);
			}
			writer.Write(']');
		}
	}
}
