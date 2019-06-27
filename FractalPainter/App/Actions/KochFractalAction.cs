﻿using FractalPainting.App.Fractals;
using FractalPainting.Infrastructure.UiActions;

namespace FractalPainting.App.Actions
{
    public class KochFractalAction : IUiAction
    {
        KochPainter painter;

        public KochFractalAction(KochPainter painter)
        {
            this.painter = painter;
        }

        public CategoryType Category => CategoryType.Фракталы;
        public string Name => "Кривая Коха";
        public string Description => "Кривая Коха";

        public void Perform() => painter.Paint();
    }
}