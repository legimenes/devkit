using DevKit.Application;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DevKit.Tests;
public class CodeSnippetTests
{
    [Fact]
    [Trait("", "")]
    public void T()
    {
        string input = """
            public class Account
            {
                public long Id { get; set; }
                public string Fullname { get; set; }
                public string? Email { get; set; }
                public Phone CellPhone { get; set; }
            }
            """;
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(input);
        CompilationUnitSyntax root = syntaxTree.GetCompilationUnitRoot();
        ClassDeclarationSyntax classNode = root.DescendantNodes().OfType<ClassDeclarationSyntax>().First();
        
        EntityModel entityModel = EntityModel.Create(classNode.Identifier.Text);

        IEnumerable<PropertyDeclarationSyntax> properties = classNode.Members.OfType<PropertyDeclarationSyntax>();
        foreach (var prop in properties)
        {
            string type = prop.Type.ToString();
            string name = prop.Identifier.Text;

            Console.WriteLine($">>> Propriedade: {name}, Tipo: {type}");
        }

    }

    [Fact]
    public void ParseClassSyntactically()
    {
        string input = """
            public class Account
            {
                public long Id { get; set; }
                public string Fullname { get; set; }
                public string? Email { get; set; }
                public Phone CellPhone { get; set; }
            }
            """;
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(input);
        CompilationUnitSyntax root = syntaxTree.GetCompilationUnitRoot();
        
        ClassDeclarationSyntax classNode = root.DescendantNodes().OfType<ClassDeclarationSyntax>().First();
        IEnumerable<PropertyDeclarationSyntax> properties = classNode.Members.OfType<PropertyDeclarationSyntax>();

        Assert.Equal("Account", classNode.Identifier.Text);
        Assert.Equal("long", properties.ElementAt(0).Type.ToString());
        Assert.Equal("Id", properties.ElementAt(0).Identifier.Text);
    }
}
