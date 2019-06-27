﻿using System.IO;
using System.Windows.Forms;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;

namespace FractalPainting.App.Actions
{
    public class SaveImageAction : IUiAction
    {
        private IImageDirectoryProvider imageDirectoryProvider;
        private IImageHolder imageHolder;

        public SaveImageAction(IImageDirectoryProvider imageDirectoryProvider, IImageHolder imageHolder)
        {
            this.imageDirectoryProvider = imageDirectoryProvider;
            this.imageHolder = imageHolder;
        }

        public CategoryType Category => CategoryType.Файл;
        public string Name => "Сохранить...";
        public string Description => "Сохранить изображение в файл";

        public void Perform()
        {
            var dialog = new SaveFileDialog
            {
                CheckFileExists = false,
                InitialDirectory = Path.GetFullPath(imageDirectoryProvider.ImagesDirectory),
                DefaultExt = "bmp",
                FileName = "image.bmp",
                Filter = "Изображения (*.bmp)|*.bmp" 
            };
            var res = dialog.ShowDialog();
            if (res == DialogResult.OK)
                imageHolder.SaveImage(dialog.FileName);
        }
    }
}