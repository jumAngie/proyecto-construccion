#pragma checksum "C:\Users\axel2\OneDrive\Documentos\proyecto-construccion\Construccion.WEBUI\Construccion.WEBUI\Views\Login\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01a681a51906160ee9964bd297a749590c238153"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Index), @"mvc.1.0.view", @"/Views/Login/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01a681a51906160ee9964bd297a749590c238153", @"/Views/Login/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81b24afac5b23230dacfa18b3fa7e6d5a1a9d7db", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/toastr.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ValidarSesion", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Validaciones y otros/Login.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/toastr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/toastr.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_CambiarContra", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\axel2\OneDrive\Documentos\proyecto-construccion\Construccion.WEBUI\Construccion.WEBUI\Views\Login\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01a681a51906160ee9964bd297a749590c2381536924", async() => {
                WriteLiteral(@"
    <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <meta name=""description"" content=""Cuba admin is super flexible, powerful, clean &amp; modern responsive bootstrap 5 admin template with unlimited possibilities."">
    <meta name=""keywords"" content=""admin template, Cuba admin template, dashboard template, flat admin template, responsive admin template, web app"">
    <meta name=""author"" content=""pixelstrap"">
    <link rel=""icon"" href=""Content/images/favicon.png"" type=""image/x-icon"">
    <link rel=""shortcut icon"" href=""Content/images/favicon.png"" type=""image/x-icon"">
    <title>Cuba - Premium Admin Template</title>
    <!-- Google font-->
    <link href=""https://fonts.googleapis.com/css?family=Rubik:400,400i,500,500i,700,700i&amp;display=swap"" rel=""stylesheet"">
    <link href=""https://fonts.googleapis.com/css?family=Roboto:300,300i,400,400i,500");
                WriteLiteral(@",500i,700,700i,900&amp;display=swap"" rel=""stylesheet"">
    <link rel=""stylesheet"" type=""text/css"" href=""Content/css/font-awesome.css"">
    <!-- ico-font-->
    <link rel=""stylesheet"" type=""text/css"" href=""Content/css/vendors/icofont.css"">
    <!-- Themify icon-->
    <link rel=""stylesheet"" type=""text/css"" href=""Content/css/vendors/themify.css"">
    <!-- Flag icon-->
    <link rel=""stylesheet"" type=""text/css"" href=""Content/css/vendors/flag-icon.css"">
    <!-- Feather icon-->
    <link rel=""stylesheet"" type=""text/css"" href=""Content/css/vendors/feather-icon.css"">
    <!-- Plugins css start-->
    <!-- Plugins css Ends-->
    <!-- Bootstrap css-->
    <link rel=""stylesheet"" type=""text/css"" href=""Content/css/vendors/bootstrap.css"">
    <!-- App css-->
    <link rel=""stylesheet"" type=""text/css"" href=""Content/css/style.css"">
    <link id=""color"" rel=""stylesheet"" href=""Content/css/color-1.css"" media=""screen"">
    <!-- Responsive css-->
    <link rel=""stylesheet"" type=""text/css"" href=""Content/css/res");
                WriteLiteral("ponsive.css\">\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "01a681a51906160ee9964bd297a749590c2381539419", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01a681a51906160ee9964bd297a749590c23815311305", async() => {
                WriteLiteral(@"
    <!-- login page start-->
    <div class=""container-fluid p-0"">
        <div class=""row m-0"">
            <div class=""col-12 p-0"">
                <div class=""login-card"">
                    <div>
                        <div><a class=""logo"" href=""index.html""><img class=""img-fluid for-light"" src=""Content/images/logo/login.png"" alt=""looginpage""><img class=""img-fluid for-dark"" src=""../assets/images/logo/logo_dark.png"" alt=""looginpage""></a></div>
                        <div class=""login-main"">
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01a681a51906160ee9964bd297a749590c23815312126", async() => {
                    WriteLiteral("\r\n                                <h4>Iniciar Sesión</h4>\r\n                                ");
#nullable restore
#line 54 "C:\Users\axel2\OneDrive\Documentos\proyecto-construccion\Construccion.WEBUI\Construccion.WEBUI\Views\Login\Index.cshtml"
                           Write(Html.ValidationMessage("ErrorSesion", new { @class = "text-danger", @style = "font-size:14px;" }));

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"
                                <div class=""form-group"">
                                    <label class=""col-form-label"">Usuario</label>
                                    <input type=""text"" id=""txtUserSes"" name=""user_NombreUsuario"" class=""form-control mb-3"" placeholder=""Usuario"" />
                                    ");
#nullable restore
#line 58 "C:\Users\axel2\OneDrive\Documentos\proyecto-construccion\Construccion.WEBUI\Construccion.WEBUI\Views\Login\Index.cshtml"
                               Write(Html.ValidationMessage("ErrorSesion1", new { @class = "text-danger", @style = "font-size:14px;" }));

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"
                                </div>
                                <br />
                                <div class=""form-group"">
                                    <label class=""col-form-label"">Contraseña</label>
                                    <div class=""form-input position-relative"">
                                        <input type=""password"" id=""txtPasswordSes"" name=""user_Contrasena"" class=""form-control mb-1"" placeholder=""Contraseña"" />
                                        ");
#nullable restore
#line 65 "C:\Users\axel2\OneDrive\Documentos\proyecto-construccion\Construccion.WEBUI\Construccion.WEBUI\Views\Login\Index.cshtml"
                                   Write(Html.ValidationMessage("ErrorSesion2", new { @class = "text-danger", @style = "font-size:14px;" }));

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"
                                    </div>
                                </div>
                                <br />
                                <div class=""form-group mb-0"">
                                    <a class=""link"" onclick=""AbrirModal()"">¿Olvido su contraseña?</a>
                                    <div class=""text-end mt-3"">
                                        <button class=""btn btn-primary btn-block w-100"" type=""submit"">Iniciar Sesión</button>
                                    </div>
                                </div>
                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <!-- latest jquery-->\r\n        <script src=\"Content/js/jquery-3.5.1.min.js\"></script>\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01a681a51906160ee9964bd297a749590c23815316784", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01a681a51906160ee9964bd297a749590c23815317888", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01a681a51906160ee9964bd297a749590c23815318992", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
        <!-- Bootstrap js-->
        <script src=""Content/js/bootstrap/bootstrap.bundle.min.js""></script>
        <!-- feather icon js-->
        <script src=""Content/js/icons/feather-icon/feather.min.js""></script>
        <script src=""Content/js/icons/feather-icon/feather-icon.js""></script>
        <!-- scrollbar js-->
        <!-- Sidebar jquery-->
        <script src=""Content/js/config.js""></script>
        <!-- Plugins JS start-->
        <!-- Plugins JS Ends-->
        <!-- Theme js-->
        <script src=""Content/js/script.js""></script>
        <!-- login js-->
        <!-- Plugin used-->
        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "01a681a51906160ee9964bd297a749590c23815320721", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 102 "C:\Users\axel2\OneDrive\Documentos\proyecto-construccion\Construccion.WEBUI\Construccion.WEBUI\Views\Login\Index.cshtml"
          
            if (ViewBag.Sesion == "Sesion" && ViewBag.Sesion != "")
            {
                string var1 = ViewBag.User;
                string var2 = ViewBag.Contra;

#line default
#line hidden
#nullable disable
                WriteLiteral("                <script>\r\n                $(\"#txtUserSes\").val(\'");
#nullable restore
#line 108 "C:\Users\axel2\OneDrive\Documentos\proyecto-construccion\Construccion.WEBUI\Construccion.WEBUI\Views\Login\Index.cshtml"
                                 Write(var1);

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n                $(\"#txtPasswordSes\").val(\'");
#nullable restore
#line 109 "C:\Users\axel2\OneDrive\Documentos\proyecto-construccion\Construccion.WEBUI\Construccion.WEBUI\Views\Login\Index.cshtml"
                                     Write(var2);

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n                </script>\r\n");
#nullable restore
#line 111 "C:\Users\axel2\OneDrive\Documentos\proyecto-construccion\Construccion.WEBUI\Construccion.WEBUI\Views\Login\Index.cshtml"
            }
            if (ViewBag.Cambiar != "" && ViewBag.Cambiar != null)
            {
                string Mensaje = ViewBag.MensajeCambia;

#line default
#line hidden
#nullable disable
                WriteLiteral("                <script>\r\n                    MostrarMensajeSuccess(\'");
#nullable restore
#line 116 "C:\Users\axel2\OneDrive\Documentos\proyecto-construccion\Construccion.WEBUI\Construccion.WEBUI\Views\Login\Index.cshtml"
                                      Write(Mensaje);

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n                </script>\r\n");
#nullable restore
#line 118 "C:\Users\axel2\OneDrive\Documentos\proyecto-construccion\Construccion.WEBUI\Construccion.WEBUI\Views\Login\Index.cshtml"
            }
            if (ViewBag.MensajeRestablecer != "" && ViewBag.MensajeRestablecer != null)
            {
                string Mensaje2 = ViewBag.MensajeRestablecer;

#line default
#line hidden
#nullable disable
                WriteLiteral("                <script>\r\n                    MostrarMensajeSuccess(\'");
#nullable restore
#line 123 "C:\Users\axel2\OneDrive\Documentos\proyecto-construccion\Construccion.WEBUI\Construccion.WEBUI\Views\Login\Index.cshtml"
                                      Write(Mensaje2);

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n                </script>\r\n");
#nullable restore
#line 125 "C:\Users\axel2\OneDrive\Documentos\proyecto-construccion\Construccion.WEBUI\Construccion.WEBUI\Views\Login\Index.cshtml"
            }
        

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
