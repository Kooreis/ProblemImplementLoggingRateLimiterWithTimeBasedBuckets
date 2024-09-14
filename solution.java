import java.util.*;

public class Main {
    public static void main(String[] args) {
        Logger logger = new Logger();
    }
}

class Logger {
    private Map<String, Integer> msgMap;

    public Logger() {
        msgMap = new HashMap<>();
    }
}