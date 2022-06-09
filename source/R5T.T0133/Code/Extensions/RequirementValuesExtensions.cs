using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0133
{
    public static class RequirementValuesExtensions
    {
        public static CompilationRequirements<TNode> GetCompilationRequirements<TNode>(this RequirementValues requirementValues,
            TNode node)
            where TNode : SyntaxNode
        {
            var output = new CompilationRequirements<TNode>(
                node,
                requirementValues.NamespaceNames,
                requirementValues.NameAliases,
                requirementValues.ProjectReferenceFilePaths);

            return output;
        }
    }
}
