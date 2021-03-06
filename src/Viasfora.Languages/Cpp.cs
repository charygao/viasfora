﻿using System;
using System.ComponentModel.Composition;
using Winterdom.Viasfora.Contracts;
using Winterdom.Viasfora.Languages.Sequences;
using Winterdom.Viasfora.Util;

namespace Winterdom.Viasfora.Languages {
  [Export(typeof(ILanguage))]
  class Cpp : CBasedLanguage {
    public const String ContentType = "C/C++";
    static readonly String[] CPP_KEYWORDS = {
         "if", "else", "while", "do", "for", "each", "switch",
         "break", "continue", "return", "goto", "throw"
      };
    static readonly String[] CPP_VIS_KEYWORDS = {
         "public", "private", "protected", "internal", "friend"
      };
    protected override String[] ControlFlowDefaults {
      get { return CPP_KEYWORDS; }
    }
    protected override String[] LinqDefaults {
      get { return new String[0]; }
    }
    protected override String[] VisibilityDefaults {
      get { return CPP_VIS_KEYWORDS; }
    }
    public override String KeyName {
      get { return Constants.Cpp; }
    }
    protected override String[] SupportedContentTypes {
      get { return new String[] { ContentType }; }
    }

    [ImportingConstructor]
    public Cpp(IVsfSettings settings) : base(settings) {
    }

    public override IStringScanner NewStringScanner(string text) {
      return new CStringScanner(text);
    }
  }
}
