using System.Collections.Generic;

namespace RecognizeClass.Data
{
    public class RecognitionInfo
    {
        public char Class { get; set; }

        public IDictionary<Zond, int> ZondCrossDictionary { get; set; }
    }
}
