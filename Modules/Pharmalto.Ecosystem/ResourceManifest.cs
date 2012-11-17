using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.UI.Resources;

namespace Pharmalto.Ecosystem
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest.DefineStyle("Pharmalto.Common").SetUrl("common.css");
            manifest.DefineScript("jquery-file-upload").SetUrl("jquery.fileupload.js").SetVersion("5.19.3").SetDependencies("jQuery");
            manifest.DefineScript("jquery-ui-widget").SetUrl("jquery.ui.widget.js").SetVersion("1.9.1").SetDependencies("jQuery");
            manifest.DefineScript("jquery-iframe-transport").SetUrl("jquery.iframe-transport.js").SetVersion("1.5").SetDependencies("jQuery");
        }
    }
}