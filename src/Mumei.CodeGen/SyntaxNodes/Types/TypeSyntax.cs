﻿// ReSharper disable once CheckNamespace

using Mumei.CodeGen.SyntaxNodes;
using Mumei.CodeGen.SyntaxWriters;

namespace Mumei.CodeGen.SyntaxBuilders;

public abstract class TypeSyntax : Syntax {
  private readonly List<MemberSyntax> _members = new();

  public readonly Type[] TypeArguments = Type.EmptyTypes;
  public bool IsGenericType => TypeArguments.Length > 0;

  public IEnumerable<MemberSyntax> Members => _members;
  public bool HasMembers => _members.Count > 0;

  protected TypeSyntax(string name) : base(name) {
  }

  protected TypeSyntax(string name, Syntax? parent) : base(name, parent) {
  }

  public void AddMember(MemberSyntax member) {
    _members.Add(member);
  }

  public T AddNewMember<T>(string name, Type typeOrReturnType) where T : MemberSyntax {
    var member = (T) Activator.CreateInstance(typeof(T), name, typeOrReturnType);
    AddMember(member);
    return member;
  }

  public T? GetMember<T>(string name) where T : MemberSyntax {
    return Members.OfType<T>().SingleOrDefault(m => m.Name == name);
  }

  public IEnumerable<T> GetMembers<T>() where T : MemberSyntax {
    return Members.OfType<T>();
  }

  /// <summary>
  ///   Writes all members of the type to the syntax writer.
  /// </summary>
  /// <param name="writer"></param>
  protected void WriteMembers(ITypeAwareSyntaxWriter writer) {
  }
}