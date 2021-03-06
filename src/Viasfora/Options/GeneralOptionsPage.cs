﻿using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Winterdom.Viasfora.Rainbow;

namespace Winterdom.Viasfora.Options {
  [Guid(Guids.GeneralOptions)]
  public class GeneralOptionsPage : DialogPage {

    public override void SaveSettingsToStorage() {
      base.SaveSettingsToStorage();
      var settings = SettingsContext.GetSettings();
      var rainbowSettings = SettingsContext.GetSpecificSettings<IRainbowSettings>();

      settings.CurrentLineHighlightEnabled = CurrentLineHighlightEnabled;
      settings.CurrentColumnHighlightEnabled = CurrentColumnHighlightEnabled;
      settings.HighlightLineWidth = this.HighlightLineWidth;
      settings.KeywordClassifierEnabled = KeywordClassifierEnabled;
      settings.FlowControlUseItalics = FlowControlUseItalics;
      settings.EscapeSequencesEnabled = EscapeSeqHighlightEnabled;
      settings.DeveloperMarginEnabled = DevMarginEnabled;
      settings.AutoExpandRegions = AutoExpandRegions;
      settings.BoldAsItalicsEnabled = BoldAsItalicsEnabled;
      settings.ModelinesEnabled = ModelinesEnabled;
      settings.ModelinesNumLines = (int)ModelinesNumLines;
      settings.TelemetryEnabled = TelemetryEnabled;
      settings.Save();
    }
    public override void LoadSettingsFromStorage() {
      base.LoadSettingsFromStorage();
      var settings = SettingsContext.GetSettings();

      CurrentLineHighlightEnabled = settings.CurrentLineHighlightEnabled;
      CurrentColumnHighlightEnabled = settings.CurrentColumnHighlightEnabled;
      highlightLineWidth = settings.HighlightLineWidth;
      KeywordClassifierEnabled = settings.KeywordClassifierEnabled;
      FlowControlUseItalics = settings.FlowControlUseItalics;
      EscapeSeqHighlightEnabled = settings.EscapeSequencesEnabled;
      DevMarginEnabled = settings.DeveloperMarginEnabled;
      AutoExpandRegions = settings.AutoExpandRegions;
      BoldAsItalicsEnabled = settings.BoldAsItalicsEnabled;
      ModelinesEnabled = settings.ModelinesEnabled;
      ModelinesNumLines = (uint)settings.ModelinesNumLines;
      TelemetryEnabled = settings.TelemetryEnabled;
    }

    // General Settings
    [LocDisplayName("Enable Telemetry")]
    [Description("Enable sending telemetry about Viasfora usage. Will only take effect after a restart.")]
    [Category("General")]
    public bool TelemetryEnabled { get; set; }

    // Text Editor Extensions
    [LocDisplayName("Enable Keyword Classifier")]
    [Description("Enable custom keyword highlighting for C#, CPP and JS")]
    [Category("Text Editor")]
    public bool KeywordClassifierEnabled { get; set; }
    [LocDisplayName("Use italics on Flow Control Keywords")]
    [Description("Use italics on text highlighted by the Keyword Classifier")]
    [Category("Text Editor")]
    public bool FlowControlUseItalics { get; set; }


    [LocDisplayName("Highlight Escape Sequences")]
    [Description("Enable highlighting of escape sequences in strings")]
    [Category("Text Editor")]
    public bool EscapeSeqHighlightEnabled { get; set; }

    [LocDisplayName("Highlight Current Line")]
    [Description("Enables highlighting the current line in the text editor")]
    [Category("Text Editor")]
    public bool CurrentLineHighlightEnabled { get; set; }

    [LocDisplayName("Highlight Current Column")]
    [Description("Enables highlighting the current column in the text editor")]
    [Category("Text Editor")]
    public bool CurrentColumnHighlightEnabled { get; set; }

    private double highlightLineWidth;
    [LocDisplayName("Highlight Line Width")]
    [Description("Defines the thickness of the current line/column highlight")]
    [Category("Text Editor")]
    public double HighlightLineWidth {
      get { return this.highlightLineWidth; }
      set {
        if ( value <= 0.0 ) {
          throw new ArgumentOutOfRangeException("Value must be greater than 0");
        }
        this.highlightLineWidth = value;
      }
    }


    [LocDisplayName("Enable Developer Margin")]
    [Description("Enables the VS text editor extension developer margin")]
    [Category("Text Editor")]
    public bool DevMarginEnabled { get; set; }


    [LocDisplayName("Expand Regions on Open")]
    [Description("Automatically expand collapsible regions when a new text view is opened")]
    [Category("Text Editor")]
    public Outlining.AutoExpandMode AutoExpandRegions { get; set; }

    [LocDisplayName("Enable 'Bold As Italics'")]
    [Description("Render bold fonts using italics instead")]
    [Category("Text Editor")]
    public bool BoldAsItalicsEnabled { get; set; }


    // Modelines Configuration
    [LocDisplayName("Enable Modelines Support")]
    [Description("Enables the use of Vim-style modelines to configure the text editor")]
    [Category("Modelines")]
    public bool ModelinesEnabled { get; set; }

    [LocDisplayName("Lines to Check")]
    [Description("Number of lines to check for modeline commands")]
    [Category("Modelines")]
    public uint ModelinesNumLines {get; set; }
  }
}
