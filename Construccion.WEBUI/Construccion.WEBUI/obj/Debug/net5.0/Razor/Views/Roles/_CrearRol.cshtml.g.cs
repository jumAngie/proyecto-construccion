#pragma checksum "C:\Users\axel2\OneDrive\Documentos\proyecto-construccion\Construccion.WEBUI\Construccion.WEBUI\Views\Roles\_CrearRol.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07f5ea67504ebd5a1b008c2adc732eae9575d885"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Roles__CrearRol), @"mvc.1.0.view", @"/Views/Roles/_CrearRol.cshtml")]
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
#line 1 "C:\Users\axel2\OneDrive\Documentos\proyecto-construccion\Construccion.WEBUI\Construccion.WEBUI\Views\_ViewImports.cshtml"
using Construccion.WEBUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\axel2\OneDrive\Documentos\proyecto-construccion\Construccion.WEBUI\Construccion.WEBUI\Views\_ViewImports.cshtml"
using Construccion.WEBUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07f5ea67504ebd5a1b008c2adc732eae9575d885", @"/Views/Roles/_CrearRol.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81b24afac5b23230dacfa18b3fa7e6d5a1a9d7db", @"/Views/_ViewImports.cshtml")]
    public class Views_Roles__CrearRol : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""modal fade bd-example-modal-lg"" id=""ModalAcceso"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"" id=""myLargeModalLabel"">Permisos de Acceso de roles</h4>
                <button class=""btn-close"" type=""button"" data-bs-dismiss=""modal"" aria-label=""Close"" onclick=""LimpiarAcceso()""></button>
                <input type=""text"" name=""name""");
            BeginWriteAttribute("value", " value=\"", 687, "\"", 695, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""txtIdRol"" hidden/>
            </div>
            <div class=""modal-body"">
                <div class=""col-sm-12 col-xl-12"">
            <div class=""card"">
                <div class=""card-body"">
                    <div class=""row"">
                        <div class=""col-sm-4"">
                            <div class=""list-group"" id=""list-tab"" role=""tablist""><a class=""list-group-item list-group-item-action active"" id=""list-home-list"" data-bs-toggle=""list"" href=""#list-home"" role=""tab"" aria-controls=""list-home"">Generales</a><a class=""list-group-item list-group-item-action"" id=""list-profile-list"" data-bs-toggle=""list"" href=""#list-profile"" role=""tab"" aria-controls=""list-profile"">Construcción</a><a class=""list-group-item list-group-item-action"" id=""list-messages-list"" data-bs-toggle=""list"" href=""#list-messages"" role=""tab"" aria-controls=""list-messages"">Acceso</a></div>
                        </div>
                        <div class=""col-sm-8"">
                            <div class=""tab-content"" ");
            WriteLiteral(@"id=""nav-tabContent"">
                                <div class=""tab-pane fade show active"" id=""list-home"" role=""tabpanel"" aria-labelledby=""list-home-list"">
                                    <label>
                                        <input type=""checkbox"" id=""7"" class=""checkbox-animated"" value=""7"">
                                        Unidades de medida
                                    </label>
                                    <br>
                                    <label>
                                        <input type=""checkbox"" id=""3"" class=""checkbox-animated"" value=""3"">
                                        Cargos
                                    </label>
                                    <br>
                                </div>
                                <div class=""tab-pane fade"" id=""list-profile"" role=""tabpanel"" aria-labelledby=""list-profile-list"">
                                    <label>
                                        <input type=""checkb");
            WriteLiteral(@"ox"" id=""4"" class=""checkbox-animated"" value=""4"">
                                        Clientes
                                    </label>
                                    <br>
                                    <label>
                                        <input type=""checkbox"" id=""6"" class=""checkbox-animated"" value=""6"">
                                        Construcciones
                                    </label>
                                    <br>
                                    <label>
                                        <input type=""checkbox"" id=""8"" class=""checkbox-animated"" value=""8"">
                                        Insumos
                                    </label>
");
            WriteLiteral(@"                                    <br>
                                    <label>
                                        <input type=""checkbox"" id=""5"" class=""checkbox-animated"" value=""5"">
                                        Empleados
                                    </label>
                                </div>
                                <div class=""tab-pane fade"" id=""list-messages"" role=""tabpanel"" aria-labelledby=""list-messages-list"">
                                    <label>
                                        <input type=""checkbox"" id=""2"" class=""checkbox-animated"" value=""2"">
                                        Roles
                                    </label>
                                    <br>
                                    <label>
                                        <input type=""checkbox"" id=""1"" class=""checkbox-animated"" value=""1"">
                                        Usuarios
                                    </label>
                      ");
            WriteLiteral(@"          </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
            </div>
            <div class=""modal-footer"">
                <button class=""btn btn-primary"" type=""button"" data-bs-dismiss=""modal"" onclick=""LimpiarAcceso()"">Cerrar</button>
                <button class=""btn btn-secondary"" type=""button"" id=""btnAplicar"">Aplicar</button>
            </div>
        </div>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
