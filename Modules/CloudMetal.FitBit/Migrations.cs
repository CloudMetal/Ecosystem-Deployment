using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace CloudMetal.FitBit
{
    public class Migrations : DataMigrationImpl
    {
        public int Create() {
            SchemaBuilder.CreateTable("OAuthSettingsRecord", table => table
                .ContentPartRecord()
                .Column<string>("ClientId")
                .Column<string>("ClientSecret")
                );

            ContentDefinitionManager.AlterPartDefinition("OAuthSettingsPart", part => part
               .Attachable(false)
               );

            SchemaBuilder.CreateTable("FitBitWidgetPartRecord", table => table
                .ContentPartRecord()
                .Column<DateTime>("ActivitiesDate")
                );

            ContentDefinitionManager.AlterPartDefinition("FitBitWidgetPart", part => part
                .Attachable()
                );

            return 1;
        }

        public int UpdateFrom1() {
            ContentDefinitionManager.AlterTypeDefinition("FitBitWidget", type => type
                .WithPart("WidgetPart")
                .WithPart("CommonPart")
                    .WithPart("FitBitWidgetPart")
                    .WithSetting("Stereotype", "Widget")
                );
            return 2;
        }
    }
}