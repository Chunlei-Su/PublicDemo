#pragma checksum "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0fb4c50bb896251ad82299bd66229448b92817d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_SellerChangeInfo), @"mvc.1.0.view", @"/Views/Home/SellerChangeInfo.cshtml")]
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
#line 1 "F:\ShoppingProject_V1.0\ShoppingProject\Views\_ViewImports.cshtml"
using ShoppingProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\ShoppingProject_V1.0\ShoppingProject\Views\_ViewImports.cshtml"
using ShoppingProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0fb4c50bb896251ad82299bd66229448b92817d6", @"/Views/Home/SellerChangeInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b9ef12efd708238457a5a8766dd1c899ce41b61", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_SellerChangeInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/customer.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "OutLogin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CustomerPage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateSellerInfo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("customerinfo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-md-9"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin: 0 auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 3 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
  
    ViewData["Title"] = "CustomerChangerInfo";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0fb4c50bb896251ad82299bd66229448b92817d67442", async() => {
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
            WriteLiteral("<div class=\"navbar-nav\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n");
            WriteLiteral("            <div class=\"col-md-12\">\r\n                <p style=\"display: inline-block\">便捷购物，幸福生活</p>\r\n");
#nullable restore
#line 16 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
                 if (ViewBag.CustomerName != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p style=\"display: inline-block; float: right\">\r\n                        <span>尊敬的：");
#nullable restore
#line 19 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
                             Write(ViewBag.CustomerName[0]);

#line default
#line hidden
#nullable disable
            WriteLiteral("&nbsp;</span>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0fb4c50bb896251ad82299bd66229448b92817d69480", async() => {
                WriteLiteral(" 退出登录");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </p>\r\n");
#nullable restore
#line 22 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"customer-title\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-10\" style=\"font-size: 25px;font-weight: bold\">修改店铺信息</div>\r\n");
#nullable restore
#line 32 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
             if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour < 11)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-2\" style=\"text-align: center;\">亲，上午好！</div>\r\n");
#nullable restore
#line 35 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
             if (DateTime.Now.Hour >= 11 && DateTime.Now.Hour < 13)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-2\" style=\"text-align: center;\">亲，中午好！</div>\r\n");
#nullable restore
#line 39 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
             if (DateTime.Now.Hour >= 13 && DateTime.Now.Hour < 18)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-2\" style=\"text-align: center;\">亲，下午好！</div>\r\n");
#nullable restore
#line 43 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
             if (DateTime.Now.Hour >= 18 && DateTime.Now.Hour < 24)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-2\" style=\"text-align: center;\">亲，晚上好！</div>\r\n");
#nullable restore
#line 47 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
             if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 6)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-2\" style=\"text-align: center;\">夜深了，晚安</div>\r\n");
#nullable restore
#line 51 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"container custchange-bg\">\r\n    <div class=\"col-md-12\">\r\n        <br />\r\n        <br />\r\n        <br />\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0fb4c50bb896251ad82299bd66229448b92817d613987", async() => {
                WriteLiteral(@"
            <div class=""col-md-12"">
                <div class=""form-group"">
                    <div class=""input-group mb-3"">
                        <div class=""input-group-append"">
                            <span class=""input-group-text"">LOGO</span>
                        </div>
                        <div class=""customer-head"" style=""margin-left: 10px;"">
                            <img");
                BeginWriteAttribute("src", " src=\"", 2465, "\"", 2501, 1);
#nullable restore
#line 70 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
WriteAttributeValue("", 2471, ViewBag.SellerInfo.SellerLogo, 2471, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" width=""100%"" height=""100%"" id=""seller-logo"" />
                        </div>
                        <input type=""file"" name=""sellerlogo"" class=""uploadhead"" id=""uplodelogo"" value=""上传头像"" />
                        <input type=""hidden"" id=""sellerlogodata"" name=""logodata""");
                BeginWriteAttribute("value", " value=\"", 2776, "\"", 2784, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
                        <span id=""tips"">(点击更换LOGO)</span>
                    </div>
                </div>
            </div>

            <div class=""col-md-12"">
                <div class=""form-group"">
                    <div class=""input-group mb-3"">
                        <div class=""input-group-append"">
                            <span class=""input-group-text"">帐&ensp;&ensp;号</span>
                        </div>
                        <input type=""text"" class=""form-control"" disabled=""disabled""");
                BeginWriteAttribute("name", " name=\"", 3309, "\"", 3316, 0);
                EndWriteAttribute();
                WriteLiteral(" maxlength=\"20\"");
                BeginWriteAttribute("value", " value=\"", 3332, "\"", 3372, 1);
#nullable restore
#line 85 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
WriteAttributeValue("", 3340, ViewBag.SellerInfo.SellerNumber, 3340, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" title=\"账号不可修改\">\r\n\r\n                        <input type=\"hidden\" class=\"form-control\" name=\"sellernumber\" maxlength=\"20\"");
                BeginWriteAttribute("value", " value=\"", 3493, "\"", 3533, 1);
#nullable restore
#line 87 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
WriteAttributeValue("", 3501, ViewBag.SellerInfo.SellerNumber, 3501, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" >
                    </div>
                </div>
            </div>

            <div class=""col-md-12"">
                <div class=""form-group"">
                    <div class=""input-group mb-3"">
                        <div class=""input-group-append"">
                            <span class=""input-group-text"">名&ensp;&ensp;称</span>
                        </div>
                        <input type=""text"" class=""form-control"" placeholder=""昵称"" id=""shopname"" name=""shopname"" maxlength=""20""");
                BeginWriteAttribute("value", " value=\"", 4040, "\"", 4076, 1);
#nullable restore
#line 98 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
WriteAttributeValue("", 4048, ViewBag.SellerInfo.ShopName, 4048, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                    </div>
                </div>
            </div>
            
            <div class=""col-md-12"">
                <div class=""form-group"">
                    <div class=""input-group mb-3"">
                        <div class=""input-group-append"">
                            <span class=""input-group-text"">地&ensp;&ensp;址</span>
                        </div>
                        <input type=""text"" class=""form-control"" placeholder=""地址"" id=""shopaddress"" name=""shopaddress"" maxlength=""20""");
                BeginWriteAttribute("value", " value=\"", 4600, "\"", 4639, 1);
#nullable restore
#line 109 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
WriteAttributeValue("", 4608, ViewBag.SellerInfo.ShopAddress, 4608, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n            <input type=\"hidden\" id=\"imgextpic\" name=\"imgextpic\"");
                BeginWriteAttribute("value", " value=\"", 4781, "\"", 4789, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n            <input type=\"hidden\" id=\"imgextlogo\" name=\"imgextlogo\"");
                BeginWriteAttribute("value", " value=\"", 4859, "\"", 4867, 0);
                EndWriteAttribute();
                WriteLiteral(@">

            <div class=""col-md-12"">
                <div class=""form-group"">
                    <div class=""input-group mb-3"">
                        <div class=""input-group-append"">
                            <span class=""input-group-text"">图&ensp;&ensp;片</span>
                        </div>
                        <div class=""customer-head"" style=""margin-left: 10px;"">
                            <img");
                BeginWriteAttribute("src", " src=\"", 5288, "\"", 5323, 1);
#nullable restore
#line 124 "F:\ShoppingProject_V1.0\ShoppingProject\Views\Home\SellerChangeInfo.cshtml"
WriteAttributeValue("", 5294, ViewBag.SellerInfo.SellerPic, 5294, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" width=""100%"" height=""100%"" id=""seller-pic"" />
                        </div>
                        <input type=""file"" name=""customerhead"" class=""uploadhead"" id=""uplodepic"" value=""上传头像"" />
                        <input type=""hidden"" id=""sellerpicdata"" name=""picdata""");
                BeginWriteAttribute("value", " value=\"", 5596, "\"", 5604, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
                        <span id=""tips"">(点击更换展示图片)</span>
                    </div>
                </div>
            </div>
            <br /><br />
            <div class=""row"" style=""text-align: center;"">
                <div class=""col-md-6""><button type=""submit"" class=""btn btn-danger"">提交修改</button></div>
                <div class=""col-md-6"">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0fb4c50bb896251ad82299bd66229448b92817d621176", async() => {
                    WriteLiteral("返回首页");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</div>\r\n            </div>\r\n\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
            WriteLiteral(@"<script>
    $(() => {
        //声明文件读取对象
        var readerlogo = new FileReader();
        var readerpic = new FileReader();
        //当读取到文件后进行赋值
        readerlogo.onload = function () {
            $(""#seller-logo"").attr(""src"", this.result);
            $(""#sellerlogodata"").val(this.result);
        };
        readerpic.onload = function () {
            $(""#seller-pic"").attr(""src"", this.result);
            $(""#sellerpicdata"").val(this.result);
        };

        //当选中文件后进行文件的读取
        $(""#uplodepic"").change(function () {
            var ext = this.files[0].name.split('.');
            if (ext[ext.length - 1] != 'jpg' && ext[ext.length - 1] != 'jpeg' && ext[ext.length - 1] != 'png') {
                alert(""请选择有效的文件！"");
                return;
            }
            $(""#imgextpic"").val(ext[ext.length - 1]);
            readerpic.readAsDataURL(this.files[0]);
        });

        $(""#uplodelogo"").change(function () {
            var ext = this.files[0].name.split('.');
  ");
            WriteLiteral(@"          if (ext[ext.length - 1] != 'jpg' && ext[ext.length - 1] != 'jpeg' && ext[ext.length - 1] != 'png') {
                alert(""请选择有效的文件！"");
                return;
            }
            $(""#imgextlogo"").val(ext[ext.length - 1]);
            readerlogo.readAsDataURL(this.files[0]);
        });
        //{
        ////检查电话号码格式
        //jQuery.validator.addMethod(""CheckTel"", function (value, element) {
        //    var mobile = /^[1][3,4,5,7,8][0-9]{9}$/;
        //    return mobile.test(value);
        //}, ""您的号码格式有误"");

        ////检查昵称是否重复
        //jQuery.validator.addMethod(""CheckName"",
        //    function (value, element) {
        //        //如果没改名，就不用去搜索是否重复
        //        if ($(""#CustomerNowName"").val() == value)
        //            return true;
        //        //为了避免每输入一个字符就执行一次数据库检查名称请求，在此获取这个元素的焦点状态
        //        var isFocus = $(""#"" + element.id).is("":focus"");
        //        var boo = true;
        //        //只有当该元素失去焦点的时候才会执行检查请求
        //     ");
            WriteLiteral(@"   if (!isFocus) {
        //            $.ajax({
        //                url: ""/Home/CheckCustomerName"",
        //                type: ""POST"",
        //                async: false,
        //                dataType: ""json"",
        //                data: { CustName: value },
        //                success: function (data) {
        //                    if (data === true) {
        //                        boo = false;
        //                        return;
        //                    }
        //                    boo = true;
        //                }
        //            });
        //            return boo;
        //        }
        //        return true;

        //    }, ""昵称已被使用""
        //);

        //$('#customerinfo').validate({
        //    //设置验证失败时存放错误提示的标签
        //    errorElement: 'span',
        //    //设置标签用到的样式
        //    errorClass: 'invalid-feedback',
        //    //设置验证用的规则
        //    rules: {
        //        CustomerName: {");
            WriteLiteral(@"
        //            required: true,
        //            CheckName: true
        //        },
        //        CustomerTel: {
        //            required: true,
        //            CheckTel: true,
        //            minlength: 11
        //        }
        //    },
        //    //设置验证失败的错误提示
        //    messages: {
        //        CustomerName: {
        //            required: ""此项必填""
        //        },
        //        CustomerTel: {
        //            required: ""此项必填"",
        //            minlength: ""电话长度固定为11位""

        //        },
        //    },
        //    //验证失败触发的事件
        //    errorPlacement: function (error, element) {
        //        element.next().remove(); //删除显示图标
        //        element.after(
        //            '<span class=""glyphicon form-control-feedback invalid-feedback"" aria-hidden=""true""></span>'
        //        );
        //        element.parent().append(error);
        //    },
        //    //设置高亮显示的事件
        //  ");
            WriteLiteral(@"  highlight: function (element) {
        //        $(element)
        //            .closest('.form-group')
        //            .find('input')
        //            .addClass('is-invalid');
        //    },
        //    //验证成功的事件
        //    success: function (label) {
        //        var el = label.closest('.form-group').find('input');
        //        el.next().remove(); //与errorPlacement相似
        //        el.after('<span class=""glyphicon form-control-feedback valid-feedback"" aria-hidden=""true""></span>');
        //        el.removeClass('is-invalid').addClass('is-valid');
        //    }
            //});
        //}
    })

</script>");
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
