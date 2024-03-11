﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ATDD.V2.Exercise.CSharp.Specs.Features.API
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Order")]
    [NUnit.Framework.CategoryAttribute("api-login")]
    [NUnit.Framework.CategoryAttribute("db")]
    public partial class OrderFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "api-login",
                "db"};
        
#line 1 "Order.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Specs/Features/API", "Order", null, ProgrammingLanguage.CSharp, new string[] {
                        "api-login",
                        "db"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("订单列表")]
        public virtual void 订单列表()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("订单列表", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 5
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "code",
                            "productName",
                            "total",
                            "recipientName",
                            "status"});
                table1.AddRow(new string[] {
                            "SN001",
                            "电脑",
                            "19999",
                            "张三",
                            "toBeDelivered"});
#line 6
        testRunner.Given("存在如下订单:", ((string)(null)), table1, "Given ");
#line hidden
#line 9
        testRunner.When("API查询订单时", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 10
        testRunner.Then("返回如下订单", "  [{\r\n    \"code\": \"SN001\",\r\n    \"productName\": \"电脑\",\r\n    \"total\": 19999.00,\r\n   " +
                        " \"status\": \"toBeDelivered\"\r\n  }]", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("订单详情 - 无物流")]
        public virtual void 订单详情_无物流()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("订单详情 - 无物流", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 20
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "code",
                            "productName",
                            "total",
                            "recipientName",
                            "recipientMobile",
                            "recipientAddress",
                            "status"});
                table2.AddRow(new string[] {
                            "SN001",
                            "电脑",
                            "19999",
                            "张三",
                            "13085901735",
                            "上海市长宁区",
                            "toBeDelivered"});
#line 21
        testRunner.Given("存在如下订单:", ((string)(null)), table2, "Given ");
#line hidden
#line 24
        testRunner.When("API查询订单\"SN001\"详情时", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 25
        testRunner.Then("返回如下订单", "  {\r\n    \"code\": \"SN001\",\r\n    \"productName\": \"电脑\",\r\n    \"total\": 19999.0,\r\n    \"" +
                        "recipientName\": \"张三\",\r\n    \"recipientMobile\": \"13085901735\",\r\n    \"recipientAddr" +
                        "ess\": \"上海市长宁区\",\r\n    \"status\": \"toBeDelivered\"\r\n  }", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("订单发货")]
        public virtual void 订单发货()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("订单发货", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 38
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "code",
                            "productName",
                            "total",
                            "recipientName",
                            "recipientMobile",
                            "recipientAddress",
                            "status"});
                table3.AddRow(new string[] {
                            "SN001",
                            "电脑",
                            "19999",
                            "张三",
                            "13085901735",
                            "上海市长宁区",
                            "toBeDelivered"});
#line 39
        testRunner.Given("存在如下订单:", ((string)(null)), table3, "Given ");
#line hidden
#line 42
        testRunner.And("当前时间为\"2000-05-10T20:00:00Z\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 43
        testRunner.When("通过API发货订单\"SN001\"，快递单号为\"SF001\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 44
        testRunner.Then("订单\"SN001\"已发货，发货时间为\"2000-05-10T20:00:00Z\"，快递单号为\"SF001\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("订单详情 - 查询物流")]
        public virtual void 订单详情_查询物流()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("订单详情 - 查询物流", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 46
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "code",
                            "productName",
                            "total",
                            "recipientName",
                            "recipientMobile",
                            "recipientAddress",
                            "status",
                            "deliverNo",
                            "deliveredAt"});
                table4.AddRow(new string[] {
                            "SN001",
                            "电脑",
                            "19999",
                            "张三",
                            "13085901735",
                            "上海市长宁区",
                            "delivering",
                            "4313751158896",
                            "2022-02-26 16:25:01"});
#line 47
        testRunner.Given("存在如下订单:", ((string)(null)), table4, "Given ");
#line hidden
#line 50
        testRunner.And("存在快递单\"4313751158896\"的物流信息如下", @"{
    ""status"": 0,
    ""msg"": ""ok"",
    ""result"": {
        ""number"": ""4313751158896"",
        ""type"": ""yunda"",
        ""typename"": ""韵达快运"",
        ""logo"": ""https://api.jisuapi.com/express/static/images/logo/80/yunda.png"",
        ""list"": [
            {
                ""time"": ""2021-04-16 23:51:55"",
                ""status"": ""【潍坊市】已离开 山东潍坊分拨中心；发往 成都东地区包""
            },
            {
                ""time"": ""2021-04-16 23:45:47"",
                ""status"": ""【潍坊市】已到达 山东潍坊分拨中心""
            },
            {
                ""time"": ""2021-04-16 16:47:35"",
                ""status"": ""【潍坊市】山东青州市公司-赵良涛(13606367012) 已揽收""
            }
        ],
        ""deliverystatus"": 1,
        ""issign"": 0
    }
}", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 79
        testRunner.When("API查询订单\"SN001\"详情时", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 80
        testRunner.Then("返回如下订单", @"  {
    ""code"": ""SN001"",
    ""productName"": ""电脑"",
    ""total"": 19999.0,
    ""recipientName"": ""张三"",
    ""recipientMobile"": ""13085901735"",
    ""recipientAddress"": ""上海市长宁区"",
    ""status"": ""delivering"",
    ""deliveredAt"": ""2022-02-26 16:25:01"",
    ""logistics"": {
        ""deliverNo"": ""4313751158896"",
        ""companyCode"": ""yunda"",
        ""companyName"": ""韵达快运"",
        ""companyLogo"": ""https://api.jisuapi.com/express/static/images/logo/80/yunda.png"",
        ""details"": [
            {
                ""time"": ""2021-04-16 23:51:55"",
                ""status"": ""【潍坊市】已离开 山东潍坊分拨中心；发往 成都东地区包""
            },
            {
                ""time"": ""2021-04-16 23:45:47"",
                ""status"": ""【潍坊市】已到达 山东潍坊分拨中心""
            },
            {
                ""time"": ""2021-04-16 16:47:35"",
                ""status"": ""【潍坊市】山东青州市公司-赵良涛(13606367012) 已揽收""
            }
        ],
        ""deliveryStatus"": ""在途中"",
        ""isSigned"": ""未签收""
    }
  }", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
