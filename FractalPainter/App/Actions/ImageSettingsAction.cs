using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;

namespace FractalPainting.App.Actions
{
    public class ImageSettingsAction : IUiAction
    {
        private IImageHolder imageHolder;
        private AppSettings appSettings;

        public ImageSettingsAction(IImageHolder imageHolder, AppSettings appSettings)
        {
            this.imageHolder = imageHolder;
            this.appSettings = appSettings;
        }

        public CategoryType Category => CategoryType.Настройки;
        public string Name => "Изображение...";
        public string Description => "Размеры изображения";

        public void Perform()
        {
            SettingsForm.For(appSettings.ImageSettings).ShowDialog();
            imageHolder.RecreateImage(appSettings.ImageSettings);
        }
    }
}