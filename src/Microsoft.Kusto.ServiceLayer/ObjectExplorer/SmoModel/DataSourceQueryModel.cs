﻿// This file was generated by a T4 Template. Do not modify directly, instead update the SmoQueryModelDefinition.xml file
// and re-run the T4 template. This can be done in Visual Studio by right-click in and choosing "Run Custom Tool",
// or from the command-line on any platform by running "build.cmd -Target=CodeGen" or "build.sh -Target=CodeGen".

using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Broker;
using Microsoft.Kusto.ServiceLayer.DataSource;
using Microsoft.Kusto.ServiceLayer.Metadata.Contracts;

namespace Microsoft.Kusto.ServiceLayer.ObjectExplorer.DataSourceModel
{

    [Export(typeof(DataSourceQuerier))]
    internal partial class DatabaseQuerier: DataSourceQuerier
    {
        Type[] supportedTypes = new Type[] { typeof(Database) };

        public override Type[] SupportedObjectTypes { get { return supportedTypes; } }

        public override  IEnumerable<ObjectMetadata> Query(QueryContext context, string filter, bool refresh, IEnumerable<string> extraProperties)
        {
            if (context.KustoUtils != null)
            {
                return context.dataSource.GetDatabaseMetadata();
            }
            return Enumerable.Empty<ObjectMetadata>();
        }
    }

    [Export(typeof(DataSourceQuerier))]
    internal partial class TableQuerier: DataSourceQuerier
    {
        Type[] supportedTypes = new Type[] { typeof(Table) };

        public override Type[] SupportedObjectTypes { get { return supportedTypes; } }

        public override  IEnumerable<ObjectMetadata> Query(QueryContext context, string filter, bool refresh, IEnumerable<string> extraProperties)
        {
            if (context.Parent != null)
            {
                ValidationUtils.IsArgumentEqual(context.Parent.MetadataType, MetadataType.Database, nameof(context.Parent.MetadataType), StringComparer.Ordinal);
                return context.dataSource.GetTableMetadata(context.Parent.Name);
            }
            return Enumerable.Empty<ObjectMetadata>();
        }
    }

    

    [Export(typeof(DataSourceQuerier))]
    internal partial class ColumnQuerier: DataSourceQuerier
    {
        Type[] supportedTypes = new Type[] { typeof(Column) };

        public override Type[] SupportedObjectTypes { get { return supportedTypes; } }

        public override  IEnumerable<ObjectMetadata> Query(QueryContext context, string filter, bool refresh, IEnumerable<string> extraProperties)
        {
            if (context.Parent != null)
            {
                ValidationUtils.IsArgumentEqual(context.Parent.MetadataType, MetadataType.Table, nameof(context.Parent.MetadataType), StringComparer.Ordinal);
                return context.dataSource.GetColumnMetadata(context.Parent.Name);
            }
            return Enumerable.Empty<ObjectMetadata>();
        }
    }
}