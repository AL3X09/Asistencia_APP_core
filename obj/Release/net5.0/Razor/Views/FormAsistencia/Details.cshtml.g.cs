#pragma checksum "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72b7d4dff0f7b1c680fed61cd55b6a585e069513"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FormAsistencia_Details), @"mvc.1.0.view", @"/Views/FormAsistencia/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "B:\NETAPPS\Asistencia_APP_core\Views\_ViewImports.cshtml"
using asistencia_rips_APP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "B:\NETAPPS\Asistencia_APP_core\Views\_ViewImports.cshtml"
using asistencia_rips_APP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72b7d4dff0f7b1c680fed61cd55b6a585e069513", @"/Views/FormAsistencia/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec2a718c0469e5258c6c800e4bc6856299ff616e", @"/Views/_ViewImports.cshtml")]
    public class Views_FormAsistencia_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<asistencia_rips_APP.Models.FormAsistenciaClass>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
  
    ViewData["Title"] = "Detalles Asistencia";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 13 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Consec));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 16 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayFor(model => model.Consec));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 19 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Fecha));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 22 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayFor(model => model.Fecha));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 25 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Nombres_contacto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 28 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayFor(model => model.Nombres_contacto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 31 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Apellidos_contacto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 34 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayFor(model => model.Apellidos_contacto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 37 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Datos_contacto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 40 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayFor(model => model.Datos_contacto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 43 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Acciones));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 46 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayFor(model => model.Acciones));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 49 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Compromisos));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 52 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayFor(model => model.Compromisos));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <!--<dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 55 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Firma));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n        ");
#nullable restore
#line 58 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
   Write(Html.DisplayFor(model => model.Firma));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>-->\r\n\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 62 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Tema));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 65 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayFor(model => model.Tema.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 68 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TipoAsistencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 71 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayFor(model => model.TipoAsistencia.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 74 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.EstadoTramite));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 77 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayFor(model => model.EstadoTramite.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 80 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 84 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.is_Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 87 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayFor(model => model.is_Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 90 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayFor(model => model.User.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 91 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
       Write(Html.DisplayFor(model => model.User.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "72b7d4dff0f7b1c680fed61cd55b6a585e06951312257", async() => {
                WriteLiteral("Editar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 96 "B:\NETAPPS\Asistencia_APP_core\Views\FormAsistencia\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    <!--<a asp-action=\"Index\">Regresar al listado</a>-->\r\n    <a onclick=\"history.back()\">Volver</a>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<asistencia_rips_APP.Models.FormAsistenciaClass> Html { get; private set; }
    }
}
#pragma warning restore 1591
