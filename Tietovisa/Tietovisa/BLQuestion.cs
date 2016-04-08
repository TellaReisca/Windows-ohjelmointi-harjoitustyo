using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tietovisa
{
    class BLQuestion
    {
        private int questionKey;

        public int QuestionKey
        {
            get { return questionKey; }
            set { questionKey = value; }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        #region CONSTRUCTROS

        public BLQuestion()
        {
           
        }

        public BLQuestion(int questionKey, string content)
        {
            this.questionKey = questionKey;
            this.content = content;
        }

        

        #endregion

        public string getString()
        {
            return questionKey +" "+ content;
        }

    }
}
