using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Pharmalto.Ecosystem {
    public class Migrations : DataMigrationImpl {

        public int Create() {

            SchemaBuilder.CreateTable("EcoUserPartRecord", table => table
                .ContentPartRecord()
                .Column<int>("UserId")
                );

            ContentDefinitionManager.AlterPartDefinition("EcoUserPart", part => part
               .Attachable(false)
               );

            ContentDefinitionManager.AlterTypeDefinition("User", type => type
                .WithPart("EcoUserPart")
                );

            return 1;
        }

        public int UpdateFrom1 () {
            SchemaBuilder.CreateTable("HealthViewWidgetPartRecord", table => table
                .ContentPartRecord()
                .Column<string>("Mode")
                );

            ContentDefinitionManager.AlterPartDefinition("HealthViewWidgetPart", part => part
               .Attachable()
               );

            ContentDefinitionManager.AlterTypeDefinition("HealthViewWidget", type => type
                .WithPart("HealthViewWidgetPart")
                .WithPart("CommonPart")
                .WithPart("WidgetPart")
                .WithSetting("Stereotype", "Widget")
                );
            return 2;
        }

        public int UpdateFrom2() {
            SchemaBuilder.CreateTable("EcoProfilePartRecord", table => table
                .ContentPartRecord()
                .Column<int>("ProfileId")
                );

            ContentDefinitionManager.AlterPartDefinition("ProfilePlatePart", part => part
                .Attachable());

            ContentDefinitionManager.AlterTypeDefinition("ProfilePlate", type => type
                .WithPart("ProfilePlatePart")
                .WithPart("CommonPart")
                .WithPart("WidgetPart")
                .WithSetting("Stereotype", "Widget")
                );

            return 3;
        }

        public int UpdateFrom3() {
            SchemaBuilder.CreateTable("StorageSettingsPartRecord",
                table => table
                    .ContentPartRecord()
                    .Column<string>("AccountName")
                    .Column<string>("AccountKey")
                );

            return 4;
        }
    }
}