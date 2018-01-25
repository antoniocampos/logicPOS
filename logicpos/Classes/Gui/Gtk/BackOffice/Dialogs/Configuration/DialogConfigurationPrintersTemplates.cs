﻿using Gtk;
using logicpos.datalayer.DataLayer.Xpo;
using logicpos.App;
using logicpos.Classes.Gui.Gtk.WidgetsGeneric;
using logicpos.resources.Resources.Localization;
using logicpos.Classes.Gui.Gtk.Widgets.BackOffice;

namespace logicpos.Classes.Gui.Gtk.BackOffice
{
    class DialogConfigurationPrintersTemplates : BOBaseDialog
    {
        public DialogConfigurationPrintersTemplates(Window pSourceWindow, GenericTreeViewXPO pTreeView, DialogFlags pFlags, DialogMode pDialogMode, XPGuidObject pXPGuidObject)
            : base(pSourceWindow, pTreeView, pFlags, pDialogMode, pXPGuidObject)
        {
            this.Title = Utils.GetWindowTitle(Resx.window_title_edit_dialogconfigurationprinterstype);
            SetSizeRequest(500, 500);
            InitUI();
            InitNotes();
            ShowAll();
        }

        private void InitUI()
        {
            try
            {
                //Tab1
                VBox vboxTab1 = new VBox(false, _boxSpacing) { BorderWidth = (uint)_boxSpacing };

                //Ord
                Entry entryOrd = new Entry();
                BOWidgetBox boxLabel = new BOWidgetBox(Resx.global_record_order, entryOrd);
                vboxTab1.PackStart(boxLabel, false, false, 0);
                _crudWidgetList.Add(new GenericCRUDWidgetXPO(boxLabel, _dataSourceRow, "Ord", SettingsApp.RegexIntegerGreaterThanZero, true));

                //Code
                Entry entryCode = new Entry();
                BOWidgetBox boxCode = new BOWidgetBox(Resx.global_record_code, entryCode);
                vboxTab1.PackStart(boxCode, false, false, 0);
                _crudWidgetList.Add(new GenericCRUDWidgetXPO(boxCode, _dataSourceRow, "Code", SettingsApp.RegexIntegerGreaterThanZero, true));

                //Designation
                Entry entryDesignation = new Entry();
                BOWidgetBox boxDesignation = new BOWidgetBox(Resx.global_designation, entryDesignation);
                vboxTab1.PackStart(boxDesignation, false, false, 0);
                _crudWidgetList.Add(new GenericCRUDWidgetXPO(boxDesignation, _dataSourceRow, "Designation", SettingsApp.RegexAlfa, true));

                //FileTemplate
                FileChooserButton fileChooserFileTemplate = new FileChooserButton(string.Empty, FileChooserAction.Open) { HeightRequest = 23 };
                Image fileChooserImagePreviewFileTemplate = new Image() { WidthRequest = _sizefileChooserPreview.Width, HeightRequest = _sizefileChooserPreview.Height };
                Frame fileChooserFrameImagePreviewFileTemplate = new Frame();
                fileChooserFrameImagePreviewFileTemplate.ShadowType = ShadowType.None;
                fileChooserFrameImagePreviewFileTemplate.Add(fileChooserImagePreviewFileTemplate);
                fileChooserFileTemplate.SetFilename(((SYS_ConfigurationPrintersTemplates)DataSourceRow).FileTemplate);
                fileChooserFileTemplate.Filter = Utils.GetFileFilterTemplates();
                fileChooserFileTemplate.SelectionChanged += (sender, eventArgs) => fileChooserImagePreviewFileTemplate.Pixbuf = Utils.ResizeAndCropFileToPixBuf((sender as FileChooserButton).Filename, new System.Drawing.Size(fileChooserImagePreviewFileTemplate.WidthRequest, fileChooserImagePreviewFileTemplate.HeightRequest));
                BOWidgetBox boxfileChooserFileTemplate = new BOWidgetBox(Resx.global_file, fileChooserFileTemplate);
                HBox hboxfileChooserAndimagePreviewFileTemplate = new HBox(false, _boxSpacing);
                hboxfileChooserAndimagePreviewFileTemplate.PackStart(boxfileChooserFileTemplate, true, true, 0);
                hboxfileChooserAndimagePreviewFileTemplate.PackStart(fileChooserFrameImagePreviewFileTemplate, false, false, 0);
                vboxTab1.PackStart(hboxfileChooserAndimagePreviewFileTemplate, false, false, 0);
                _crudWidgetList.Add(new GenericCRUDWidgetXPO(boxfileChooserFileTemplate, _dataSourceRow, "FileTemplate", string.Empty, false));

                //FinancialTemplate
                CheckButton checkButtonFinancialTemplate = new CheckButton(Resx.global_financialtemplate);
                vboxTab1.PackStart(checkButtonFinancialTemplate, false, false, 0);
                _crudWidgetList.Add(new GenericCRUDWidgetXPO(checkButtonFinancialTemplate, _dataSourceRow, "FinancialTemplate"));

                //Disabled
                CheckButton checkButtonDisabled = new CheckButton(Resx.global_record_disabled);
                if (_dialogMode == DialogMode.Insert) checkButtonDisabled.Active = SettingsApp.BOXPOObjectsStartDisabled;
                vboxTab1.PackStart(checkButtonDisabled, false, false, 0);
                _crudWidgetList.Add(new GenericCRUDWidgetXPO(checkButtonDisabled, _dataSourceRow, "Disabled"));

                //Append Tab
                _notebook.AppendPage(vboxTab1, new Label(Resx.global_record_main_detail));
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
            }
        }
    }
}


