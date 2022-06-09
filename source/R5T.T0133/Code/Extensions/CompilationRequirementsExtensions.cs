using System;

using Microsoft.CodeAnalysis;

using R5T.T0133;


namespace System
{
    public static class CompilationRequirementsExtensions
    {
        public static CompilationRequirements<TNode> AddNamespaceName<TNode>(this CompilationRequirements<TNode> compilationRequirements,
            string namespaceName)
            where TNode : SyntaxNode
        {
            compilationRequirements.NamespaceNames.Add(namespaceName);

            return compilationRequirements;
        }

        public static CompilationRequirements<TNode> AddProjectReferenceFilePath<TNode>(this CompilationRequirements<TNode> compilationRequirements,
            string projectReferenceFilePath)
            where TNode : SyntaxNode
        {
            compilationRequirements.ProjectReferenceFilePaths.Add(projectReferenceFilePath);

            return compilationRequirements;
        }

        public static RequirementValues GetRequirementValues(this CompilationRequirements compilationRequirements)
        {
            var output = new RequirementValues(
                compilationRequirements.NamespaceNames,
                compilationRequirements.NameAliases,
                compilationRequirements.ProjectReferenceFilePaths);

            return output;
        }

        public static CompilationRequirements<TNode> Modify<TNode>(this CompilationRequirements<TNode> compilationRequirements,
            Func<TNode, TNode> nodeModifier)
            where TNode : SyntaxNode
        {
            var modifiedNode = nodeModifier(compilationRequirements.Node);

            var output = compilationRequirements.WithNode(
                modifiedNode);

            return output;
        }

        public static CompilationRequirements<TNode> Modify<TNode>(this CompilationRequirements<TNode> compilationRequirements,
            Func<TNode, RequirementValues, TNode> nodeModifier)
            where TNode : SyntaxNode
        {
            var requirementValues = compilationRequirements.GetRequirementValues();

            var modifiedNode = nodeModifier(
                compilationRequirements.Node,
                requirementValues);

            var output = requirementValues.GetCompilationRequirements(
                modifiedNode);

            return output;
        }

        public static CompilationRequirements<TNode> WithNode<TNode>(this CompilationRequirements<TNode> compilationRequirements,
            TNode newNode)
            where TNode : SyntaxNode
        {
            var output = new CompilationRequirements<TNode>(
                newNode,
                compilationRequirements.NamespaceNames,
                compilationRequirements.NameAliases,
                compilationRequirements.ProjectReferenceFilePaths);

            return output;
        }
    }
}
