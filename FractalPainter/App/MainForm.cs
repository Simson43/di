﻿using System;
using System.Drawing;
using System.Windows.Forms;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;
using Ninject;

namespace FractalPainting.App
{
    public class MainForm : Form
    {
        public MainForm(IUiAction[] actions, PictureBoxImageHolder pictureBox, Palette palette, AppSettings appSettings)
        {
            var mainMenu = new MenuStrip();
            mainMenu.Items.AddRange(actions.ToMenuItems());
            Controls.Add(mainMenu);

            var imageSettings = appSettings.ImageSettings;
            ClientSize = new Size(imageSettings.Width, imageSettings.Height);

            pictureBox.RecreateImage(imageSettings);
            pictureBox.Dock = DockStyle.Fill;
            Controls.Add(pictureBox);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Text = "Fractal Painter";
        }
    }
}