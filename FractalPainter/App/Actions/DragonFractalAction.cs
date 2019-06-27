using System;
using FractalPainting.App.Fractals;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;

namespace FractalPainting.App.Actions
{
    public class DragonFractalAction : IUiAction
    {
        private IDragonPainterFactory dragonPainterFactory;
        private Func<DragonSettingsGenerator> generatorFactory;

        public DragonFractalAction(IDragonPainterFactory dragonPainterFactory, Func<DragonSettingsGenerator> generatorFactory)
        {
            this.dragonPainterFactory = dragonPainterFactory;
            this.generatorFactory = generatorFactory;
        }

        public CategoryType Category => CategoryType.Фракталы;
        public string Name => "Дракон";
        public string Description => "Дракон Хартера-Хейтуэя";

        public void Perform()
        {
            var dragonSettings = generatorFactory().Generate();
            SettingsForm.For(dragonSettings).ShowDialog();
            dragonPainterFactory.CreateDragonPainter(dragonSettings).Paint();
        }
    }
}