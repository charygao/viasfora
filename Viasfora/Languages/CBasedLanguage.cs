﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Winterdom.Viasfora.Languages.BraceExtractors;
using Winterdom.Viasfora.Languages.CommentParsers;
using Winterdom.Viasfora.Languages.Sequences;
using Winterdom.Viasfora.Rainbow;
using Winterdom.Viasfora.Util;

namespace Winterdom.Viasfora.Languages {
  public abstract class CBasedLanguage : LanguageInfo {

    public CBasedLanguage(IVsfSettings settings) : base(settings) {
    }
    public override IBraceExtractor NewBraceExtractor() {
      return new CBraceExtractor();
    }
    public override IStringParser NewStringParser(String text) {
      return new CStringParser(text);
    }
  }
}
