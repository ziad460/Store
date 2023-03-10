#pragma checksum "E:\ITI\Projects\ITI Final Project\Store\Store\Areas\Admin\Views\Product\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e68ce9a51105cad36b3f40d180973ee0cf4db70f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Product_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/Product/Details.cshtml")]
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
#line 1 "E:\ITI\Projects\ITI Final Project\Store\Store\Areas\Admin\Views\_ViewImports.cshtml"
using Store;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\ITI\Projects\ITI Final Project\Store\Store\Areas\Admin\Views\_ViewImports.cshtml"
using Store.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e68ce9a51105cad36b3f40d180973ee0cf4db70f", @"/Areas/Admin/Views/Product/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bf4e815b3c664a1a42b413716bf96a575e49a98", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Product_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Store.Models.Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("detailsimage"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Product Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-target", new global::Microsoft.AspNetCore.Html.HtmlString("#carouselExample"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\ITI\Projects\ITI Final Project\Store\Store\Areas\Admin\Views\Product\Details.cshtml"
  
    ViewData["Title"] = "Details";
    int counter = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"Details-Header\">\r\n    <h1> ");
#nullable restore
#line 9 "E:\ITI\Projects\ITI Final Project\Store\Store\Areas\Admin\Views\Product\Details.cshtml"
    Write(Model.Product_Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"'s Details </h1>
</div>

<br />

<div class=""container"">
    <div class=""row"">

        <div class=""col-lg-3 col-md-6 col-sm-12 bg-primary"">
            <div class=""product-info"">
                <h3>Number Of Sales</h3>
                <p>150</p>
            </div>
            <a");
            BeginWriteAttribute("href", " href=\"", 450, "\"", 457, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""product-info-small-box"">
                More Info
                <i class=""icon-long-arrow-right""></i>
            </a>
        </div>

        <div class=""col-lg-3 col-md-6 col-sm-12 bg-success"">
            <div class=""product-info"">
                <h3>Number Of Sales</h3>
                <p>150</p>
            </div>
            <a");
            BeginWriteAttribute("href", " href=\"", 816, "\"", 823, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""product-info-small-box"">
                More Info
                <i class=""icon-long-arrow-right""></i>
            </a>
        </div>

        <div class=""col-lg-3 col-md-6 col-sm-12 bg-warning"">
            <div class=""product-info"">
                <h3>Number Of Sales</h3>
                <p>150</p>
            </div>
            <a");
            BeginWriteAttribute("href", " href=\"", 1182, "\"", 1189, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""product-info-small-box"">
                More Info
                <i class=""icon-long-arrow-right""></i>
            </a>
        </div>

        <div class=""col-lg-3 col-md-6 col-sm-12 bg-danger"">
            <div class=""product-info"">
                <h3>Number Of Sales</h3>
                <p>150</p>
            </div>
            <a");
            BeginWriteAttribute("href", " href=\"", 1547, "\"", 1554, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""product-info-small-box"">
                More Info
                <i class=""icon-long-arrow-right""></i>
            </a>
        </div>

    </div>
</div>

<br />

<table class=""table table-bordered table-striped table-responsive"" style=""margin-top:20px"">
    <tr>
        <th>Product ID</th>
        <td>");
#nullable restore
#line 69 "E:\ITI\Projects\ITI Final Project\Store\Store\Areas\Admin\Views\Product\Details.cshtml"
       Write(Model.Product_ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <th>Product Name</th>\r\n        <td>");
#nullable restore
#line 73 "E:\ITI\Projects\ITI Final Project\Store\Store\Areas\Admin\Views\Product\Details.cshtml"
       Write(Model.Product_Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <th>Product Price</th>\r\n        <td>");
#nullable restore
#line 77 "E:\ITI\Projects\ITI Final Project\Store\Store\Areas\Admin\Views\Product\Details.cshtml"
       Write(Model.Product_Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <th>Product Color</th>\r\n        <td>");
#nullable restore
#line 81 "E:\ITI\Projects\ITI Final Project\Store\Store\Areas\Admin\Views\Product\Details.cshtml"
       Write(Model.Product_Color);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <th>Product Size</th>\r\n        <td>");
#nullable restore
#line 85 "E:\ITI\Projects\ITI Final Project\Store\Store\Areas\Admin\Views\Product\Details.cshtml"
       Write(Model.Product_Size);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <th>Product Description</th>\r\n        <td>");
#nullable restore
#line 89 "E:\ITI\Projects\ITI Final Project\Store\Store\Areas\Admin\Views\Product\Details.cshtml"
       Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <th>Product Category</th>\r\n        <td>");
#nullable restore
#line 93 "E:\ITI\Projects\ITI Final Project\Store\Store\Areas\Admin\Views\Product\Details.cshtml"
       Write(Model.Category.Category_Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <th>Available Quantity</th>\r\n        <td>");
#nullable restore
#line 97 "E:\ITI\Projects\ITI Final Project\Store\Store\Areas\Admin\Views\Product\Details.cshtml"
       Write(Model.Stored_Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <th>Nubmer Of Sales</th>\r\n        <td>");
#nullable restore
#line 101 "E:\ITI\Projects\ITI Final Project\Store\Store\Areas\Admin\Views\Product\Details.cshtml"
       Write(Model.Popularity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <th>Product Images</th>\r\n        <td>\r\n            <div class=\"container-fluid\">\r\n                <div class=\"row\" id=\"gallary\">\r\n");
#nullable restore
#line 108 "E:\ITI\Projects\ITI Final Project\Store\Store\Areas\Admin\Views\Product\Details.cshtml"
                     foreach (var item in Model.ProductsImages)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-lg-3 col-md-4 col-sm-12\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e68ce9a51105cad36b3f40d180973ee0cf4db70f10429", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3013, "~/images/Products/", 3013, 18, true);
#nullable restore
#line 111 "E:\ITI\Projects\ITI Final Project\Store\Store\Areas\Admin\Views\Product\Details.cshtml"
AddHtmlAttributeValue("", 3031, item.Image, 3031, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 111 "E:\ITI\Projects\ITI Final Project\Store\Store\Areas\Admin\Views\Product\Details.cshtml"
                                                                                                                                                              counter++;

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-slide-to", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 113 "E:\ITI\Projects\ITI Final Project\Store\Store\Areas\Admin\Views\Product\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </td>\r\n    </tr>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Store.Models.Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
