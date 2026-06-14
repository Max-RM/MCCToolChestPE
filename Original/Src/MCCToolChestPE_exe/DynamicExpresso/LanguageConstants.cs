using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using qKu0ijWwCUEywjMLLp;
using uL2B6CXB2hZQU16Di7r;
using YBh7EaXMWmkFRJOX37M;

namespace DynamicExpresso;

public static class LanguageConstants
{
	public static readonly ReferenceType[] PrimitiveTypes;

	public static readonly ReferenceType[] CSharpPrimitiveTypes;

	public static readonly ReferenceType[] CommonTypes;

	public static readonly Identifier[] Literals;

	public static readonly string[] ReserverKeywords;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static LanguageConstants()
	{
		while (false)
		{
			_ = ((object[])null)[0];
		}
		Hm96YcXHNOTbKhIs4rg.TtVGNoKztHEBW();
		PrimitiveTypes = new ReferenceType[18]
		{
			new ReferenceType(typeof(object)),
			new ReferenceType(typeof(bool)),
			new ReferenceType(typeof(char)),
			new ReferenceType(typeof(string)),
			new ReferenceType(typeof(sbyte)),
			new ReferenceType(typeof(byte)),
			new ReferenceType(typeof(short)),
			new ReferenceType(typeof(ushort)),
			new ReferenceType(typeof(int)),
			new ReferenceType(typeof(uint)),
			new ReferenceType(typeof(long)),
			new ReferenceType(typeof(ulong)),
			new ReferenceType(typeof(float)),
			new ReferenceType(typeof(double)),
			new ReferenceType(typeof(decimal)),
			new ReferenceType(typeof(DateTime)),
			new ReferenceType(typeof(TimeSpan)),
			new ReferenceType(typeof(Guid))
		};
		CSharpPrimitiveTypes = new ReferenceType[9]
		{
			new ReferenceType(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31526), typeof(object)),
			new ReferenceType(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31542), typeof(string)),
			new ReferenceType(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31558), typeof(char)),
			new ReferenceType(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31570), typeof(bool)),
			new ReferenceType(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31582), typeof(byte)),
			new ReferenceType(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31594), typeof(int)),
			new ReferenceType(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31604), typeof(long)),
			new ReferenceType(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31616), typeof(double)),
			new ReferenceType(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31632), typeof(decimal))
		};
		CommonTypes = new ReferenceType[3]
		{
			new ReferenceType(typeof(Math)),
			new ReferenceType(typeof(Convert)),
			new ReferenceType(typeof(Enumerable))
		};
		Literals = new Identifier[3]
		{
			new Identifier(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31650), Expression.Constant(true)),
			new Identifier(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31662), Expression.Constant(false)),
			new Identifier(Ne4dSgXrbYTX6VcmT1p.mqbSrBrZa1U(31676), EDoCLYSxsUAlj0LLek.QgqLITYqRZ)
		};
		ReserverKeywords = EDoCLYSxsUAlj0LLek.TbZLzS7xMm;
	}
}
