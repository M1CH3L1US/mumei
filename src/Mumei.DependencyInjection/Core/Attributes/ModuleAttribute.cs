namespace Mumei.Core.Attributes;

/// <summary>
///   Marks a class as a module.
///   Classes that implement IDynamicModule
///   don't need to be marked with this attribute.
///   All "Injectable" members of a module are automatically added to the module.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class ModuleAttribute : Attribute { }