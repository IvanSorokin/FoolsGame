using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolsGame
{
    public class Table //shit by FoKycHuK. Не меняйте код позязя не сказав мне :3 спасибо.
    {
        private List<PairCard> tablePosition = new List<PairCard>(); //скрытый лист, содержащий, собсно, пары.
        public void AddOffCard(Card offCard) //добавление карты в лист, нападение. 
        {
            tablePosition.Add(new PairCard { OffCard = offCard });
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
        
        /*
        List<PairCard> Beaten; // я настаиваю что эти массивы лучше бы разделить
        List<Card> Open;
        
        pu IEnumerable<Card> All
        {
            foreach(var e in Beaten) { yield return e.First; yield return e.Second; }
            fore(var e in Open) yield return e;
        }
        */
    }
    public class PairCard // Вместо Tuple
    {
        public Card OffCard
        {
            get;
            set;
        }
        public Card DefCard
        {
            get;
            set;
        }
        public bool IsBeaten()
        {
            return DefCard != null;
        }
    }
}
