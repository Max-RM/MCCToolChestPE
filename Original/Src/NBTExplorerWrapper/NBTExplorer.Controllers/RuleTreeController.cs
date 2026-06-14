using System.Windows.Forms;
using NBTExplorer.Model.Search;
using NBTExplorer.Windows;
using NBTExplorer.Windows.Search;
using Substrate.Nbt;

namespace NBTExplorer.Controllers;

public class RuleTreeController
{
	private TreeView _nodeTree;

	private IconRegistry _iconRegistry;

	private RootRule _rootData;

	public RootRule Root => _rootData;

	public TreeView Tree => _nodeTree;

	public bool ShowVirtualRoot { get; set; }

	public string VirtualRootDisplay => _rootData.NodeDisplay;

	private TreeNode SelectedNode => _nodeTree.SelectedNode;

	private TreeNode SelectedOrRootNode
	{
		get
		{
			TreeNode treeNode = _nodeTree.SelectedNode;
			if (treeNode == null)
			{
				if (_nodeTree.Nodes.Count <= 0)
				{
					return null;
				}
				treeNode = _nodeTree.Nodes[0];
			}
			return treeNode;
		}
	}

	public RuleTreeController(TreeView nodeTree)
	{
		_nodeTree = nodeTree;
		InitializeIconRegistry();
		ShowVirtualRoot = true;
		_rootData = new RootRule();
		RefreshTree();
	}

	private void InitializeIconRegistry()
	{
		_iconRegistry = new IconRegistry();
		_iconRegistry.DefaultIcon = 15;
		_iconRegistry.Register(typeof(RootRule), 18);
		_iconRegistry.Register(typeof(UnionRule), 21);
		_iconRegistry.Register(typeof(IntersectRule), 20);
		_iconRegistry.Register(typeof(WildcardRule), 19);
		_iconRegistry.Register(typeof(ByteTagRule), 0);
		_iconRegistry.Register(typeof(ShortTagRule), 1);
		_iconRegistry.Register(typeof(IntTagRule), 2);
		_iconRegistry.Register(typeof(LongTagRule), 3);
		_iconRegistry.Register(typeof(FloatTagRule), 4);
		_iconRegistry.Register(typeof(DoubleTagRule), 5);
		_iconRegistry.Register(typeof(StringTagRule), 7);
	}

	public void DeleteSelection()
	{
		DeleteNode(SelectedNode);
	}

	public void DeleteNode(TreeNode node)
	{
		if (node != null && node.Tag is SearchRule)
		{
			TreeNode parent = node.Parent;
			if (parent != null && parent.Tag is GroupRule)
			{
				GroupRule groupRule = parent.Tag as GroupRule;
				SearchRule item = node.Tag as SearchRule;
				groupRule.Rules.Remove(item);
				parent.Nodes.Remove(node);
			}
		}
	}

	private TreeNode CreateIntegralNode<T, K>(string typeName) where T : IntegralTagRule<K>, new() where K : TagNode
	{
		T rule = new T();
		ValueRuleForm valueRuleForm = new ValueRuleForm(SearchRule.NumericOpStrings);
		valueRuleForm.Text = "Edit " + typeName + " Tag Rule";
		using (ValueRuleForm valueRuleForm2 = valueRuleForm)
		{
			if (valueRuleForm2.ShowDialog() != DialogResult.OK)
			{
				return null;
			}
			string tagName = valueRuleForm2.TagName;
			rule.Name = tagName;
			long tagValueAsLong = valueRuleForm2.TagValueAsLong;
			rule.Value = tagValueAsLong;
			NumericOperator num = valueRuleForm2.Operator;
			rule.Operator = num;
		}
		TreeNode treeNode = CreateNode(rule);
		treeNode.Text = rule.NodeDisplay;
		return treeNode;
	}

	private void EditIntegralNode<T, K>(TreeNode node, T rule, string typeName) where T : IntegralTagRule<K> where K : TagNode
	{
		ValueRuleForm valueRuleForm = new ValueRuleForm(SearchRule.NumericOpStrings);
		valueRuleForm.Text = "Edit " + typeName + " Tag Rule";
		valueRuleForm.TagName = rule.Name;
		valueRuleForm.TagValue = rule.Value.ToString();
		valueRuleForm.Operator = rule.Operator;
		using (ValueRuleForm valueRuleForm2 = valueRuleForm)
		{
			if (valueRuleForm2.ShowDialog() == DialogResult.OK)
			{
				string tagName = valueRuleForm2.TagName;
				rule.Name = tagName;
				long tagValueAsLong = valueRuleForm2.TagValueAsLong;
				rule.Value = tagValueAsLong;
				NumericOperator num = valueRuleForm2.Operator;
				rule.Operator = num;
			}
		}
		node.Text = rule.NodeDisplay;
	}

	private TreeNode CreateFloatNode<T, K>(string typeName) where T : FloatTagRule<K>, new() where K : TagNode
	{
		T rule = new T();
		ValueRuleForm valueRuleForm = new ValueRuleForm(SearchRule.NumericOpStrings);
		valueRuleForm.Text = "Edit " + typeName + " Tag Rule";
		using (ValueRuleForm valueRuleForm2 = valueRuleForm)
		{
			if (valueRuleForm2.ShowDialog() != DialogResult.OK)
			{
				return null;
			}
			string tagName = valueRuleForm2.TagName;
			rule.Name = tagName;
			double tagValueAsDouble = valueRuleForm2.TagValueAsDouble;
			rule.Value = tagValueAsDouble;
			NumericOperator num = valueRuleForm2.Operator;
			rule.Operator = num;
		}
		TreeNode treeNode = CreateNode(rule);
		treeNode.Text = rule.NodeDisplay;
		return treeNode;
	}

	private void EditFloatNode<T, K>(TreeNode node, T rule, string typeName) where T : FloatTagRule<K> where K : TagNode
	{
		ValueRuleForm valueRuleForm = new ValueRuleForm(SearchRule.NumericOpStrings);
		valueRuleForm.Text = "Edit " + typeName + " Tag Rule";
		valueRuleForm.TagName = rule.Name;
		valueRuleForm.TagValue = rule.Value.ToString();
		valueRuleForm.Operator = rule.Operator;
		using (ValueRuleForm valueRuleForm2 = valueRuleForm)
		{
			if (valueRuleForm2.ShowDialog() == DialogResult.OK)
			{
				string tagName = valueRuleForm2.TagName;
				rule.Name = tagName;
				double tagValueAsDouble = valueRuleForm2.TagValueAsDouble;
				rule.Value = tagValueAsDouble;
				NumericOperator num = valueRuleForm2.Operator;
				rule.Operator = num;
			}
		}
		node.Text = rule.NodeDisplay;
	}

	private TreeNode CreateStringNode(string typeName)
	{
		StringTagRule stringTagRule = new StringTagRule();
		StringRuleForm stringRuleForm = new StringRuleForm(SearchRule.StringOpStrings);
		stringRuleForm.Text = "Edit " + typeName + " Tag Rule";
		using (StringRuleForm stringRuleForm2 = stringRuleForm)
		{
			if (stringRuleForm2.ShowDialog() != DialogResult.OK)
			{
				return null;
			}
			stringTagRule.Name = stringRuleForm2.TagName;
			stringTagRule.Value = stringRuleForm2.TagValue;
			stringTagRule.Operator = stringRuleForm2.Operator;
		}
		TreeNode treeNode = CreateNode(stringTagRule);
		treeNode.Text = stringTagRule.NodeDisplay;
		return treeNode;
	}

	private void EditStringNode(TreeNode node, StringTagRule rule, string typeName)
	{
		StringRuleForm stringRuleForm = new StringRuleForm(SearchRule.StringOpStrings);
		stringRuleForm.Text = "Edit " + typeName + " Tag Rule";
		stringRuleForm.TagName = rule.Name;
		stringRuleForm.TagValue = rule.Value;
		stringRuleForm.Operator = rule.Operator;
		using (StringRuleForm stringRuleForm2 = stringRuleForm)
		{
			if (stringRuleForm2.ShowDialog() == DialogResult.OK)
			{
				rule.Name = stringRuleForm2.TagName;
				rule.Value = stringRuleForm2.TagValue;
				rule.Operator = stringRuleForm2.Operator;
			}
		}
		node.Text = rule.NodeDisplay;
	}

	private TreeNode CreateWildcardNode(string typeName)
	{
		WildcardRule wildcardRule = new WildcardRule();
		WildcardRuleForm wildcardRuleForm = new WildcardRuleForm(SearchRule.WildcardOpStrings);
		wildcardRuleForm.Text = "Edit " + typeName + " Rule";
		using (WildcardRuleForm wildcardRuleForm2 = wildcardRuleForm)
		{
			if (wildcardRuleForm2.ShowDialog() != DialogResult.OK)
			{
				return null;
			}
			wildcardRule.Name = wildcardRuleForm2.TagName;
			wildcardRule.Value = wildcardRuleForm2.TagValue;
			wildcardRule.Operator = wildcardRuleForm2.Operator;
		}
		TreeNode treeNode = CreateNode(wildcardRule);
		treeNode.Text = wildcardRule.NodeDisplay;
		return treeNode;
	}

	private void EditWildcardNode(TreeNode node, WildcardRule rule, string typeName)
	{
		WildcardRuleForm wildcardRuleForm = new WildcardRuleForm(SearchRule.WildcardOpStrings);
		wildcardRuleForm.Text = "Edit " + typeName + " Rule";
		wildcardRuleForm.TagName = rule.Name;
		wildcardRuleForm.TagValue = rule.Value;
		wildcardRuleForm.Operator = rule.Operator;
		using (WildcardRuleForm wildcardRuleForm2 = wildcardRuleForm)
		{
			if (wildcardRuleForm2.ShowDialog() == DialogResult.OK)
			{
				rule.Name = wildcardRuleForm2.TagName;
				rule.Value = wildcardRuleForm2.TagValue;
				rule.Operator = wildcardRuleForm2.Operator;
			}
		}
		node.Text = rule.NodeDisplay;
	}

	public void CreateNode(TreeNode node, TagType type)
	{
		if (node != null && node.Tag is GroupRule)
		{
			GroupRule groupRule = node.Tag as GroupRule;
			TreeNode treeNode = null;
			switch (type)
			{
			case TagType.TAG_BYTE:
				treeNode = CreateIntegralNode<ByteTagRule, TagNodeByte>("Byte");
				break;
			case TagType.TAG_SHORT:
				treeNode = CreateIntegralNode<ShortTagRule, TagNodeShort>("Short");
				break;
			case TagType.TAG_INT:
				treeNode = CreateIntegralNode<IntTagRule, TagNodeInt>("Int");
				break;
			case TagType.TAG_LONG:
				treeNode = CreateIntegralNode<LongTagRule, TagNodeLong>("Long");
				break;
			case TagType.TAG_FLOAT:
				treeNode = CreateFloatNode<FloatTagRule, TagNodeFloat>("Float");
				break;
			case TagType.TAG_DOUBLE:
				treeNode = CreateFloatNode<DoubleTagRule, TagNodeDouble>("Double");
				break;
			case TagType.TAG_STRING:
				treeNode = CreateStringNode("String");
				break;
			}
			if (treeNode != null)
			{
				node.Nodes.Add(treeNode);
				groupRule.Rules.Add(treeNode.Tag as SearchRule);
				node.Expand();
			}
		}
	}

	public void EditNode(TreeNode node)
	{
		if (node != null && node.Tag is SearchRule)
		{
			SearchRule searchRule = node.Tag as SearchRule;
			if (searchRule is ByteTagRule)
			{
				EditIntegralNode<ByteTagRule, TagNodeByte>(node, searchRule as ByteTagRule, "Byte");
			}
			else if (searchRule is ShortTagRule)
			{
				EditIntegralNode<ShortTagRule, TagNodeShort>(node, searchRule as ShortTagRule, "Short");
			}
			else if (searchRule is IntTagRule)
			{
				EditIntegralNode<IntTagRule, TagNodeInt>(node, searchRule as IntTagRule, "Int");
			}
			else if (searchRule is LongTagRule)
			{
				EditIntegralNode<LongTagRule, TagNodeLong>(node, searchRule as LongTagRule, "Long");
			}
			else if (searchRule is FloatTagRule)
			{
				EditFloatNode<FloatTagRule, TagNodeFloat>(node, searchRule as FloatTagRule, "Float");
			}
			else if (searchRule is DoubleTagRule)
			{
				EditFloatNode<DoubleTagRule, TagNodeDouble>(node, searchRule as DoubleTagRule, "Double");
			}
			else if (searchRule is StringTagRule)
			{
				EditStringNode(node, searchRule as StringTagRule, "String");
			}
			else if (searchRule is WildcardRule)
			{
				EditWildcardNode(node, searchRule as WildcardRule, "Wildcard");
			}
		}
	}

	public void EditSelection()
	{
		if (_nodeTree.SelectedNode != null)
		{
			EditNode(_nodeTree.SelectedNode);
		}
	}

	public void CreateWildcardNode(TreeNode node)
	{
		if (node != null && node.Tag is GroupRule)
		{
			GroupRule groupRule = node.Tag as GroupRule;
			TreeNode treeNode = CreateWildcardNode("Wildcard");
			if (treeNode != null)
			{
				node.Nodes.Add(treeNode);
				groupRule.Rules.Add(treeNode.Tag as SearchRule);
				node.Expand();
			}
		}
	}

	public void CreateWildcardNode()
	{
		CreateWildcardNode(SelectedOrRootNode);
	}

	public void CreateUnionNode(TreeNode node)
	{
		if (node != null && node.Tag is GroupRule)
		{
			GroupRule groupRule = node.Tag as GroupRule;
			TreeNode treeNode = CreateNode(new UnionRule());
			node.Nodes.Add(treeNode);
			groupRule.Rules.Add(treeNode.Tag as SearchRule);
			node.Expand();
		}
	}

	public void CreateUnionNode()
	{
		CreateUnionNode(SelectedOrRootNode);
	}

	public void CreateIntersectNode(TreeNode node)
	{
		if (node != null && node.Tag is GroupRule)
		{
			GroupRule groupRule = node.Tag as GroupRule;
			TreeNode treeNode = CreateNode(new IntersectRule());
			node.Nodes.Add(treeNode);
			groupRule.Rules.Add(treeNode.Tag as SearchRule);
			node.Expand();
		}
	}

	public void CreateIntersectNode()
	{
		CreateIntersectNode(SelectedOrRootNode);
	}

	public void CreateNode(TagType type)
	{
		if (SelectedOrRootNode != null)
		{
			CreateNode(SelectedOrRootNode, type);
		}
	}

	private TreeNode CreateNode(SearchRule rule)
	{
		TreeNode treeNode = new TreeNode(rule.NodeDisplay);
		treeNode.ImageIndex = _iconRegistry.Lookup(rule.GetType());
		treeNode.SelectedImageIndex = treeNode.ImageIndex;
		treeNode.Tag = rule;
		return treeNode;
	}

	private void ExpandNode(TreeNode node, bool recurse)
	{
		if (!(node.Tag is GroupRule groupRule))
		{
			return;
		}
		foreach (SearchRule rule in groupRule.Rules)
		{
			TreeNode node2 = CreateNode(rule);
			node.Nodes.Add(node2);
			if (recurse)
			{
				ExpandNode(node2, recurse);
			}
		}
	}

	private void RefreshTree()
	{
		_nodeTree.Nodes.Clear();
		_nodeTree.Nodes.Add(CreateNode(_rootData));
		ExpandNode(_nodeTree.Nodes[0], recurse: true);
		_nodeTree.ExpandAll();
	}
}
