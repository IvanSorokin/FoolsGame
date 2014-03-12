using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    public class AttackResponse
    {
        public List<Card> OffCards;
        public List<Card> PlayerHand;//зачем?
        public Table CurrentTable;//может не заставлять людей делать это? 
        //пока что сделала без этих 2 полей. Если я неправа - легко исправить
    }
}
