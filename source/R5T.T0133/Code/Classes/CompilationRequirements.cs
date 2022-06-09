using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;

using R5T.T0129;


namespace R5T.T0133
{
    /// <summary>
    /// Allows syntax node creation functions to return a created node along with any namespace names and project references required to compile the syntax of the node.
    /// </summary>
    public class CompilationRequirements<TNode> : CompilationRequirements
        where TNode : SyntaxNode
    {
        public TNode Node { get; }


        public CompilationRequirements(
            TNode node,
            IEnumerable<string> namespaceNames,
            IEnumerable<NameAlias> nameAliases,
            IEnumerable<string> projectReferenceFilePaths)
            : base(
                  namespaceNames,
                  nameAliases,
                  projectReferenceFilePaths)
        {
            this.Node = node;
        }
    }


    public abstract class CompilationRequirements
    {
        #region Static

        public static CompilationRequirements<TNode> From<TNode>(
            TNode node,
            IEnumerable<string> namespaceNames = default,
            IEnumerable<NameAlias> nameAliases = default,
            IEnumerable<string> projectReferenceFilePaths = default)
            where TNode : SyntaxNode
        {
            var output = new CompilationRequirements<TNode>(
                node,
                namespaceNames,
                nameAliases,
                projectReferenceFilePaths);

            return output;
        }

        #endregion


        public List<string> NamespaceNames { get; }
        public List<NameAlias> NameAliases { get; }
        public List<string> ProjectReferenceFilePaths { get; }


        public CompilationRequirements(
            IEnumerable<string> namespaceNames,
            IEnumerable<NameAlias> nameAliases,
            IEnumerable<string> projectReferenceFilePaths)
        {
            this.NamespaceNames = namespaceNames.ToList_HandleDefault();
            this.NameAliases = nameAliases.ToList_HandleDefault();
            this.ProjectReferenceFilePaths = projectReferenceFilePaths.ToList_HandleDefault();
        }
    }
}