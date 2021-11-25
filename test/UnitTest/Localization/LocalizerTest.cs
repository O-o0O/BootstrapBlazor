﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Components;
using BootstrapBlazor.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;
using UnitTest.Core;
using Xunit;

namespace UnitTest.Localization
{
    public class LocalizerZhTest : BootstrapBlazorTestBase
    {
        private IStringLocalizer<Foo> Localizer { get; }

        public LocalizerZhTest()
        {
            Localizer = Context.Services.GetRequiredService<IStringLocalizer<Foo>>();
        }

        [Fact]
        public void Foo_Json_Ok()
        {
            var foo = Foo.Generate(Localizer);

            Assert.Equal("张三 1000", foo.Name);
        }

        [Fact]
        public void Dummy_Resource_Ok()
        {
            var val = Utility.GetDisplayName(typeof(Dummy), nameof(Dummy.Name));
            Assert.Equal("姓名", val);

            var model = new Dummy() { Name = "Name", Address = "Address" };
            val = Utility.GetDisplayName(model, nameof(Dummy.Address));
            Assert.Equal("Address1", val);
            Assert.Equal("Name", model.Name);
            Assert.Equal("Address", model.Address);
        }

        class Dummy
        {
            [Display(Name = "Name1")]
            public string? Name { get; set; }

            [Display(Name = "Address1")]
            public string? Address { get; set; }
        }
    }

    #region 英文资源文件
    public class LocalizerEnTest : BootstrapBlazorEnTestBase
    {
        private IStringLocalizer<Foo> Localizer { get; }

        public LocalizerEnTest()
        {
            Localizer = Context.Services.GetRequiredService<IStringLocalizer<Foo>>();
        }

        [Fact]
        public void Foo_Json_Ok()
        {
            var foo = Foo.Generate(Localizer);

            Assert.Equal("Zhangsan 1000", foo.Name);
        }

        [Fact]
        public void Dummy_Resource_Ok()
        {
            var val = Utility.GetDisplayName(typeof(DummyEn), nameof(DummyEn.Name));
            Assert.Equal("TestName", val);

            var model = new DummyEn() { Name = "Name", Address = "Address" };
            val = Utility.GetDisplayName(model, nameof(DummyEn.Address));
            Assert.Equal("Address1", val);
            Assert.Equal("Name", model.Name);
            Assert.Equal("Address", model.Address);
        }

        class DummyEn
        {
            [Display(Name = "Name1")]
            public string? Name { get; set; }

            [Display(Name = "Address1")]
            public string? Address { get; set; }
        }
    }
    #endregion
}
