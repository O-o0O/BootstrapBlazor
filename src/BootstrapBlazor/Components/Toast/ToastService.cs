﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace BootstrapBlazor.Components;

/// <summary>
/// Toast 弹出窗服务类
/// </summary>
public class ToastService : BootstrapServiceBase<ToastOption>, IDisposable
{
    private readonly IDisposable _optionsReloadToken;
    private BootstrapBlazorOptions _option;

    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="option"></param>
    public ToastService(IOptionsMonitor<BootstrapBlazorOptions> option)
    {
        _option = option.CurrentValue;
        _optionsReloadToken = option.OnChange(op => _option = op);
    }

    /// <summary>
    /// Show 方法
    /// </summary>
    /// <param name="option"></param>
    /// <param name="toast">指定弹窗组件 默认为 null 使用 <see cref="BootstrapBlazorRoot"/> 组件内置弹窗组件</param>
    public async Task Show(ToastOption option, Toast? toast = null)
    {
        if (!option.ForceDelay && _option.ToastDelay != 0)
        {
            option.Delay = _option.ToastDelay;
        }
        await Invoke(option, toast);
    }

    /// <summary>
    /// Toast 调用成功快捷方法
    /// </summary>
    /// <param name="title">Title 属性</param>
    /// <param name="content">Content 属性</param>
    /// <param name="autoHide">自动隐藏属性默认为 true</param>
    /// <returns></returns>
    public Task Success(string? title = null, string? content = null, bool autoHide = true) => Show(new ToastOption()
    {
        Category = ToastCategory.Success,
        IsAutoHide = autoHide,
        Title = title ?? "",
        Content = content ?? ""
    });

    /// <summary>
    /// Toast 调用错误快捷方法
    /// </summary>
    /// <param name="title"></param>
    /// <param name="content"></param>
    /// <param name="autoHide"></param>
    /// <returns></returns>
    public Task Error(string? title = null, string? content = null, bool autoHide = true) => Show(new ToastOption()
    {
        Category = ToastCategory.Error,
        IsAutoHide = autoHide,
        Title = title ?? "",
        Content = content ?? ""
    });

    /// <summary>
    /// Toast 调用提示信息快捷方法
    /// </summary>
    /// <param name="title"></param>
    /// <param name="content"></param>
    /// <param name="autoHide"></param>
    /// <returns></returns>
    public Task Information(string? title = null, string? content = null, bool autoHide = true) => Show(new ToastOption()
    {
        Category = ToastCategory.Information,
        IsAutoHide = autoHide,
        Title = title ?? "",
        Content = content ?? ""
    });

    /// <summary>
    /// Toast 调用警告信息快捷方法
    /// </summary>
    /// <param name="title"></param>
    /// <param name="content"></param>
    /// <param name="autoHide"></param>
    /// <returns></returns>
    public Task Warning(string? title = null, string? content = null, bool autoHide = true) => Show(new ToastOption()
    {
        Category = ToastCategory.Warning,
        IsAutoHide = autoHide,
        Title = title ?? "",
        Content = content ?? ""
    });

    /// <summary>
    /// 
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _optionsReloadToken.Dispose();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
