using System.Collections.Generic;
using System.Xml;
using NAppUpdate.Framework.Conditions;
using NAppUpdate.Framework.Tasks;

namespace NAppUpdate.Framework.FeedReaders;

public class AppcastReader : IUpdateFeedReader
{
	public IList<IUpdateTask> Read(string feed)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(feed);
		XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/rss/channel/item");
		List<IUpdateTask> list = new List<IUpdateTask>();
		foreach (XmlNode item in xmlNodeList)
		{
			FileUpdateTask fileUpdateTask = new FileUpdateTask();
			fileUpdateTask.Description = item["description"].InnerText;
			fileUpdateTask.UpdateTo = item["enclosure"].Attributes["url"].Value;
			FileVersionCondition fileVersionCondition = new FileVersionCondition();
			fileVersionCondition.Version = item["appcast:version"].InnerText;
			if (fileUpdateTask.UpdateConditions == null)
			{
				fileUpdateTask.UpdateConditions = new BooleanCondition();
			}
			fileUpdateTask.UpdateConditions.AddCondition(fileVersionCondition, BooleanCondition.ConditionType.AND);
			list.Add(fileUpdateTask);
		}
		return list;
	}
}
