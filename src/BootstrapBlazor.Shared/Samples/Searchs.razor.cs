﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Shared.Common;
using BootstrapBlazor.Shared.Components;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace BootstrapBlazor.Shared.Samples;

/// <summary>
/// 
/// </summary>
public sealed partial class Searchs
{
    private static IEnumerable<string> Items => new string[] { "1", "12", "123", "1234" };

    [NotNull]
    private BlockLogger? Trace { get; set; }

    [NotNull]
    private BlockLogger? Trace2 { get; set; }

    [NotNull]
    private BlockLogger? Trace3 { get; set; }

    [NotNull]
    private BlockLogger? Trace4 { get; set; }

    private Task OnSearch1(string searchText)
    {
        Trace.Log($"SearchText: {searchText}");
        return Task.CompletedTask;
    }

    private Task OnSearch2(string searchText)
    {
        Trace2.Log($"SearchText: {searchText}");
        return Task.CompletedTask;
    }

    private Task OnSearch3(string searchText)
    {
        Trace3.Log($"SearchText: {searchText}");
        return Task.CompletedTask;
    }

    private Task OnSearch4(string searchText)
    {
        Trace4.Log($"SearchText: {searchText}");
        return Task.CompletedTask;
    }

    private Task OnClear(string searchText)
    {
        Trace3.Log($"OnClear: {searchText}");
        return Task.CompletedTask;
    }

    /// <summary>
    /// 获得属性方法
    /// </summary>
    /// <returns></returns>
    private static IEnumerable<AttributeItem> GetAttributes() => new AttributeItem[]
    {
            // TODO: 移动到数据库中
            new AttributeItem() {
                Name = "ChildContent",
                Description = "内容",
                Type = "RenderFragment",
                ValueList = " — ",
                DefaultValue = " — "
            },
            new AttributeItem() {
                Name = "Items",
                Description = "内容",
                Type = "IEnumerable<string>",
                ValueList = " — ",
                DefaultValue = " — "
            },
            new AttributeItem() {
                Name = "NoDataTip",
                Description = "自动完成数据无匹配项时提示信息",
                Type = "string",
                ValueList = " — ",
                DefaultValue = "无匹配数据"
            },
            new AttributeItem()
            {
                Name="SearchButtonLoadingIcon",
                Description = "正在搜索按钮图标",
                Type = "string",
                ValueList = " — ",
                DefaultValue = "fa fa-fw fa-spinner fa-spin"
            },
            new AttributeItem() {
                Name = "ClearButtonIcon",
                Description = "清空按钮图标",
                Type = "string",
                ValueList = " — ",
                DefaultValue = "fa fa-trash"
            },
            new AttributeItem() {
                Name = "ClearButtonText",
                Description = "清空按钮文本",
                Type = "string",
                ValueList = " — ",
                DefaultValue = " — "
            },
            new AttributeItem() {
                Name = "ClearButtonColor",
                Description = "清空按钮颜色",
                Type = "Color",
                ValueList = " — ",
                DefaultValue = "Secondary"
            },
            new AttributeItem() {
                Name = "SearchButtonColor",
                Description = "搜索按钮颜色",
                Type = "Color",
                ValueList = " — ",
                DefaultValue = "Primary"
            },
            new AttributeItem() {
                Name = "IsLikeMatch",
                Description = "是否开启模糊匹配",
                Type = "bool",
                ValueList = "true|false",
                DefaultValue = "false"
            },
            new AttributeItem() {
                Name = "IsAutoFocus",
                Description = "是否自动获得焦点",
                Type = "bool",
                ValueList = "true|false",
                DefaultValue = "false"
            },
            new AttributeItem() {
                Name = "IsAutoClearAfterSearch",
                Description = "点击搜索后是否自动清空搜索框",
                Type = "bool",
                ValueList = "true|false",
                DefaultValue = "false"
            },
            new AttributeItem() {
                Name = "IsOnInputTrigger",
                Description = "搜索模式是否为输入即触发,默认点击搜索按钮触发",
                Type = "bool",
                ValueList = "true|false",
                DefaultValue = "false"
            },
            new AttributeItem()
            {
                Name = "IgnoreCase",
                Description = "匹配时是否忽略大小写",
                Type = "bool",
                ValueList = "true|false",
                DefaultValue = "true"
            },
            new AttributeItem()
            {
                Name = "ShowClearButton",
                Description = "是否显示清除按钮",
                Type = "bool",
                ValueList = "true|false",
                DefaultValue = "false"
            },
            new AttributeItem()
            {
                Name="OnSearch",
                Description = "点击搜索时回调此委托",
                Type = "Func<string, Task>",
                ValueList = " — ",
                DefaultValue = " — "
            },
            new AttributeItem()
            {
                Name="OnClear",
                Description = "点击清空时回调此委托",
                Type = "Func<string, Task>",
                ValueList = " — ",
                DefaultValue = " — "
            }
    };
}
