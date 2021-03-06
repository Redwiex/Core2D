﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using Core2D.Containers;
using Core2D.Interfaces;
using Core2D.Shapes;
using Core2D.Style;

namespace Core2D.Editor.Tools.Selection
{
    /// <summary>
    /// Helper class for <see cref="IRectangleShape"/> shape selection.
    /// </summary>
    public class ToolRectangleSelection
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILayerContainer _layer;
        private readonly IRectangleShape _rectangle;
        private readonly IShapeStyle _style;
        private readonly IBaseShape _point;
        private IPointShape _topLeftHelperPoint;
        private IPointShape _bottomRightHelperPoint;

        /// <summary>
        /// Initialize new instance of <see cref="ToolRectangleSelection"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="layer">The selection shapes layer.</param>
        /// <param name="shape">The selected shape.</param>
        /// <param name="style">The selection shapes style.</param>
        /// <param name="point">The selection point shape.</param>
        public ToolRectangleSelection(IServiceProvider serviceProvider, ILayerContainer layer, IRectangleShape shape, IShapeStyle style, IBaseShape point)
        {
            _serviceProvider = serviceProvider;
            _layer = layer;
            _rectangle = shape;
            _style = style;
            _point = point;
        }

        /// <summary>
        /// Transfer selection state to BottomRight.
        /// </summary>
        public void ToStateBottomRight()
        {
            _topLeftHelperPoint = _serviceProvider.GetService<IFactory>().CreatePointShape(0, 0, _point);
            _bottomRightHelperPoint = _serviceProvider.GetService<IFactory>().CreatePointShape(0, 0, _point);

            _layer.Shapes = _layer.Shapes.Add(_topLeftHelperPoint);
            _layer.Shapes = _layer.Shapes.Add(_bottomRightHelperPoint);
        }

        /// <summary>
        /// Move selection.
        /// </summary>
        public void Move()
        {
            if (_topLeftHelperPoint != null)
            {
                _topLeftHelperPoint.X = _rectangle.TopLeft.X;
                _topLeftHelperPoint.Y = _rectangle.TopLeft.Y;
            }

            if (_bottomRightHelperPoint != null)
            {
                _bottomRightHelperPoint.X = _rectangle.BottomRight.X;
                _bottomRightHelperPoint.Y = _rectangle.BottomRight.Y;
            }

            _layer.Invalidate();
        }

        /// <summary>
        /// Remove selection.
        /// </summary>
        public void Remove()
        {
            if (_topLeftHelperPoint != null)
            {
                _layer.Shapes = _layer.Shapes.Remove(_topLeftHelperPoint);
                _topLeftHelperPoint = null;
            }

            if (_bottomRightHelperPoint != null)
            {
                _layer.Shapes = _layer.Shapes.Remove(_bottomRightHelperPoint);
                _bottomRightHelperPoint = null;
            }

            _layer.Invalidate();
        }
    }
}
