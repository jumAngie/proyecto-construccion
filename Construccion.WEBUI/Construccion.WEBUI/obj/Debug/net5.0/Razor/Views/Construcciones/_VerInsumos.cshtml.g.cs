#pragma checksum "C:\Users\axel2\OneDrive\Documentos\proyecto-construccion\Construccion.WEBUI\Construccion.WEBUI\Views\Construcciones\_VerInsumos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a02b8a6a2cd9a378da2c38017b5f7ac9604d1e1b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Construcciones__VerInsumos), @"mvc.1.0.view", @"/Views/Construcciones/_VerInsumos.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a02b8a6a2cd9a378da2c38017b5f7ac9604d1e1b", @"/Views/Construcciones/_VerInsumos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81b24afac5b23230dacfa18b3fa7e6d5a1a9d7db", @"/Views/_ViewImports.cshtml")]
    public class Views_Construcciones__VerInsumos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""modal fade bd-example-modal-lg"" tabindex=""-1"" id=""ModalInsumosPorConstruccion"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"" id=""myLargeModalLabel"">Insumos Por construccion</h4>
                <button class=""btn-close"" type=""button"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                <div class=""table table-responsive"">
                    <table class=""display"" id=""TableInsumos"">
                        <thead>
                            <tr>
                                <th>
                                    <span>Insumos Id</span>                                   
                                </th>
                                <th>
                                    <span>Insumos</span>                               ");
            WriteLiteral(@"    
                                </th>
                                <th>
                                    <span>
                                        Unidades de medida
                                    </span>
                                </th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>
            <div class=""modal-footer"">
                <button class=""btn btn-secondary"" type=""button"" data-bs-dismiss=""modal"">Cerrar</button>
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
