﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System.Collections.Generic;

namespace Dock.Model
{
    /// <summary>
    /// Dock factory contract.
    /// </summary>
    public interface IDockFactory
    {
        /// <summary>
        /// Updates windows.
        /// </summary>
        /// <param name="windows">The windows to update.</param>
        /// <param name="context">The context object.</param>
        void UpdateWindows(IList<IDockWindow> windows, object context);

        /// <summary>
        /// Updates views.
        /// </summary>
        /// <param name="views">The views to update.</param>
        /// <param name="context">The context object.</param>
        void UpdateViews(IList<IDock> views, object context);

        /// <summary>
        /// Updates layout.
        /// </summary>
        /// <param name="layout">The layout to update.</param>
        /// <param name="context">The context object.</param>
        void UpdateLayout(IDock layout, object context);

        /// <summary>
        /// Creates dock window from view.
        /// </summary>
        /// <param name="layout">The owner layout.</param>
        /// <param name="context">The context object.</param>
        /// <param name="source">The source layout.</param>
        /// <param name="viewIndex">The view layout.</param>
        /// <param name="x">The X coordinate of window.</param>
        /// <param name="y">The Y coordinate of window.</param>
        /// <returns>The new instance of the <see cref="IDockWindow"/> class.</returns>
        IDockWindow CreateDockWindow(IDock layout, object context, IDock source, int viewIndex, double x, double y);

        /// <summary>
        /// Creates default layout.
        /// </summary>
        /// <param name="context">The context object.</param>
        /// <returns>The new instance of the <see cref="IDock"/> class.</returns>
        IDock CreateDefaultLayout(object context);

        /// <summary>
        /// Creates or updates current layout.
        /// </summary>
        void CreateOrUpdateLayout();
    }
}
