using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    class Table //shit by FoKycHuK. Не меняйте код позязя не сказав мне :3 спасибо.
    {
        private List<PairCard> tablePosition = new List<PairCard>(); //скрытый лист, содержащий, собсно, пары.
        public void AddOffCard(Card offCard) //добавление карты в лист, нападение. 
        {
            var card = new PairCard();  //может, можно проще? - отлично же, ну
            card.OffCard = offCard;
            tablePosition.Add(card);
        }
        public void AddDefCard(Card defCard, int num)
        {
            tablePosition[num].DefCard = defCard; 
        }
        public int HowMuch()
        {
            return tablePosition.Count;
        }
        public void Clear()
        {
            tablePosition.Clear();
        }
        public List<PairCard> TablePosition
        {
            get {return tablePosition;}
        }
    }
    class PairCard // Вместо Tuple
    {
        private Card offCard;
        public Card OffCard
        {
            get { return offCard; }
            set { offCard = value; }
        }
        private Card defCard;
        public Card DefCard
        {
            get { return defCard; }
            set { defCard = value; }
        }
        public bool IsBeaten()
        {
            return defCard != null;
        }
    }
}
