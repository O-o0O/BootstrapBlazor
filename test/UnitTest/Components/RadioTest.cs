// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Components;
using Bunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Core;
using Xunit;

namespace UnitTest.Components;

public class RadioTest : BootstrapBlazorTestBase
{
    [Fact]
    public void Color_Ok()
    {
        var items = new List<SelectedItem>()
        {
            new SelectedItem("0","选项一"),
            new SelectedItem("1","选项二")
        };

        var cut = Context.RenderComponent<RadioList<string>>(builder =>
        {
            builder.Add(p => p.Color, Color.Primary);
            builder.Add(p => p.Items, items);
        });

        Assert.Contains("form-check-primary", cut.Markup);
    }

    [Fact]
    public void IsAutoAddNullItem_Ok()
    {
        var items = new List<SelectedItem>()
        {
            new SelectedItem("0","选项一"),
            new SelectedItem("1","选项二")
        };

        var cut = Context.RenderComponent<RadioList<string>>(builder =>
        {
            builder.Add(p => p.IsAutoAddNullItem, true);
            builder.Add(p => p.NullItemText, "Null Value");
            builder.Add(p => p.Items, items);
        });
    }

    [Fact]
    public void IsVertical_Ok()
    {
        var items = new List<SelectedItem>()
        {
            new SelectedItem("0","选项一"),
            new SelectedItem("1","选项二")
        };

        var cut = Context.RenderComponent<RadioList<string>>(builder =>
        {
            builder.Add(p => p.IsVertical, true);
            builder.Add(p => p.Items, items);
        });

        Assert.Contains("is-vertical", cut.Markup);
    }

    [Fact]
    public void IsDisabled_Ok()
    {
        var items = new List<SelectedItem>()
        {
            new SelectedItem("0","选项一"),
            new SelectedItem("1","选项二")
        };

        var cut = Context.RenderComponent<RadioList<string>>(builder =>
        {
            builder.Add(p => p.IsDisabled, true);
            builder.Add(p => p.Items, items);
        });

        Assert.Contains("disabled", cut.Markup);
    }

    [Fact]
    public void ShowBorder_Ok()
    {
        var items = new List<SelectedItem>()
        {
            new SelectedItem("0","选项一"),
            new SelectedItem("1","选项二")
        };

        var cut = Context.RenderComponent<RadioList<string>>(builder =>
        {
            builder.Add(p => p.ShowBorder, false);
            builder.Add(p => p.Items, items);
        });

        Assert.Contains("no-border", cut.Markup);
    }

    [Fact]
    public void OnSelectedChanged_Ok()
    {
        var items = new List<SelectedItem>()
        {
            new SelectedItem("0","选项一"),
            new SelectedItem("1","选项二")
        };
        var ret = "";
        var cut = Context.RenderComponent<RadioList<string>>(builder =>
        {
            builder.Add(p => p.OnSelectedChanged, (e, v) =>
            {
                ret = v;
                return Task.CompletedTask;
            });
            builder.Add(p => p.Items, items);
        });

        cut.FindAll(".form-check-input").First().Click();

        Assert.NotEmpty(ret);
    }

    [Fact]
    public void IsShowLabel_Ok()
    {
        var items = new List<SelectedItem>()
        {
            new SelectedItem("0","选项一"),
            new SelectedItem("1","选项二")
        };

        var cut = Context.RenderComponent<RadioList<string>>(builder =>
        {
            builder.Add(p => p.ShowLabel, true);
            builder.Add(p => p.DisplayText, "RadioList Label");
            builder.Add(p => p.Items, items);
        });

        Assert.Contains("RadioList Label", cut.Markup);
    }
}
