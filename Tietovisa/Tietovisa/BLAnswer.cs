using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tietovisa
{
    class BLAnswer
    {
        private int answerKey;

        public int AnswerKey
        {
            get { return answerKey; }
            set { answerKey = value; }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private int flag;

        public int Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        #region CONSTRUCTROS

        public BLAnswer()
        {

        }

        public BLAnswer(int answerKey, string content, int flag)
        {
            this.answerKey = answerKey;
            this.content = content;
            this.flag = flag;
        }



        #endregion

        public string getString()
        {
            return answerKey + " " + content;
        }


        
    }
}
