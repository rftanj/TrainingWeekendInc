#pragma checksum "F:\.NET\TRAINING WEEKEND INC\WebCMSTraining\Views\Category\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "072e110845a2df309e7cdcb6bc6134091f67f240"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Category_Index), @"mvc.1.0.view", @"/Views/Category/Index.cshtml")]
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
#line 1 "F:\.NET\TRAINING WEEKEND INC\WebCMSTraining\Views\_ViewImports.cshtml"
using WebCMSTraining;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\.NET\TRAINING WEEKEND INC\WebCMSTraining\Views\_ViewImports.cshtml"
using WebCMSTraining.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"072e110845a2df309e7cdcb6bc6134091f67f240", @"/Views/Category/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e82eb0ea571af0200db00ce1ee436ad022f31f0c", @"/Views/_ViewImports.cshtml")]
    public class Views_Category_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("DeleteCate"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "F:\.NET\TRAINING WEEKEND INC\WebCMSTraining\Views\Category\Index.cshtml"
  
    Layout = "_AdminLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div class=\"col text-right\">\r\n    <a");
            BeginWriteAttribute("href", " href=\"", 873, "\"", 921, 1);
#nullable restore
#line 20 "F:\.NET\TRAINING WEEKEND INC\WebCMSTraining\Views\Category\Index.cshtml"
WriteAttributeValue("", 880, Url.Action("CreateCategory", "Category"), 880, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary mb-3\">\r\n        Add Category\r\n    </a>\r\n</div>\r\n");
#nullable restore
#line 24 "F:\.NET\TRAINING WEEKEND INC\WebCMSTraining\Views\Category\Index.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-12"">
        <table id=""tablecategory"">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Category Name</th>
                    <th>Status</th>
                    <th>Update</th>
                    <th>Delete</th>
                </tr>
            </thead>
");
            WriteLiteral("        </table>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "072e110845a2df309e7cdcb6bc6134091f67f2405216", async() => {
                WriteLiteral("\r\n            <input type=\"hidden\" name=\"Id\" id=\"CekDelete\" style=\"display:none\">\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 49 "F:\.NET\TRAINING WEEKEND INC\WebCMSTraining\Views\Category\Index.cshtml"
AddHtmlAttributeValue("", 2041, Url.Action("DeleteCategory", "Category"), 2041, 41, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script>
        $(document).ready(function ()
        {
            $(""#tablecategory"").DataTable({

                processing: true, // for show progress bar
                serverSide: true, // for process server side
                filter: true, // this is for disable filter (search box)
                orderMulti: false, // for disable multiple column at once
                searching: true,

                ajax: {
                    url: ""/Category/LoadDataCategory"",
                    type: ""POST"",
                    dataType: ""json"",
                    headers: {
                        'RequestVerificationToken': $('input[name=""__RequestVerificationToken""]').val()
                    }
                },

                columnDefs: [
                        {
                            ""defaultContent"" : ""-"",
                            ""targets"": [0],
                            ""visible"": false,
                            ""searchable"": false
             ");
                WriteLiteral(@"           }
                 ],

                columns: [
                    {
                        ""data"": ""id"",
                        ""name"": ""id"",
                        ""autoWidth"": true
                    },
                    {
                        ""data"": ""categoryName"",
                        ""name"": ""categoryName"",
                        ""autoWidth"": true
                    },
                    {
                        ""data"": ""status"",
                        ""name"": ""status"",
                        ""autoWidth"": true
                    },
                    {
                        ""render"": function (data, type, full, meta) {
                            return '<a class=""btn btn-sm btn-primary"" href=""/Category/UpdateCategory?id=' + full.id + '""> Update </a>';
                        }
                    },
                    {
                        ""data"": null,
                        ""render"": function(data, type, row) {
                    ");
                WriteLiteral(@"        return ""<a href='#' class='btn btn-sm btn-danger' onclick=DeleteData('"" + row.id + ""'); > Delete </a>"";
                        }
                    },
                ]
            });
        });


        function DeleteData(id)
        {
            if (confirm(""Delete This Data?""))
            {
                Delete(id);
            }
            else
            {
                return false;
            }
        }


        function Delete(id)
        {
            var url = '");
#nullable restore
#line 147 "F:\.NET\TRAINING WEEKEND INC\WebCMSTraining\Views\Category\Index.cshtml"
                  Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"' + ""Category/DeleteCategory"";

            $.post(url, { ID: id }, function(data) {
                if (data)
                {
                    oTable = $('#tablecategory').DataTable();
                    oTable.draw();
                }
                else {
                    alert(""Something Went Wrong!"");
                }
            });
        }
    </script>

");
            }
            );
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
