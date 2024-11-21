// <copyright file="ErrorDetail.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace FishyFlip.Models;

/// <summary>
/// Represents an atError detail.
/// </summary>
public record ErrorDetail(string Error, string Message)
{
}