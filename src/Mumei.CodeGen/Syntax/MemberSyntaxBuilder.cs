﻿using Mumei.CodeGen.SyntaxWriters;

namespace Mumei.CodeGen.SyntaxBuilders;

public abstract class MemberSyntaxBuilder {
  private readonly SyntaxTypeContext _ctx;
  protected readonly List<Tuple<Type, object[]>> Attributes = new();

  public MemberSyntaxBuilder(int indentLevel, SyntaxTypeContext ctx) {
    _ctx = ctx;
  }

  public abstract string Build();

  public void AddAttribute(Type attributeType, params object[] arguments) {
    Attributes.Add(new Tuple<Type, object[]>(attributeType, arguments));
  }

  public void AddAttribute<TAttribute>(params object[] arguments) where TAttribute : Attribute {
    AddAttribute(typeof(TAttribute), arguments);
  }

  protected internal string GetAttributeString() {
    var writer = new AttributeSyntaxWriter(0, _ctx);

    foreach (var (attributeType, arguments) in Attributes) {
      // writer.WriteAttribute(attributeType, arguments);
    }

    return writer.ToSyntax();
  }
}