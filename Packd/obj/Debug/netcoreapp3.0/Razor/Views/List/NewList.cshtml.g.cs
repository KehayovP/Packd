#pragma checksum "C:\Users\kehay\source\repos\Packd\Packd\Views\List\NewList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cfb9ba92043df3b127fc347a3db135866e0beac0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_List_NewList), @"mvc.1.0.view", @"/Views/List/NewList.cshtml")]
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
#line 1 "C:\Users\kehay\source\repos\Packd\Packd\Views\_ViewImports.cshtml"
using Packd;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\kehay\source\repos\Packd\Packd\Views\_ViewImports.cshtml"
using Packd.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfb9ba92043df3b127fc347a3db135866e0beac0", @"/Views/List/NewList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c02d48ad31095612c61924121411613157e8fb28", @"/Views/_ViewImports.cshtml")]
    public class Views_List_NewList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/NewList.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\kehay\source\repos\Packd\Packd\Views\List\NewList.cshtml"
  
    ViewData["Title"] = "NewList";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"text-center mb-3\">Create a New List</h1>\r\n\r\n<div id=\"DefaultListContent\" class=\"w-50 float-left mb-2\">\r\n\r\n    <h3 class=\"text-center w-75\">");
#nullable restore
#line 10 "C:\Users\kehay\source\repos\Packd\Packd\Views\List\NewList.cshtml"
                            Write(ViewBag.DefaultListContent.ListName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n");
#nullable restore
#line 12 "C:\Users\kehay\source\repos\Packd\Packd\Views\List\NewList.cshtml"
     foreach (var category in ViewBag.DefaultListContent.Categories)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <ul class=\"list-group w-75 mr-auto ml-auto\"");
            BeginWriteAttribute("id", " id=\"", 370, "\"", 395, 1);
#nullable restore
#line 14 "C:\Users\kehay\source\repos\Packd\Packd\Views\List\NewList.cshtml"
WriteAttributeValue("", 375, category.CategoryId, 375, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <li");
            BeginWriteAttribute("id", " id=\"", 414, "\"", 448, 2);
            WriteAttributeValue("", 419, "category-", 419, 9, true);
#nullable restore
#line 15 "C:\Users\kehay\source\repos\Packd\Packd\Views\List\NewList.cshtml"
WriteAttributeValue("", 428, category.CategoryId, 428, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"list-group-item active category-li\">");
#nullable restore
#line 15 "C:\Users\kehay\source\repos\Packd\Packd\Views\List\NewList.cshtml"
                                                                                         Write(category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n\r\n");
#nullable restore
#line 17 "C:\Users\kehay\source\repos\Packd\Packd\Views\List\NewList.cshtml"
             foreach (var item in category.Items)
            {
                string IsPacked = @item.IsPacked ? "checked" : "";
                

#line default
#line hidden
#nullable disable
            WriteLiteral("<li");
            BeginWriteAttribute("id", " id=\"", 677, "\"", 699, 2);
            WriteAttributeValue("", 682, "item-", 682, 5, true);
#nullable restore
#line 20 "C:\Users\kehay\source\repos\Packd\Packd\Views\List\NewList.cshtml"
WriteAttributeValue("", 687, item.ItemId, 687, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"list-group-item\">");
#nullable restore
#line 20 "C:\Users\kehay\source\repos\Packd\Packd\Views\List\NewList.cshtml"
                                                              Write(item.ItemName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <input class=\"float-right add-default-item\" type=\"button\" value=\"+\"></li>\r\n");
#nullable restore
#line 21 "C:\Users\kehay\source\repos\Packd\Packd\Views\List\NewList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </ul>\r\n        <br />\r\n        <br />\r\n");
#nullable restore
#line 26 "C:\Users\kehay\source\repos\Packd\Packd\Views\List\NewList.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <br />
    <br />
</div>

<div id=""NewListContentDiv"" class=""w-50 float-right mb-2"">

    <div class=""form-group"" id=""NewListNameFieldDiv"">
        <input type=""text"" class=""form-control"" id=""NewListNameField"" placeholder=""List name goes here ..."" required>
        <input type=""button"" name=""CreateNewListButton"" id=""CreateNewListButton"" value=""Create"" class=""btn btn-success float-right mt-1"" />
    </div>



    <div id=""NewListContent"">
        <h3 class=""text-center w-75"" id=""NewListName""></h3>

        <div class=""form-group"" id=""NewCategoryDiv"">
            <input type=""text"" class=""form-control"" id=""NewCategoryField"" placeholder=""Cateogry name goes here ..."" required>
            <input type=""button"" name=""CreateNewCategoryButton"" id=""CreateNewCategoryButton"" value=""Create Category"" class=""btn btn-success float-right mt-1"" />
        </div>
        <br />
        <br />

        <div id=""PredefinedCategories"">
        </div>

        <div id=""CustomCategories"">
        </");
            WriteLiteral("div>\r\n\r\n        <div id=\"SaveListDiv\">\r\n            <br />\r\n            <br />\r\n            <button type=\"button\" class=\"btn btn-primary btn-lg btn-block\" id=\"SaveListButton\">Save List</button>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cfb9ba92043df3b127fc347a3db135866e0beac08430", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
