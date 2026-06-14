using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using NAppUpdate.Framework.Conditions;
using NAppUpdate.Framework.Tasks;
using NAppUpdate.Framework.Utils;

namespace NAppUpdate.Framework.FeedReaders;

public class NauXmlFeedReader : IUpdateFeedReader
{
	private Dictionary<string, Type> _updateConditions { get; set; }

	private Dictionary<string, Type> _updateTasks { get; set; }

	public IList<IUpdateTask> Read(string feed)
	{
		if (_updateTasks == null)
		{
			_updateConditions = new Dictionary<string, Type>();
			_updateTasks = new Dictionary<string, Type>();
			Reflection.FindTasksAndConditionsInAssembly(GetType().Assembly, _updateTasks, _updateConditions);
		}
		List<IUpdateTask> list = new List<IUpdateTask>();
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(feed);
		XmlNode xmlNode = xmlDocument.SelectSingleNode("/Feed[version=\"1.0\"] | /Feed") ?? xmlDocument;
		if (xmlNode.Attributes["BaseUrl"] != null && !string.IsNullOrEmpty(xmlNode.Attributes["BaseUrl"].Value))
		{
			UpdateManager.Instance.BaseUrl = xmlNode.Attributes["BaseUrl"].Value;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		XmlNodeList xmlNodeList = xmlNode.SelectNodes("./Tasks/*");
		if (xmlNodeList == null)
		{
			return new List<IUpdateTask>();
		}
		foreach (XmlNode item in xmlNodeList)
		{
			if (!_updateTasks.ContainsKey(item.Name))
			{
				continue;
			}
			IUpdateTask updateTask = (IUpdateTask)Activator.CreateInstance(_updateTasks[item.Name]);
			if (item.Attributes != null)
			{
				foreach (XmlAttribute attribute in item.Attributes)
				{
					if (!"type".Equals(attribute.Name))
					{
						dictionary.Add(attribute.Name, attribute.Value);
					}
				}
				if (dictionary.Count > 0)
				{
					Reflection.SetNauAttributes(updateTask, dictionary);
					dictionary.Clear();
				}
			}
			if (item.HasChildNodes)
			{
				if (item["Description"] != null)
				{
					updateTask.Description = item["Description"].InnerText;
				}
				if (item["Conditions"] != null)
				{
					IUpdateCondition updateCondition = ReadCondition(item["Conditions"]);
					if (updateCondition != null)
					{
						if (updateCondition is BooleanCondition updateConditions)
						{
							updateTask.UpdateConditions = updateConditions;
						}
						else
						{
							if (updateTask.UpdateConditions == null)
							{
								updateTask.UpdateConditions = new BooleanCondition();
							}
							updateTask.UpdateConditions.AddCondition(updateCondition);
						}
					}
				}
			}
			list.Add(updateTask);
		}
		return list;
	}

	private IUpdateCondition ReadCondition(XmlNode cnd)
	{
		IUpdateCondition updateCondition = null;
		if (cnd.ChildNodes.Count > 0 || "GroupCondition".Equals(cnd.Name))
		{
			BooleanCondition booleanCondition = new BooleanCondition();
			foreach (XmlNode childNode in cnd.ChildNodes)
			{
				IUpdateCondition updateCondition2 = ReadCondition(childNode);
				if (updateCondition2 != null)
				{
					booleanCondition.AddCondition(updateCondition2, BooleanCondition.ConditionTypeFromString((childNode.Attributes != null && childNode.Attributes["type"] != null) ? childNode.Attributes["type"].Value : null));
				}
			}
			if (booleanCondition.ChildConditionsCount > 0)
			{
				updateCondition = booleanCondition.Degrade();
			}
		}
		else if (_updateConditions.ContainsKey(cnd.Name))
		{
			updateCondition = (IUpdateCondition)Activator.CreateInstance(_updateConditions[cnd.Name]);
			if (cnd.Attributes != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				foreach (XmlAttribute attribute in cnd.Attributes)
				{
					if (!"type".Equals(attribute.Name))
					{
						dictionary.Add(attribute.Name, attribute.Value);
					}
				}
				if (dictionary.Count > 0)
				{
					Reflection.SetNauAttributes(updateCondition, dictionary);
				}
			}
		}
		return updateCondition;
	}

	public void LoadConditionsAndTasks(Assembly assembly)
	{
		if (_updateTasks == null)
		{
			_updateConditions = new Dictionary<string, Type>();
			_updateTasks = new Dictionary<string, Type>();
		}
		Reflection.FindTasksAndConditionsInAssembly(assembly, _updateTasks, _updateConditions);
	}
}
