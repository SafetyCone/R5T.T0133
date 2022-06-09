using System;
using System.Collections.Generic;

using R5T.T0129;


namespace R5T.T0133
{
    public class RequirementValues
    {
        public List<string> NamespaceNames { get; }
        public List<NameAlias> NameAliases { get; }
        public List<string> ProjectReferenceFilePaths { get; }


        public RequirementValues(
            List<string> namespaceNames,
            List<NameAlias> nameAliases,
            List<string> projectReferenceFilePaths)
        {
            this.NamespaceNames = namespaceNames;
            this.NameAliases = nameAliases;
            this.ProjectReferenceFilePaths = projectReferenceFilePaths;
        }
    }
}
