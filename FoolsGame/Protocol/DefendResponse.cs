using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    public enum WhatMove//английский ужасен, но я не знаю, как это. пока что понятными НЕПРАВИЛЬНЫМИ!!! словами
    {
        Defend,
        Translate,
        Take
    }
    public class DefendInfo
    {
        public List<Card> BeatenCards;
        public List<Card> PlayerHand;//аналогично не понимаю, зачем)
        public Table CurrentTable;//а, может, я тупица)
        public WhatMove Move;
    }
}
