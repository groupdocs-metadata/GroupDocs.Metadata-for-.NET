---
id: groupdocs-metadata-for-net-20-1-release-notes
url: metadata/net/groupdocs-metadata-for-net-20-1-release-notes
title: GroupDocs.Metadata for .NET 20.1 Release Notes
weight: 20
description: ""
keywords: 
productName: GroupDocs.Metadata for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Metadata for .NET 20.1{{< /alert >}}

## Major Features

There are the following features, enhancements and fixes in this release:

*   Implement the ability to obtain known property descriptors in the public API
*   Implement an alternative way to extract metadata property values
*   Add support for .Net Standard 2.0

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| METADATANET-3132 | Implement the ability to obtain known property descriptors in the public API | Improvement |
| METADATANET-3143 | Implement an alternative way to extract metadata property values | Improvement |
| METADATANET-3133 | Add support for .Net Standard 2.0 | Improvement |

## Public API and Backward Incompatible Changes

### Implement the ability to obtain known property descriptors in the public API

This enhancement allows the user to extract information about known properties that can be encountered in a particular package.

##### Public API changes

The *PropertyAccessLevels* enum has been added to the *GroupDocs.Metadata.Common* namespace

The *Read* item has been added to the *PropertyAccessLevels* enum

The *Update* item has been added to the *PropertyAccessLevels* enum

The *Remove* item has been added to the *PropertyAccessLevels* enum

The *Add* item has been added to the *PropertyAccessLevels* enum

The *AddOrUpdate* item has been added to the *PropertyAccessLevels* enum

The *Full* item has been added to the *PropertyAccessLevels* enum

The *PropertyDescriptor* class has been added to the *GroupDocs.Metadata.Common* namespace

The *Type* property has been added to the *PropertyDescriptor* class

The *AccessLevel* property has been added to the *PropertyDescriptor* class

The *Tags* property has been added to the *PropertyDescriptor* class

The *Name* property has been added to the *PropertyDescriptor* class

The *KnowPropertyDescriptors* property has been added to the *MetadataPackage* class

##### Use cases

Obtain known property descriptors from a metadata package



```csharp
using (Metadata metadata = new Metadata(@"D:\input.doc"))
{
	var root = metadata.GetRootPackage<WordProcessingRootPackage>();
	foreach (var descriptor in root.DocumentProperties.KnowPropertyDescriptors)
	{
		Console.WriteLine(descriptor.Name);
		Console.WriteLine(descriptor.Type);
		Console.WriteLine(descriptor.AccessLevel);

		foreach (var tag in descriptor.Tags)
		{
			Console.WriteLine(tag);
		}

		Console.WriteLine();
	}
}
```

{{< alert style="info" >}}Not all possible properties are presented in the KnowPropertyDescriptors collection. The library provides information on the most frequently used properties only. If there is no descriptor for some property it is still accessible through the GroupDocs.Metadata search engine in read-only mode.{{< /alert >}}

### Add support for .Net Standard 2.0

Starting from 20.1 release GroupDocs.Metadata for .Net includes a .Net Standard 2.0 compatible assembly.

##### Public API changes

None

### Implement an alternative way to extract metadata property values

This enhancement introduces an alternative way to extract a value stored in a metadata property.

##### Public API changes

The *ValueAcceptor* class has been added to the *GroupDocs.Metadata.Common* namespace

The *AcceptNull()* method has been added to the *ValueAcceptor* class

The *Accept(string)* method has been added to the *ValueAcceptor* class

The *Accept(bool)* method has been added to the *ValueAcceptor* class

The *Accept(DateTime)* method has been added to the *ValueAcceptor* class

The *Accept(TimeSpan)* method has been added to the *ValueAcceptor* class

The *Accept(int)* method has been added to the *ValueAcceptor* class

The *Accept(long)* method has been added to the *ValueAcceptor* class

The *Accept(double)* method has been added to the *ValueAcceptor* class

The *Accept(string\[\])* method has been added to the *ValueAcceptor* class

The *Accept(byte\[\])* method has been added to the *ValueAcceptor* class

The *Accept(double\[\])* method has been added to the *ValueAcceptor* class

The *Accept(int\[\])* method has been added to the *ValueAcceptor* class

The *Accept(long\[\])* method has been added to the *ValueAcceptor* class

The *Accept(MetadataPackage)* method has been added to the *ValueAcceptor* class

The *Accept(*MetadataPackage*\[\])* method has been added to the *ValueAcceptor* class

The *Accept(Guid)* method has been added to the *ValueAcceptor* class

The *Accept(PropertyValue\[\])* method has been added to the *ValueAcceptor* class

The *AcceptValue(ValueAcceptor)* method has been added to the *PropertyValue* class

##### Use cases

Print values of all properties extracted from a file



```csharp
static void Main(string[] args)
{
	using (Metadata metadata = new Metadata(@"D:\input.docx"))
	{
		// Fetch all metadata properties
		var properties = metadata.FindProperties(p => true);

		var valueAcceptor = new CustomValueAcceptor();
		foreach (var property in properties)
		{
			// Extract the property value using a custom acceptor
			property.Value.AcceptValue(valueAcceptor);
		}
	}
	Console.ReadKey();
}
private class CustomValueAcceptor : ValueAcceptor
{
	protected override void AcceptNull()
	{
		Console.WriteLine("Null value extracted");
	}

	protected override void Accept(string value)
	{
		Console.WriteLine("String value extracted: {0}", value);
	}

	protected override void Accept(bool value)
	{
		Console.WriteLine("Boolean value extracted: {0}", value);
	}

	protected override void Accept(DateTime value)
	{
		Console.WriteLine("DateTime value extracted: {0}", value);
	}

	protected override void Accept(TimeSpan value)
	{
		Console.WriteLine("DateTime value extracted: {0}", value);
	}

	protected override void Accept(int value)
	{
		Console.WriteLine("Integer value extracted: {0}", value);
	}

	protected override void Accept(long value)
	{
		Console.WriteLine("Long value extracted: {0}", value);
	}

	protected override void Accept(double value)
	{
		Console.WriteLine("Double value extracted: {0}", value);
	}

	protected override void Accept(string[] value)
	{
		Console.WriteLine("String array extracted: {0}", value?.Length ?? 0);
	}

	protected override void Accept(byte[] value)
	{
		Console.WriteLine("Byte array extracted: {0}", value?.Length ?? 0);
	}

	protected override void Accept(double[] value)
	{
		Console.WriteLine("Double array extracted: {0}", value?.Length ?? 0);
	}

	protected override void Accept(int[] value)
	{
		Console.WriteLine("Integer array extracted: {0}", value?.Length ?? 0);
	}

	protected override void Accept(long[] value)
	{
		Console.WriteLine("Long array extracted: {0}", value?.Length ?? 0);
	}

	protected override void Accept(MetadataPackage value)
	{
		Console.WriteLine("Metadata package value extracted: {0}", value);
	}

	protected override void Accept(MetadataPackage[] value)
	{
		Console.WriteLine("Metadata package array extracted: {0}", value?.Length ?? 0);
	}

	protected override void Accept(Guid value)
	{
		Console.WriteLine("Guid value extracted: {0}", value);
	}

	protected override void Accept(PropertyValue[] value)
	{
		Console.WriteLine("Property value array extracted: {0}", value?.Length ?? 0);
	}
}
```
