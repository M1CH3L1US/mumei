using Mumei.CodeGen.SyntaxNodes;
using Mumei.CodeGen.SyntaxWriters;

namespace Mumei.Test.SyntaxNodes.Stubs;

public class StubMemberSyntax : MemberSyntax {
  public override int Priority { get; } = 10;

  public StubMemberSyntax(string identifier, Syntax parent) : base(identifier, parent) {
  }

  public override void WriteAsSyntax(ITypeAwareSyntaxWriter writer) {
    throw new NotImplementedException();
  }
}