namespace Teddy {
    public class XManager {
        private static XManager _instance = null;

        private XManager() {
            // to do 
        }

        public static XManager getInstance() {
            if (_instance == null) {
                _instance = new XManager();
            }
            return _instance;
        }
    }
}