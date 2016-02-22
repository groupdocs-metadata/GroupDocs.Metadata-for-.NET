// Copyright (c) Aspose 2002-2016. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GroupDocsMetadataVisualStudioPlugin.Core
{
    public class GroupDocsComponents
    {
        public static Dictionary<String, GroupDocsComponent> list = new Dictionary<string, GroupDocsComponent>();
        public GroupDocsComponents()
        {
            list.Clear();

            GroupDocsComponent groupdocsMetadata = new GroupDocsComponent();
            groupdocsMetadata.set_downloadUrl("");
            groupdocsMetadata.set_downloadFileName("groupdocs.metadata.zip");
            groupdocsMetadata.set_name(Constants.GROUPDOCS_COMPONENT);
            groupdocsMetadata.set_remoteExamplesRepository("https://github.com/groupdocsmetadata/GroupDocs_Metadata_NET.git");
            list.Add(Constants.GROUPDOCS_COMPONENT, groupdocsMetadata);
        }
    }
}
